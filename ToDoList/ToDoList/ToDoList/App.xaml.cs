using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoList.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        private static void SetMainPage()
        {
            Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}

