# EpicInstallFinder
エピックゲームズランチャーから、インストールされたゲームのインストール情報を入手するクラス

## サンプルコード
```cs
EIF eif = new EIF("fn", "4fe75bbc5a674f4f9b356b5c90567da5", "Fortnite");

string installLocation = eif.InstallLocation();
string namespaceId = eif.NamespaceId();
string itemId = eif.ItemId();
string artifactId = eif.ArtifactId();
string appVersion = eif.AppVersion();
string appName = eif.AppName();

eif.Dump();
```

```
InstallLocation -> C:\Program Files\Epic Games/Fortnite
NamespaceId -> fn
ItemId -> 4fe75bbc5a674f4f9b356b5c90567da5
ArtifactId -> Fortnite
AppVersion -> ++Fortnite+Release-??.??-CL-????????-Windows
AppName -> Fortnite
```
