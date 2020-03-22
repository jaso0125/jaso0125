using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ViewModels;
using ToDoList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        // 表示するデータ
        private MainViewModel viewModel;

        // 設定
        private Setting setting = new Setting();

        public MainPage()
        {
            InitializeComponent();
            // 内部ストレージから読み込み
            viewModel = new MainViewModel();
            this.Load();
            this.BindingContext = viewModel;

            //メッセージの受信の設定
            receiveMessage();
        }

        private void receiveMessage()
        {
            MessagingCenter.Subscribe<DetailPage, ToDo>(this, "UpdateItem",
                (page, item) =>
                {
                    viewModel.Items.Update(item.Id, item);
                    viewModel.Items.UpdateFilter();
                    // 内部ストレージに保存
                });
            MessagingCenter.Subscribe<DetailPage, ToDo>(this, "AddItem",
                (page, item) =>
                {
                    item.Id = viewModel.Items.Count + 1;
                    viewModel.Items.Add(item);
                });
            MessagingCenter.Subscribe<SettingPage>(this, "UpdateSetting",
                (page) =>
                {
                    viewModel.Items.SetFilter(setting.DispCompleted, setting.SortOrder);
                });
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            var item = ToDo.CreateNew();
            await Navigation.PushAsync(new DetailPage(item));
        }

        private async void Setting_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingPage());
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ToDo;
            if (item == null) { return; }
            await Navigation.PushAsync(new DetailPage(item.Copy()));
            listView.SelectedItem = null;
        }

        IToDoStorage storage = DependencyService.Get<IToDoStorage>();

        /// <summary>
        /// 内部ストレージに保存
        /// </summary>
        public void Save()
        {
            using (var st = storage.OpenWriter("save.xml"))
            {
                viewModel.Items.Save(st);
            }
        }

        /// <summary>
        /// 内部ストレージから読み込み
        /// </summary>
        public void Load()
        {
            var items = new ToDoFiltableCollection();

            using (var st = storage.OpenReader("save.xml"))
            {
                if (st == null || items.Load(st) == false)
                {
                    // 初期データを作成する
                    items = ToDoFiltableCollection.MakeSampleData();
                }
            }
            viewModel.Items = items;
        }
    }
    /// <summary>
    /// ストレージ用のインターフェース
    /// </summary>
    public interface IToDoStorage
    {
        Stream OpenReader(string file);
        Stream OpenWriter(string file);
    }
}