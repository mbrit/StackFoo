using System;
using System.Collections.Generic;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;

namespace Br.StackFoo
{
    internal class TagUpdateEngine : ElapsingServiceEngine
    {
        internal TagUpdateEngine()
            : base(ElapsingServiceEngineFlags.UseLocalTime)
        {
        }

        protected override void OnStarted(EventArgs e)
        {
            base.OnStarted(e);
            this.ElapseNow();
        }

        protected override DateTime GetNextTimeToElapse()
        {
            return this.CurrentTime.AddHours(1);
        }

        protected override void OnElapsed(EventArgs e)
        {
            base.OnElapsed(e);

            // go...
            using (TransactionState txn = Database.StartTransaction())
            {
                try
                {
                    // go...
                    Database.ExecuteNonQuery(new SqlStatement("update tags set isactive=0 where forceactive=0"));

                    // walk...
                    int page = 1;
                    bool stop = false;
                    while (true)
                    {
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.stackoverflow.com/1.1/tags?sort=popular&order=desc&pagesize=100&page=" + page.ToString());
                        httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                        httpWebRequest.Method = "GET";
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        string data = null;
                        Console.WriteLine("Requesting...");
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            data = streamReader.ReadToEnd();

                        // load...
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        IDictionary tags = (IDictionary)serializer.DeserializeObject(data);

                        bool found = false;
                        foreach (IDictionary tag in ((IEnumerable)tags["tags"]))
                        {
                            string name = (string)tag["name"];
                            int count = (int)tag["count"];

                            if (this.Log.IsInfoEnabled)
                                this.Log.InfoFormat("Found '{0}' ({1})...", name, count);

                            if (count < 1000)
                            {
                                stop = true;
                                break;
                            }

                            TagItem item = TagItem.GetByName(name);
                            if (item == null)
                            {
                                item = new TagItem();
                                item.Name = name;
                            }
                            item.IsActive = true;
                            item.LastCount = count;

                            item.SaveChanges();

                            found = true;
                        }

                        if (!(found))
                            stop = true;

                        // if...
                        if (stop)
                        {
                            if (this.Log.IsInfoEnabled)
                                this.Log.Info("Stopping.");
                            break;
                        }

                        // next...
                        page++;
                    }

                    // ok...
                    txn.Commit();
                }
                catch (Exception ex)
                {
                    txn.Rollback(ex);
                    throw new InvalidOperationException("The operation failed", ex);
                }
            }

            if (this.Log.IsInfoEnabled)
                this.Log.Info("Finished checking tags.");
        }
    }
}
