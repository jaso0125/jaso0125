using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            InitializeControlers();
        }

        private void InitializeControlers()
        {
            pickOrder.Items.Add("作成順");
            pickOrder.Items.Add("項目名順");
            pickOrder.Items.Add("期日順");
        }
    }
}