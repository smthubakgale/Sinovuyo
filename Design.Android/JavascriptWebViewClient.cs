 
using Android.Webkit;
using Design;
using Xamarin.Forms.Platform.Android;

namespace Hybrid.Droid
{
    public class JavascriptWebViewClient : FormsWebViewClient
    { 
        // Constructor
        public JavascriptWebViewClient(HybridWebViewRenderer renderer) : base(renderer) { }
        // Methods
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url); 
        }
    }
}