using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.XPath;
using sample_22_backend.Converters;

namespace WinFormsApp3
{
    internal class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string enrollDate { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public int departmentID { get; set; }
        [JsonConverter(typeof(IntToStringConverter))]
        public int managerID { get; set; }
        public string email { get; set; }
        public Employee(string name, int departmentID, int managerID, string email)
        {
            this.name = name;
            this.departmentID = departmentID;
            this.managerID = managerID;
            this.email = email;
        }
        public Employee(string email, int id)
        {
            this.email = email;
            this.id = id;
        }
        public Employee(int departmentID, int id)
        {
            this.departmentID=departmentID;
            this.id = id;
        }
        public Employee( int id, string name)
        {
            this.name = name;
            this.id = id;
        }
        public Employee(){
        }
    }
}
