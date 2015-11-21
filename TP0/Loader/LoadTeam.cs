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
    class TeamConverter : CustomCreationConverter<Team>
    {
        public override Team Create(Type objectType)
        {
            return new Team();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {            
            JObject jsonObject = JObject.Load(reader);

            return this.loadTeam(jsonObject, new Team());
        }

        private Team loadTeam(JObject jsonObject, Team team)
        {
            team.name = jsonObject.Property("name").ToString();
            team.description = jsonObject.Property("description").ToString();
            team.nbMatchPlayed = uint.Parse(jsonObject.Property("nb_match_played").Value.ToString());
            team.nbMatchWon = uint.Parse(jsonObject.Property("nb_match_won").Value.ToString());
            dynamic gladiators = jsonObject.Property("gladiators").ToList()[0];

            LoadGladiator loaderGladiator = new LoadGladiator();

            foreach (string gladiator in gladiators) {
                team.addGladiator(loaderGladiator.loadOne(gladiator));
            }

            return team;
        }
    }

    class LoadTeam
    {
        public LoadTeam() {}

        public Team loadOne(string name)
        {
            // TODO check if file exists
            string stringJson = File.ReadAllText("Assets/Team/" + name + ".json");

            return JsonConvert.DeserializeObject<Team>(stringJson, new TeamConverter());
        }
    }
}
