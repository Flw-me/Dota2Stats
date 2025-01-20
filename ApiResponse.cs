using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class ApiResponse<T>
    {
        [JsonProperty("rows")]
        public List<T> Rows { get; set; }
    }
}
