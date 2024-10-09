using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_elso_server.Models
{
    [DataContract]
    public class Eloado
    {
        [DataMember]
        public int EloadoAz { get; set; }
        [DataMember]
        public string EloadoName { get; set; }
        
        public override string ToString()
        {
            return $"{EloadoAz};{EloadoName}";
        }
    }
}