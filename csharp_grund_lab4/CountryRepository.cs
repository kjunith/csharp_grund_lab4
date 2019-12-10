using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace csharp_grund_lab4
{
    public sealed class CountryRepository
    {
        private static CountryRepository instance;
        private static readonly object padlock = new object();
        public CountryList CountryList { get; set; }

        CountryRepository()
        {
        }

        public static CountryRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CountryRepository();
                    }

                    return instance;
                }
            }
        }

        public void LoadData()
        {
            string jsonFile = "rawData.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFile}");

            using var reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();

            CountryList = JsonConvert.DeserializeObject<CountryList>(jsonString);
        }
    }
}
