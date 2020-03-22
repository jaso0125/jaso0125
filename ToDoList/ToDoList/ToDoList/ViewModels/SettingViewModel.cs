using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Helpers;
using ToDoList.Models;
using System.Text;

using Xamarin.Forms;

namespace ToDoList.ViewModels
{
    public class SettingViewModel : ObservableObject
    {
        private Setting setting;

        // 表示順のリスト
        public List<string> SortItems { get; }

        public SettingViewModel(Setting item)
        {
            setting = item;
            SortItems = new List<string>
            {
                "作成順","項目名順","期日順"
            };
        }

        // 完了項目の表示状態
        public bool DispCompleted
        {
            get
            {
                return setting.DispCompleted;
            }
            set
            {
                if(setting.DispCompleted != value)
                {
                    setting.DispCompleted = value;
                    OnpropertyChanged(nameof(DispCompleted));
                }

            }
        }

        // 表示順のインデックス
        public int SortOrder
        {
            get
            {
                return setting.SortOrder;
            }
            set
            {
                if(setting.SortOrder != value)
                {
                    setting.SortOrder = value;
                    OnpropertyChanged(nameof(SortOrder));
                }
            }
        }



    }

}