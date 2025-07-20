using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EpicInstallFinder
{
    //
    // 概要:
    //     エピックゲームズランチャーから、インストールされたゲームのインストール情報を入手するクラス。
    internal class EIF
    {
        //
        // 概要:
        //     ランチャーのインストール情報が保存されたファイルのパスを取得します。
        //
        // 値:
        //     ランチャーのインストール情報が保存されたファイルのパス。
        private static string InstalledLocation = "C:\\ProgramData\\Epic\\UnrealEngineLauncher\\LauncherInstalled.dat";


        //
        // 概要:
        //     クラスの新しいインスタンスを初期化します。
        public EIF(string namespaceId, string itemId, string artifactId)
        {
            if (namespaceId == null && itemId == null && artifactId == null)
            {
                return;
            }

            string jsonString = File.ReadAllText(InstalledLocation);

            if (jsonString == null)
            {
                return;
            }

            JObject jsonObject = JObject.Parse(jsonString);

            if (jsonObject == null)
            {
                return;
            }

            bool found = false;

            foreach (JObject installationList in jsonObject["InstallationList"])
            {
                bool bNamespaceId = namespaceId == null || installationList["NamespaceId"].ToString() == namespaceId;
                bool bItemId = itemId == null || installationList["ItemId"].ToString() == itemId;
                bool bArtifactId = artifactId == null || installationList["ArtifactId"].ToString() == artifactId;

                if (bNamespaceId && bItemId && bArtifactId)
                {
                    found = true;

                    this.Data.SetInstallLocation(installationList["InstallLocation"].ToString());
                    this.Data.SetNamespaceId(installationList["NamespaceId"].ToString());
                    this.Data.SetItemId(installationList["ItemId"].ToString());
                    this.Data.SetArtifactId(installationList["ArtifactId"].ToString());
                    this.Data.SetAppVersion(installationList["AppVersion"].ToString());
                    this.Data.SetAppName(installationList["AppName"].ToString());
                }
            }

            if (!found)
            {
                return;
            }

            this.IsValid = File.Exists(InstalledLocation) ? true : false;
        }


        //
        // 概要:
        //     インスタンスが有効かどうかを示す値を取得します。
        //
        // 戻り値:
        //     インスタンスが有効な場合は true。 それ以外の場合は false。
        //
        protected bool IsValid = false;


        //
        // 概要:
        //     インスタンスが有効かどうかを示す値を取得します。
        //
        // 戻り値:
        //     インスタンスが有効な場合は true。 それ以外の場合は false。
        //
        public bool Valid()
        {
            if (this == null)
            {
                MessageBox.Show("インスタンスが存在しません。", "EpicInstallFinder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return this.IsValid;
        }


        //
        // 概要:
        //     インストールされたゲームの情報
        public struct Installation
        {
            //
            // 概要:
            //     InstallLocation を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は InstallLocation。それ以外の場合は null。
            public string InstallLocation;

            //
            // 概要:
            //     NamespaceId を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は NamespaceId。それ以外の場合は null。
            private string NamespaceId;

            //
            // 概要:
            //     ArtifItemIdactId を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は ItemId。それ以外の場合は null。
            private string ItemId;

            //
            // 概要:
            //     ArtifactId を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は ArtifactId。それ以外の場合は null。
            private string ArtifactId;

            //
            // 概要:
            //     AppVersion を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は AppVersion。それ以外の場合は null。
            private string AppVersion;

            //
            // 概要:
            //     AppName を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は AppName。それ以外の場合は null。
            private string AppName;


            //
            // 概要:
            //     InstallLocation を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は InstallLocation。それ以外の場合は null。
            public string GetInstallLocation()
            {
                return this.InstallLocation;
            }

            //
            // 概要:
            //     NamespaceId を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は NamespaceId。それ以外の場合は null。
            public string GetNamespaceId()
            {
                return this.NamespaceId;
            }

            //
            // 概要:
            //     ItemId を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は ItemId。それ以外の場合は null。
            public string GetItemId()
            {
                return this.ItemId;
            }

            //
            // 概要:
            //     ArtifactId を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は ArtifactId。それ以外の場合は null。
            public string GetArtifactId()
            {
                return this.ArtifactId;
            }

            //
            // 概要:
            //     AppVersion を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は AppVersion。それ以外の場合は null。
            public string GetAppVersion()
            {
                return this.AppVersion;
            }

            //
            // 概要:
            //     AppVersion を取得します。
            //
            // 値:
            //     インスタンスが有効な場合は AppVersion。それ以外の場合は null。
            public string GetAppName()
            {
                return this.AppName;
            }


            //
            // 概要:
            //     InstallLocation を変更します。
            //
            // パラメーター:
            //   value:
            //     上書きする値。
            public void SetInstallLocation(string value)
            {
                this.InstallLocation = value;
            }

            //
            // 概要:
            //     NamespaceId を変更します。
            //
            // パラメーター:
            //   value:
            //     上書きする値。
            public void SetNamespaceId(string value)
            {
                this.NamespaceId = value;
            }

            //
            // 概要:
            //     ItemId を変更します。
            //
            // パラメーター:
            //   value:
            //     上書きする値。
            public void SetItemId(string value)
            {
                this.ItemId = value;
            }

            //
            // 概要:
            //     ArtifactId を変更します。
            //
            // パラメーター:
            //   value:
            //     上書きする値。
            public void SetArtifactId(string value)
            {
                this.ArtifactId = value;
            }

            //
            // 概要:
            //     AppVersion を変更します。
            //
            // パラメーター:
            //   value:
            //     上書きする値。
            public void SetAppVersion(string value)
            {
                this.AppVersion = value;
            }

            //
            // 概要:
            //     AppVersion を変更します。
            //
            // パラメーター:
            //   value:
            //     上書きする値。
            public void SetAppName(string value)
            {
                this.AppName = value;
            }
        }


        //
        // 概要:
        //     インストールされたゲームの情報。
        //
        // 値:
        //     インストールされたゲームの情報のデータ。
        Installation Data;


        //
        // 概要:
        //     InstallLocation を取得します。
        //
        // 値:
        //     インスタンスが有効な場合は InstallLocation。それ以外の場合は null。
        public string InstallLocation()
        {
            if (!this.Valid())
            {
                return null;
            }

            return this.Data.GetInstallLocation();
        }

        //
        // 概要:
        //     NamespaceId を取得します。
        //
        // 値:
        //     インスタンスが有効な場合は NamespaceId。それ以外の場合は null。
        public string NamespaceId()
        {
            if (!this.Valid())
            {
                return null;
            }

            return this.Data.GetNamespaceId();
        }

        //
        // 概要:
        //     ItemId を取得します。
        //
        // 値:
        //     インスタンスが有効な場合は ItemId。それ以外の場合は null。
        public string ItemId()
        {
            if (!this.Valid())
            {
                return null;
            }

            return this.Data.GetItemId();
        }

        //
        // 概要:
        //     ArtifactId を取得します。
        //
        // 値:
        //     インスタンスが有効な場合は ArtifactId。それ以外の場合は null。
        public string ArtifactId()
        {
            if (!this.Valid())
            {
                return null;
            }

            return this.Data.GetArtifactId();
        }

        //
        // 概要:
        //     AppVersion を取得します。
        //
        // 値:
        //     インスタンスが有効な場合は AppVersion。それ以外の場合は null。
        public string AppVersion()
        {
            if (!this.Valid())
            {
                return null;
            }

            return this.Data.GetAppVersion();
        }

        //
        // 概要:
        //     AppVersion を取得します。
        //
        // 値:
        //     インスタンスが有効な場合は AppVersion。それ以外の場合は null。
        public string AppName()
        {
            if (!this.Valid())
            {
                return null;
            }

            return this.Data.GetAppName();
        }


        //
        // 概要:
        //     取得したゲームのインストール情報を表示します。
        //
        public void Dump()
        {
            if (!this.Valid())
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("InstallLocation -> " + this.InstallLocation());
            Console.WriteLine("NamespaceId -> " + this.NamespaceId());
            Console.WriteLine("ItemId -> " + this.ItemId());
            Console.WriteLine("ArtifactId -> " + this.ArtifactId());
            Console.WriteLine("AppVersion -> " + this.AppVersion());
            Console.WriteLine("AppName -> " + this.AppName());
            Console.WriteLine();
        }
    }
}
