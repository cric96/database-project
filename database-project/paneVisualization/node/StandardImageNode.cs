using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_project.paneVisualization.node
{
    class StandardImageNode : AbstractImageNode
    {
        public StandardImageNode(Image image,EventHandler action) : base(image)
        {
            this.getImage().Click += action;
        }
    }
}
