using System.Collections.Generic;

namespace RestClient.Scripts.Core.Models
{
    public class Response
    {
        public long StatusCode { get; set; }

        public string Error { get; set; }

        public string DataText { get; set; }
        public object Dataobj { get; set; }
        public bool hasData { get; set; }

        public Dictionary<string, string> Headers { get; set; }
    }
}