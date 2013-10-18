using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootFX.Common.Data;
using System.Data;
using BootFX.Common.Management;
using BootFX.Common.Data.Text;
using BootFX.Common;
using System.IO;

namespace Br.StackFoo
{
    public  class StackAnalyzer : Loggable
    {
        public string Analyze()
        {
            var endDate = DateTime.Today;
            var startDate = endDate.AddDays(-90);

            // set...
            var sets = new Dictionary<string, List<string>>();
            foreach (TagSet tagSet in TagSet.GetAll())
            {
                var tags = new List<string>();
                sets[tagSet.Name] = tags;

                foreach (var part in tagSet.Tags.Split(','))
                {
                    var usePart = part.Trim();
                    if (usePart.Length > 0)
                        tags.Add(usePart);
                }
            }

            // ok...
            var path = Runtime.Current.GetTempFilePath(".csv");
            using (var writer = new StreamWriter(path))
            {
                var csv = new CsvDataWriter(writer);

                // names...
                var names = new List<string>(sets.Keys);
                names.Sort();

                // walk...
                csv.WriteValue("Week starting");
                foreach (var name in names)
                    csv.WriteValue(name);
                csv.WriteLine();

                // walk...
                var dt = startDate;
                while (dt < endDate)
                {
                    var from = dt;
                    var to = dt.AddDays(7).AddSeconds(-1);

                    if (this.Log.IsInfoEnabled)
                        this.Log.InfoFormat("Scanning {0}...", from);

                    csv.WriteValue(from.ToString("yyyy-MM-dd"));

                    foreach (var name in names)
                    {
                        // get...
                        var builder = new StringBuilder();
                        var sql = new SqlStatement();
                        builder.Append("select count(*) from questions q inner join questiontags qt on q.questionid=qt.questionid inner join tags t on t.tagid=qt.tagid where (");
                        bool first = true;
                        foreach (var tag in sets[name])
                        {
                            if (first)
                                first = false;
                            else
                                builder.Append(" or ");
                            builder.Append("t.name like ");
                            builder.Append(sql.Dialect.FormatVariableNameForQueryText(sql.Parameters.Add(DbType.String, tag + "%")));
                        }
                        builder.Append(") and q.datetime between @from and @to");
                        sql.Parameters.Add("from", DbType.DateTime, from);
                        sql.Parameters.Add("to", DbType.DateTime, to);

                        sql.CommandText = builder.ToString();

                        // get...
                        int count = Database.ExecuteScalarInt32(sql);
                        csv.WriteValue(count);
                    }
                    csv.WriteLine();

                    // next...
                    dt = dt.AddDays(7);
                }
            }

            return path;
        }
    }
}
