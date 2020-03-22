using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        public SettingPage(Setting item)
        {
            InitializeComponent();
            viewModel = new SettingViewModel(item);
            BindingContext = viewModel;
                
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Send(this, "UpdateSetting");
            base.OnDisappearing();
        }

        private SettingViewModel viewModel;
    }
}