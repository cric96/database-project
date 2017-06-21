using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_project.paneVisualization
{
    interface PaneQueryable : Pane
    {
        void search(String value);
    }
}
