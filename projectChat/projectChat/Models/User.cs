using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectChat.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int iduser { get; set; }

        public int ageuser { get; set; }
        public int telephoneuser { get; set; }
   
        public string lastnameuser { get; set; }
        public string nameuser { get; set; }
        public string countryuser { get; set; }
        public string sexouser { get; set; }
        public string emailuser { get; set; }
        public string passworduser { get; set; }
        public string agreeuser { get; set; }
        public string imageuser { get; set; }

        public DateTime dateBirth { get; set; }
        public DateTime dateRegister { get; set; }
       
    }
}
