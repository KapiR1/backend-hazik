using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_elso_server.Models
{
    [DataContract]
    public class Zeneszam
    {
        [DataMember]
        public int ZeneszamAz { get; set; }
        [DataMember]
        public string ZeneszamCim { get; set; }
        [DataMember]
        public int ZeneszamHossz { get; set; }

        public override string ToString()
        {
            return $"{ZeneszamAz};{ZeneszamCim};{ZeneszamHossz}";
        }
    }
}