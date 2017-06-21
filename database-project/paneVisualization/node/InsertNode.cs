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
        private Button imageButton;
        public InsertNode(EventHandler action) : base(Properties.Resources.ingradimento)
        {
            
            imageButton = new Button();
            imageButton.Click += action;
        }
    }
}
