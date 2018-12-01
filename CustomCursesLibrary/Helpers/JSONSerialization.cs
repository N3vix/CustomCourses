using Newtonsoft.Json;

namespace CustomCursesLibrary.Helpers
{
    public static class JsonSerialization<TModel>
    {
        public static TModel GetModel(string item)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.DeserializeObject<TModel>(item, settings);
            //_Model = JsonConvert.DeserializeObject<TModel>(File.ReadAllText(Path), settings);
        }
        public static string CreateModel(TModel model)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            return JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented, settings);
            //File.WriteAllText(Path, JsonConvert.SerializeObject(_Model, Newtonsoft.Json.Formatting.Indented, settings));
            //return true;
        }
    }
}