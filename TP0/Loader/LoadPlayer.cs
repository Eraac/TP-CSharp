using System.Collections.Generic;
using TP0.Entity;
using Newtonsoft.Json;
using System;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace TP0.Loader
{
    class PlayerConverter : CustomCreationConverter<Player>
    {
        public override Player Create(Type objectType)
        {
            return new Player();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Doc. http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Linq_JObject_Property.htm
            JObject jsonObject = JObject.Load(reader);
            var properties = jsonObject.Property("teams");

            Console.WriteLine(properties.Value);

            return new Player();
        }
    }

    class LoadPlayer
    {
        public LoadPlayer() {}

        public List<Player> loadAll()
        {
            List<Player> players = new List<Player>();
            string[] playersName = new string[1] { "kevin" };

            foreach(string playerName in playersName) {
                players.Add(loadOne(playerName));
            }

            return players;
        }

        public Player loadOne(string name)
        {
            // TODO check if file exists
            string stringJson = File.ReadAllText("Assets/Player/" + name + ".json");

            return JsonConvert.DeserializeObject<Player>(stringJson, new PlayerConverter());
        }
    }
}
