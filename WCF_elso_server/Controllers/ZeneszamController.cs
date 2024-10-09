using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_elso_server.Models;
using System.IO;

namespace WCF_elso_server.Controllers
{
    public class ZeneszamController
    {
        public List<Zeneszam> ZeneszamokLista()
        {
            string[] sor = File.ReadAllLines("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\ZeneszamAdatok.txt");
            List<Zeneszam> lista = new List<Zeneszam>();
            for (int i = 1; i < sor.Length; i++)
            {
                string[] valtas = sor[i].Split(';');
                lista.Add(new Zeneszam()
                {
                    ZeneszamAz = int.Parse(valtas[0]),
                    ZeneszamCim = valtas[1],
                    ZeneszamHossz = int.Parse(valtas[2])
                });
            }
            return lista;
        }
        public string InsertZeneszam(Zeneszam ujZeneszam)
        {
            ujZeneszam.ZeneszamAz = GenerateID();
            StreamWriter kimenet = new StreamWriter("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\ZeneszamAdatok.txt", true);

            kimenet.WriteLine(ujZeneszam.ToString());
            kimenet.WriteLine(ujZeneszam.ZeneszamHossz.ToString());
            kimenet.Close();
            return "Sikeresen mentettük az Zeneszamot.";
        }
        int GenerateID()
        {
            return ZeneszamokLista().Select(Zeneszam => Zeneszam.ZeneszamAz).ToList().Max() + 1;
        }


        public string UpdateZeneszam(Zeneszam zeneszam)
        {
            List<Zeneszam> aktualisok = ZeneszamokLista();
            int index = 0;
            while (index < aktualisok.Count &&
                aktualisok[index].ZeneszamAz != zeneszam.ZeneszamAz)
            {
                index++;
            }

            if (index < aktualisok.Count)
            {
                aktualisok[index].ZeneszamCim = zeneszam.ZeneszamCim;
                aktualisok[index].ZeneszamHossz = zeneszam.ZeneszamHossz;
                StreamWriter ujAllomany = new StreamWriter("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\ZeneszamAdatok.txt");
                ujAllomany.WriteLine("ZeneszamAzon;ZeneszamNev;ZeneszamHossz");
                foreach (Zeneszam a in aktualisok)
                {
                    ujAllomany.WriteLine(a.ToString());
                }
                ujAllomany.Close();
                return "A módosítás sikeres";

            }
            else
                return "Nincs ilyen azonosítójú zeneszam";
        }

        public string TorolZeneszam(int id)
        {
            List<Zeneszam> aktualisok = ZeneszamokLista();
            int index = 0;
            while (index < aktualisok.Count &&
                aktualisok[index].ZeneszamAz != id)
            {
                index++;
            }

            if (index < aktualisok.Count)
            {  
                StreamWriter ujAllomany = new StreamWriter("C:\\Users\\Admin\\Documents\\Suli\\Órákra_Backend\\13B\\02alkalom\\WCF_elso\\WCF_elso_server\\ZeneszamAdatok.txt");
                ujAllomany.WriteLine("ZeneszamAzon;ZeneszamNev;ZeneszamHossz");
                foreach (Zeneszam a in aktualisok)
                {
                    ujAllomany.WriteLine(a.ToString());
                }
                ujAllomany.Close();
                return "A törlés sikeres";
            }
            else
                return "Nincs ilyen azonosítójú előadó";
        }
    }
}