using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_project.ricettaUtilities
{
    public enum Difficoltà
    {
        BASSA,
        MEDIA,
        ELEVATA
    }

    public static class DifficoltàUtilities
    {
        public static string getDifficulty(Difficoltà difficoltà)
        {
            switch(difficoltà)
            {
                case Difficoltà.BASSA:
                    return "Bassa";
                case Difficoltà.MEDIA:
                    return "Media";
                case Difficoltà.ELEVATA:
                    return "Elevata";
            }
            throw new ArgumentException();
        }

        public static List<Difficoltà> getDifficulties()
        {
            List<Difficoltà> difficoltà = new List<Difficoltà>();
            difficoltà.Add(Difficoltà.BASSA);
            difficoltà.Add(Difficoltà.MEDIA);
            difficoltà.Add(Difficoltà.ELEVATA);
            return difficoltà;
        }
    }
}
