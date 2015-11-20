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
    /*class TeamConverter : CustomCreationConverter<Team>
    {
        public override Team Create(Type objectType)
        {
            return new Team();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Doc. http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Linq_JObject_Property.htm
            JObject jsonObject = JObject.Load(reader);
            var teams = jsonObject.Property("teams").ToList()[0];

            Console.WriteLine(teams[1]);

            return new Team();
        }
    }*/

    class LoadTeam
    {
        public LoadTeam() {}

        public Team loadOne(string name)
        {
            // TODO check if file exists
            /*string stringJson = File.ReadAllText("Assets/Team/" + name + ".json");

            return JsonConvert.DeserializeObject<Team>(stringJson, new TeamConverter());*/

            Team team = new Team();
            team.name = name;

            return team;
        }
    }
}
