using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(ToDoList.Droid.ToDoStorage))]
namespace ToDoList.Droid
{
    public class ToDoStorage : ToDoList.Views.IToDoStorage
    {
        public Stream OpenReader(string file)
        {
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docs, file);

            if (File.Exists(path))
            {
                return File.OpenRead(path);
            }
            else
            {
                return null;
            }
        }

        public Stream OpenWriter(string file)
        {
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docs, file);
            return File.OpenWrite(path);
        }
    }
}