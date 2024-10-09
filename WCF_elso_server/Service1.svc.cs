using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_elso_server.Controllers;
using WCF_elso_server.Models;

namespace WCF_elso_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Eloado> GetEloado()
        {
            List<Eloado> list = new EloadoController().ELoadokLista();
            return list;
        }

        public List<Zeneszam> GetZeneszams()
        {
            List<Zeneszam> lista = new ZeneszamController().ZeneszamokLista();
            return lista;
        }

        public string GetEloadoName()
        {
            Eloado eloado = new Eloado()
            {
                EloadoAz = 1,
                EloadoName = "Queen"
            };
            return eloado.EloadoName;
        }

        public string GetZeneszam()
        {
            Zeneszam zeneszam = new Zeneszam()
            {
                ZeneszamAz = 1,
                ZeneszamCim = "Rain",
                ZeneszamHossz = 213
            };
            return zeneszam.ZeneszamCim;
        }

        public string ModositEloado(Eloado eloado)
        {
            return new EloadoController().UpdateEloado(eloado);
        }

        public string UjEloado(Eloado eloado)
        {           
            return new EloadoController().InsertEloado(eloado);
        }

        public string TorolEloado(int id)
        {
            return "";
        }

        public string ModositZeneszam(Zeneszam zeneszam)
        {
            return new ZeneszamController().UpdateZeneszam(zeneszam);
        }

        public string UjZeneszam(Zeneszam zeneszam)
        {
            return new ZeneszamController().InsertZeneszam(zeneszam);
        }

        public string TorolZeneszam(int id)
        {
            return "";
        }
    }
}
