using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_project.paneVisualization.insertPane
{
    class InsertPaneFactory
    {
        public static Pane getInsertIngrediente()
        {
            return new IngredientInsert();
        }

        public static Pane getInsertRicetta()
        {
            return new RicettaInsert();
        }

        public static Pane getInsertMenu()
        {
            return new MenuInsert();
        }
    }
}
