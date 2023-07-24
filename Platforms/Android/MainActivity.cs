using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;
using Android.Content;
using Android.Content.Res;
using Microsoft.Maui.Platform;
using Android.Media;

namespace AIGalaxy;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static string DocumentsPath { get; set; }

    public static string PicturesPath { get; set; }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        DocumentsPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments ).AbsolutePath;
        PicturesPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
        //其他初始化代码
        //var intent = new Intent(Settings.ActionManageAllFilesAccessPermission);
        //StartActivityForResult(intent, 0);
    }

    public static void UpdateMedia(string filePath)
    {
        MediaScannerConnection.ScanFile(Android.App.Application.Context,
    new string[] { filePath }, null, null);

    }
}
