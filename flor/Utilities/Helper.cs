using Newtonsoft.Json;

namespace flor.Utilities
{
    public static class Helper
    {

        public static List<JsonTramo> TransformaJson(string json) {

           return JsonConvert.DeserializeObject<List<JsonTramo>>(json);

        }
    }
}
