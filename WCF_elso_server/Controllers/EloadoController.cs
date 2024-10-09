using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_elso_server.Models;
using System.IO;

namespace WCF_elso_server.Controllers
{
    public class EloadoController
    {
        public List<Eloado> ELoadokLista()
        {
            string[] sorok = File.ReadAllLines("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\EloadoAdatok.txt");
            List<Eloado> list = new List<Eloado>();
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] bontas = sorok[i].Split(';');
                list.Add(new Eloado() {
                    EloadoAz = int.Parse(bontas[0]),
                    EloadoName = bontas[1]
                });
            }
            return list;
        }

        public string InsertEloado(Eloado ujEloado)
        {
            ujEloado.EloadoAz = GenerateID();
            StreamWriter kimenet = new StreamWriter("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\EloadoAdatok.txt", true);
            
            kimenet.WriteLine(ujEloado.ToString());
            kimenet.Close();
            return "Sikeresen mentettük az előadót.";
        }

        int GenerateID()
        {
            return ELoadokLista().Select(eloado => eloado.EloadoAz).ToList().Max()+1;
        }

        public string UpdateEloado(Eloado eloado)
        {
            //beolvasok az állományból
            List<Eloado> aktualis = ELoadokLista();
            //Megkeresem az ID-t a listában
            int index = 0;
            while (index < aktualis.Count && 
                aktualis[index].EloadoAz != eloado.EloadoAz)
            {
                index++;
            }
            
            if (index < aktualis.Count)
            {   //Ha találok, módosítom a listát
                aktualis[index].EloadoName = eloado.EloadoName;
                //A módosított lista alapján újragenerálom az állományt
                StreamWriter ujAllomany = new StreamWriter("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\EloadoAdatok.txt");
                ujAllomany.WriteLine("eloadoAzon;elodoNev");
                foreach (Eloado a in aktualis)
                {
                    ujAllomany.WriteLine(a.ToString());
                }
                ujAllomany.Close();
                //Üzenem, hogy a módosítás sikeres
                return "A módosítás sikeres";
            }
            else
                //Ha nem találom, üzenem, hogy nincs ilyen
                return "Nincs ilyen azonosítójú előadó";
        }

        public string TorolEloado(int id)
        {
            //beolvasok az állományból
            List<Eloado> aktualis = ELoadokLista();
            //Megkeresem az ID-t a listában
            int index = 0;
            while (index < aktualis.Count &&
                aktualis[index].EloadoAz != id)
            {
                index++;
            }

            if (index < aktualis.Count)
            {   //Ha találok, törlöm a listából az elemet
                
                //A módosított lista alapján újragenerálom az állományt
                StreamWriter ujAllomany = new StreamWriter("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\EloadoAdatok.txt");
                ujAllomany.WriteLine("eloadoAzon;elodoNev");
                foreach (Eloado a in aktualis)
                {
                    ujAllomany.WriteLine(a.ToString());
                }
                ujAllomany.Close();
                //Üzenem, hogy a módosítás sikeres
                return "A törlés sikeres";
            }
            else
                //Ha nem találom, üzenem, hogy nincs ilyen
                return "Nincs ilyen azonosítójú előadó";
        }
    }
}