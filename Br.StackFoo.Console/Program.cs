using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Web.Script.Serialization;
using BootFX.Common;
using System.Net;
using System.IO;
using System.Collections;

namespace Br.StackFoo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // run...
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.stackoverflow.com/1.1/questions?tagged=android&order=desc&sort=creation&pagesize=100");
                //httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                //httpWebRequest.Method = "GET";
                //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //string responseText;
                //Console.WriteLine("Requesting...");
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    responseText = streamReader.ReadToEnd();
                //}

                //Console.WriteLine("Got {0} bytes...", responseText.Length);
                //IDictionary questions = (IDictionary)new JavaScriptSerializer().DeserializeObject(responseText);
                //foreach (IDictionary question in (IEnumerable)questions["questions"])
                //{
                //    //foreach (object key in question.Keys)
                //    //    Console.WriteLine(key);

                //    Console.WriteLine(question["question_id"]);
                //    Console.WriteLine(question["title"]);
                //    Console.WriteLine(UnixTimeStampToDateTime(Convert.ToDouble(question["creation_date"])));
                //    Console.WriteLine("-----------------------------");
                //}

                FooRuntime.Start("Console");

                Console.WriteLine("Mode?");
                var mode = Console.ReadLine();
                if (mode == "s")
                {
                    FooService service = new FooService();
                    service.Start();

                    Console.ReadLine();
                }
                else if (mode == "a")
                {
                    var a = new StackAnalyzer();
                    var path = a.Analyze();
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (Debugger.IsAttached)
                    Console.ReadLine();
            }
        }

    }
}
