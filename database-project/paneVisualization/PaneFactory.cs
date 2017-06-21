using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_project.paneVisualization
{
    class PaneFactory
    {
        public static Pane getMainPane()
        {
            return new MainPanel();
        }
        private PaneFactory() { }
    }
}
