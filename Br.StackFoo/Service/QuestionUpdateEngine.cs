using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;
using System.Threading;
using System.Net;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;

namespace Br.StackFoo
{
    internal class QuestionUpdateEngine : ElapsingServiceEngine
    {
        internal QuestionUpdateEngine()
            : base(ElapsingServiceEngineFlags.UseLocalTime)
        {
        }

        protected override void  OnStarted(EventArgs e)
        {
 	        base.OnStarted(e);
            this.ElapseNow();
        }

        protected override DateTime GetNextTimeToElapse()
        {
            return this.CurrentTime.AddMinutes(1);
        }

        protected override void OnElapsed(EventArgs e)
        {
            base.OnElapsed(e);

            DateTime now = DateTime.UtcNow;
            Random rand = new Random();

            // walk...
            foreach (TagItem tag in TagItem.GetByIsActive(true))
            {
                if (tag.NextUpdateUtc == DateTime.MinValue || now >= tag.NextUpdateUtc)
                {
                    try
                    {
                        HandleTag(tag);

                        tag.LastOk = true;
                        tag.SetDBNull("lasterror");
                    }
                    catch (Exception ex)
                    {
                        if (this.Log.IsErrorEnabled)
                            this.Log.Error(string.Format("Tag update for '{0}' failed.", tag.Name), ex);

                        tag.LastOk = false;
                        tag.LastError = ex.ToString();
                    }
                    finally
                    {
                        now = DateTime.UtcNow;
                        tag.NextUpdateUtc = now.AddMinutes(rand.Next(60, 120));
                        tag.LastUpdateUtc = now;
                        tag.SaveChanges();
                    }

                    // wait...
                    if (this.Log.IsInfoEnabled)
                        this.Log.Info("Waiting...");
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
            }
        }

        private void HandleTag(TagItem tag)
        {
            if (this.Log.IsInfoEnabled)
                this.Log.InfoFormat("Updating tag '{0}'...", tag.Name);

            int page = 1;
            bool stop = false;
            while (true)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://api.stackoverflow.com/1.1/questions?tagged={0}&order=desc&sort=creation&pagesize=100&page={1}",
                    tag.Name, page));
                httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = null;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                }

                Console.WriteLine("Got {0} bytes...", responseText.Length);
                IDictionary questions = (IDictionary)new JavaScriptSerializer().DeserializeObject(responseText);

                bool found = false;
                foreach (IDictionary question in (IEnumerable)questions["questions"])
                {
                    long nativeId = ConversionHelper.ToInt64(question["question_id"], Cultures.System);
                    string title = (string)question["title"];
                    DateTime dt = UnixTimeStampToDateTime(Convert.ToDouble(question["creation_date"]));

                    // ok...
                    QuestionItem item = QuestionItem.GetByNativeId(nativeId);
                    if (item == null)
                    {
                        if (this.Log.IsInfoEnabled)
                            this.Log.InfoFormat("Creating question '{0}' ({1})...", title, nativeId);

                        item = new QuestionItem();
                        item.NativeId = nativeId;
                        item.Title = title;
                        item.TrimToFit("title");
                        item.DateTime = dt;

                        item.SaveChanges();

                        // add...
                        item.AddTag(tag);
                    }
                    else if(page > 1)
                        stop = true;

                    if (stop)
                        break;
                    found = true;
                }

                if (!(found))
                    stop = true;
                if (stop)
                    break;

                // next...
                page++;
            }
        }

        private static DateTime UnixTimeStampToDateTime(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
