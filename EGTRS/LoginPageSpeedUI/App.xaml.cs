using Android.OS;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;


namespace LoginPageSpeedUI
{
    public partial class App : Application
    {
            public App()
            {
            InitializeComponent();            

            MainPage = new NavigationPage(new MainPage());//Very important add this..
                                                              //MainPage = new MainPage(); //not like this        
            }


        public static class Constants
        {
            public const string GitHubReposEndpoint = "https://localhost:44318/";
        }


        protected override void OnStart() 
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        

    }
}
