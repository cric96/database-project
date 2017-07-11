using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization
{
    public interface Pane
    {
        Panel getPanel();

        void deleteAllControl();
    }
}
