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
    public static class FooRuntime
    {
        public static void Start(string module)
        {
            Runtime.Start("Baxter-Reynolds", "Stack Foo", module, typeof(FooRuntime).Assembly.GetName().Version);
        }

        internal static void UpdateDatabase()
        {
            DatabaseUpdate.Current.Update(new OperationItem(), new DatabaseUpdateArgs());
        }
    }
}
