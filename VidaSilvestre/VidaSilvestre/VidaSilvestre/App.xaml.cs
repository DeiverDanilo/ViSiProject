using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VidaSilvestre
{
    public partial class App : Application
    {
        public const string WebServiceUrl = "https://environment.ehp.qld.gov.au/";
        public App()
        {

            InitializeComponent();

            var mainPage = new MainPage() { Title = "Vida Silvestre Mundial" };

            MainPage = new NavigationPage(mainPage)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.DarkBlue
            };
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
    }
}
