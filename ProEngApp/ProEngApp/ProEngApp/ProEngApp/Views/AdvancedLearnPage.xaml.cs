using ProEngApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProEngApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdvancedLearnPage : ContentPage
	{

        public AdvancedLearnPage ()
		{
			InitializeComponent ();
            var advanced = new AdvancedLearnViewModel();
            BindingContext = advanced;
        }

    }
}