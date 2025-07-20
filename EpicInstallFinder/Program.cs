using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicInstallFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EIF eif = new EIF("ue", "d33c86e1279b45fc9a889f5e64ed6705", "UE_5.0");

            string installLocation = eif.InstallLocation();
            string namespaceId = eif.NamespaceId();
            string itemId = eif.ItemId();
            string artifactId = eif.ArtifactId();
            string appVersion = eif.AppVersion();
            string appName = eif.AppName();

            eif.Dump();
        }
    }
}
