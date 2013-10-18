using System;
using System.Collections.Generic;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Services;
using BootFX.Common.Management;

namespace Br.StackFoo
{
    public class FooService : ServiceHost
    {
        public FooService()
        {
            FooRuntime.UpdateDatabase();
            TagSet.CheckTagSets();

            this.Engines.Add(new TagUpdateEngine());
            this.Engines.Add(new QuestionUpdateEngine());
        }
    }
}
