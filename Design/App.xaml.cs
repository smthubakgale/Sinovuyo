using Design.Views.Shared;
using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Design
{
    public partial class App : Application
	{
		// Variables  
		public static IDictionary<string, object> session; 
		// Constructor
		public App()
		{
			InitializeComponent();

			Barrel.ApplicationId = "DeesAndroid";
			session = Application.Current.Properties;

			session.Clear();

            if (!session.ContainsKey("page")) { session.Add("page", 0);  }
            if (!session.ContainsKey("nav")) { session.Add("nav", new List<string>() { "index.html"}); }

			MainPage = new _Layout() ; 
		}
        // Methods 
        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);
			if(uri.Host.ToLower() == "deees.uj.ac.za" && uri.Segments != null && uri.Segments.Length == 3) { } 
			{
				string page = uri.Segments[1].Replace("/", "");
				string param = uri.Segments[2];

				var p = false; var url = "";
				var p1 = long.TryParse(uri.Segments[2] , out long productId); 
				var p2  = (new Regex("([0-9]+(,[0-9]+)+)", RegexOptions.IgnoreCase)).IsMatch(param);

                if (p1 && page == "Product")
				{
					p = true; url = "product.html/" + param;
				}
                else if (p2 && page == "Products")
				{ 
					p = true; url = "products.html/'" + param+"'";
				}

                if (p)
				{
					var a = (int)App.session["page"];
					var b = (List<string>)App.session["nav"];

					a = a + 1;
					App.session["page"] = a;

					b.Add(url);
					App.session["nav"] = b;
					App.Current.MainPage = new _Layout();
				}
			}
        }
        protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps  
		}

		protected override void OnResume()
		{
			// Handle when your app resumes 
		}
		//
	}
}
