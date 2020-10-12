using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoCosmosWithEF.Services
{
    public class Todo
    {


        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "activity")]
        public string Activity { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }


 

        public Todo(string activity)
        {
            Id = Guid.NewGuid().ToString();
            Activity = activity;
            Created = DateTime.Now;
            Completed = false;
        }

    }
}
