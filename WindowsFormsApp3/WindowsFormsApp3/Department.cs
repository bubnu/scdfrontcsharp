using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using sample_22_backend.Converters;

namespace WindowsFormsApp3
{
    internal class Department
    {
        public int id { get; set; }
        public string description { get; set; }
        
        [JsonConverter(typeof(IntToStringConverter))]
        public int parentID { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public int managerID { get; set; }

        public Department(string description, int parentID, int managerID)
        {
            this.description = description;
            this.parentID = parentID;
            this.managerID = managerID;
        }
        public Department(string description, int id)
        {
            this.description = description;
            this.id = id;
        }
        public Department()
        {

        }

    }
}
