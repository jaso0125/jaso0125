using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ToDoList.iOS.ToDoStorage))]
namespace ToDoList.iOS
{
    public class ToDoStorage : ToDoList.Views.IToDoStorage
    {
        public Stream OpenReader(string file)
        {
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docs, file);

            if (File.Exists(path)){
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