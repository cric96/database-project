using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization.node
{
    class InsertNode : AbstractImageNode
    {
        public InsertNode(EventHandler action) : base(Properties.Resources.addizione)
        {
            this.getImage().Click += action;
        }
    }
}
