using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Reflection;
using ProEngApp.Models;

namespace ProEngApp.ViewModels
{
    class AdvancedLearnViewModel
    {
        public List<WordModel> AdvancedList { get; set; }

        public AdvancedLearnViewModel()
        {
            Assembly assenbly = typeof(WordViewModel).Assembly;
            var data = assenbly.GetManifestResourceNames();
            using (var stream = assenbly.GetManifestResourceStream("ProEngApp.Data.Advanced300.json"))
            {
                var readData = WordViewModel.LoadJson(stream);

                AdvancedList = GetEnglishData(readData);
            }
        }

        private List<WordModel> GetEnglishData(string jsonData)
        {
            try
            {
                var clientarray = JObject.Parse(jsonData)["Advanced300"].Value<JArray>();
                var wordDataModel = new WordViewModel();

                foreach (var data in clientarray)
                {
                    wordDataModel.AdvancedList.Add(new WordModel {
                        name = data["name"].ToString(),
                        mean = data["mean"].ToString(),
                        part = data["part"].ToString()
                    });
                }
                return wordDataModel.AdvancedList;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
