using BlingTree.Models;
using System.Text.Json;

namespace BlingTree
{
    public class ItemService
    {
        // Declaring the WebHostEnvironment variable
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// IWebHostEnvironment: allow us to retrieve the JSON file
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public ItemService(IWebHostEnvironment webHostEnvironment)
        {

            WebHostEnvironment = webHostEnvironment;

        }

        /// <summary>
        /// Get the file name of the json from the Data folder
        /// </summary>
        private string JsonFileName
        {

            get { return Path.Combine("Data", "items.json"); }

        }

        /// <summary>
        /// Retrieving the json text and converting it to the objects
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public IEnumerable<Item> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                // Making an array of objects. Read the json file to the end.
                var result = JsonSerializer.Deserialize<Item[]>(jsonFileReader.ReadToEnd(),
                     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }

        }
    }
}
