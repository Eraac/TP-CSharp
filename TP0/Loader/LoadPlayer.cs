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
            JObject jsonObject = JObject.Load(reader);

            return this.loadPlayer(jsonObject, new Player());
        }

        private Player loadPlayer(JObject jsonObject, Player player)
        {
            player.name = jsonObject.Property("name").ToString();
            player.firstname = jsonObject.Property("firstname").ToString();
            player.playerName = jsonObject.Property("player_name").ToString();
            //player.createAt = jsonObject.Property("create_at"); // TODO
            dynamic teams = jsonObject.Property("teams").ToList()[0];

            Console.WriteLine(teams.GetType());

            LoadTeam loaderTeam = new LoadTeam();            

            foreach (string team in teams) {
                player.addTeam(loaderTeam.loadOne(team));
            }

            return player;
        }
    }

    class LoadPlayer
    {
        public LoadPlayer() {}

        public List<Player> loadAll()
        {
            List<Player> players = new List<Player>();
            string[] playersName = new string[4] { "kevin", "magali", "david", "noemie" };

            foreach(string playerName in playersName) {
                players.Add(this.loadOne(playerName));
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
