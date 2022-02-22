using System.Collections.Generic;

namespace AssesmentApi.Models
{
    public class JokeResult
    {
        public List<object> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class Jokes
    {
        public int total { get; set; }
        public List<JokeResult> result { get; set; }
    }
}
