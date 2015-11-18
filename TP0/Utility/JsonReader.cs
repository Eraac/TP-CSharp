using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TP0.Utility
{
    class JsonReader
    {
        private 

        public JsonReader(string filename)
        {
            // TODO check if file exists
            string stringJson = File.ReadAllText(filename);

            JsonSerializer serializer = new JsonSerializer();
            JObject json = serializer.Deserialize(stringJson);
        }
    }
}
