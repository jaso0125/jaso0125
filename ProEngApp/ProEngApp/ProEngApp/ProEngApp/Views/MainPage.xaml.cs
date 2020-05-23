using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProEngApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        async void AdvancedButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdvancedLearnPage());
        }

        async void BasicButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasicLearnPage());
        }
    }
}