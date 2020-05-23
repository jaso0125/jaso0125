using System;
using System.Collections.Generic;
using System.Text;
using ProEngApp.Models;

using System.Resources;


namespace ProEngApp.ViewModels
{
    class WordViewModel
    {
        public List<WordModel> AdvancedList { get; set; }

        public WordViewModel()
        {
            AdvancedList = new List<WordModel>();
        }
        /// <summary>
        /// JSON形式から復元
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static string LoadJson(System.IO.Stream st)
        {
            var sr = new System.IO.StreamReader(st);
            var json = sr.ReadToEnd();

            return json;
        }
    }
}
