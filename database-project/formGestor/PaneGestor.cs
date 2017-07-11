using database_project.paneVisualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.formGestor
{
    interface PaneGestor {
        /* return the current pane that is showing*/
        Pane getCurrentPanel();
        /* set a panel into current main panel */
        void setPanel(Pane aPanel);
        /* clear the current pane */ 
        void clearPane();
    }
}
