using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_project.databaseGestor
{
    public class RicettarioDB
    {
        private RicettarioDB() { }
        private static RicettarioGestorDataContext SINGLETON = new RicettarioGestorDataContext();
        public static RicettarioGestorDataContext getInstance()
        {
            return SINGLETON;
        }
    }
}
