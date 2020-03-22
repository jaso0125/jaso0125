using ToDoList.Helpers;
using ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.ViewModels
{
    /// <summary>
    /// MainPageのViewModelクラス
    /// </summary>
    public class MainViewModel : ObservableObject 
    {
        public ToDoFiltableCollection Items { get; set; }
    }
}
