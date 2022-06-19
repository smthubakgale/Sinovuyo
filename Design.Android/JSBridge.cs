 
using Android.Webkit;
using Design;
using Hybrid.Views.Layout;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace Hybrid.Droid
{
    public class JSBridge : Java.Lang.Object
    {
        // Variables
        readonly WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;
        // Constructor
        public JSBridge(HybridWebViewRenderer hybridRenderer)
        {
            hybridWebViewRenderer = new
           WeakReference<HybridWebViewRenderer>(hybridRenderer);
        }
        // Bridge Methods 
        [JavascriptInterface]
        [Export("invokePost")]
        public string InvokePost(string data , string method)
        {
            HybridWebViewRenderer hybridRenderer;
            if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
            { 
                return (string)((HybridWebView)hybridRenderer.Element).InvokePost(data, method);
            }
            else { return null; }
        }

        [JavascriptInterface]
        [Export("invokeGet")]
        public string InvokeGet(string data , string method)
        {
            HybridWebViewRenderer hybridRenderer;
            try
            {
                if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
                {
                    return (string)((HybridWebView)hybridRenderer.Element).InvokeGet(data, method);
                }
                else { return null; }

            } catch { return null; }
        }  
        [JavascriptInterface]
        [Export("invokeAlert")]
        public void InvokeAlert(string data , string method)
        { 
            HybridWebViewRenderer hybridRenderer;
            if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
            { 
                ((HybridWebView)hybridRenderer.Element).InvokeAlert(data , method);
            } 
        }
        // Navigation 
        [JavascriptInterface]
        [Export("invokeNext")]
        public void invokeNext(string page)
        {
            try
            {
                var a = (int)App.session["page"];
                var b = (List<string>)App.session["nav"];

                a = a + 1;
                App.session["page"] = a;

                b.Add(page);
                App.session["nav"] = b;
            }
            catch(Exception er)
            {
                InvokeAlert(er.Message, "Exception");
            }
        }
        [JavascriptInterface]
        [Export("invokeCurrent")]
        public string invokeCurrent()
        {
            var c = "";

            try
            {
                var a = (int)App.session["page"];
                var b = (List<string>)App.session["nav"];
                c = b[a];
            }
            catch (Exception er)
            {
                InvokeAlert(er.Message, "Exception");
            }

            return c;
        }
        [JavascriptInterface]
        [Export("invokeExit")]
        public void invokeExit()
        { 
            App.session["page"] = 0;
            App.session["nav"] = new List<string>() { "index.html" };

            Device.BeginInvokeOnMainThread(async()=>
            {
                await App.Current.MainPage.Navigation.PopAsync();
            });
            
        }
        // File Handling
        [JavascriptInterface]
        [Export("invokeDownload")]
        [Obsolete]
        public string invokeDownload(string data)
        {
            var ret = ""; 
            try
            { 
                string documentsPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "");
                string localFilename = "qrcode.png";
                string localPath = Path.Combine(documentsPath, localFilename); 
                File.WriteAllBytes(localPath, Convert.FromBase64String(data));

                ret = "Done";
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            return ret;
        }
        // 
    } 
}