using ProEngApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProEngApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasicLearnPage : ContentPage
	{
		public BasicLearnPage ()
		{
			InitializeComponent ();
            var basic = new BasicLearnViewModel();
            BindingContext = basic;
        }
	}
}