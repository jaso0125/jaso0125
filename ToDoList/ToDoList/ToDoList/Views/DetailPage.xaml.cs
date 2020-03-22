using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private ToDo _item;


        public DetailPage()
        {
            InitializeComponent();
        }

        public DetailPage(ToDo item)
        {
            InitializeComponent();
            this.BindingContext = _item = item;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            // 元の画面を表示
            await Navigation.PopAsync();
            if (_item.Id == 0)
            {
                // 項目を追加
                MessagingCenter.Send(this, "AddItem", _item);
            }
            else
            {
                // 既存項目の更新
                MessagingCenter.Send(this, "UpdateItem", _item);
            }
        }
    }
}