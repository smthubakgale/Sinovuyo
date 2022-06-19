   
using Android.Content;
using Android.Views;
using Design;
using Hybrid.Droid;
using Hybrid.Views.Layout;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]

namespace Hybrid.Droid
{
    public class HybridWebViewRenderer : WebViewRenderer
    { 
        //
        Context _context;
        // Constructor
        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }
        // Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                ((HybridWebView)Element).Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.SetWebViewClient(new JavascriptWebViewClient(this));
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge"); 
                Device.BeginInvokeOnMainThread(()=>
                {
                    var page = "";
                    Task.Run(async () =>
                    {
                        try
                        {
                            using (var stream = await FileSystem.OpenAppPackageFileAsync("Content/layout.html" ))
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    page = await reader.ReadToEndAsync();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
                        }
                    }).Wait();

                    Control.LoadDataWithBaseURL($"file:///android_asset/Content/", page , "text/html", "UTF-8", null);
                }); 
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((HybridWebView)Element).Cleanup();
            }
            base.Dispose(disposing);
        } 
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            Parent.RequestDisallowInterceptTouchEvent(true);
            return base.DispatchTouchEvent(e);
        }
        //
    }
}