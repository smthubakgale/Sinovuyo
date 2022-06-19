using System;
using Xamarin.Forms; 
using Design; 
using Design.Controllers;

namespace Hybrid.Views.Layout
{
    public class HybridWebView : WebView
    {
        // Variables
        public Type type; 
        public static Application app;

        public static readonly BindableProperty UriProperty = BindableProperty.Create
        (
           propertyName: "Uri", returnType: typeof(string), 
           declaringType: typeof(HybridWebView), defaultValue: default(string)
        );
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        // Constructor 
        public HybridWebView() 
        {  
            this.IsEnabled = true; 
        }
        // Bridge Methods  
        public void Cleanup()
        {
            type = null;
        }
        public string InvokePost(string data,string method)
        { 
            try
            {  
                var controller = method.Split('/')[0]; 
                var func = method.Split('/')[1];
                var param = data; 

                var a =  (string) (new HomeController()).Post0(controller, func, param); 

                return a;
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Post :: " + method, ex.Message, "OK");
            }

            return null;
        }
        public string InvokeGet(string data, string method)
        { 
            try
            {
                var controller = method.Split('/')[0];
                var func = method.Split('/')[1];
                var param = data;

                return (string)(new HomeController()).Get0(controller, func, param);
            }
            catch(Exception ex) 
            {
                App.Current.MainPage.DisplayAlert("Get :: " + method , ex.Message , "OK");
            }

            return null;
        } 
        public void InvokeAlert(string data , string method)
        {
            Device.BeginInvokeOnMainThread(()=> 
            {
                App.Current.MainPage.DisplayAlert(method, data, "OK");
            });
        } 
        //================= 
    }

}
