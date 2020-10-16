using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoCosmos.Models
{
    public class Todo
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "activity")]
        public string Activity { get; set; }

        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Todo()
        {
            Id = Guid.NewGuid().ToString();
            Completed = false;
            Created = DateTime.Now;
        }
    }
}
