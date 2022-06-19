 
using Hybrid.Views.Layout;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Design.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class _Layout : ContentPage
    {
        public _Layout()
        { 
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); 
        }
        protected override bool OnBackButtonPressed()
        {   
            var a = (int)App.session["page"];
            var b = (List<string>)App.session["nav"];

            if(a == 0) 
            {
                App.session["page"] = a;
                App.session["nav"] = new List<string>() { "index.html/exit" };
            }
            else
            {
                a = a - 1;
                App.session["page"] = a;

                b.RemoveAt(b.Count - 1);
                App.session["nav"] = b; 
            }

            App.Current.MainPage = new _Layout();

            return true; 
        }
    }
}