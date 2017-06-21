using database_project.paneVisualization.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization
{

    abstract class BasicPanelVisualization : PaneQueryable
    {
        private TableLayoutPanel main;
        protected BasicPanelVisualization(ISet<ImageNode> images, FilterNode filter)
        {
            main = new TableLayoutPanel();
            main.Controls.Add(filter.getPanel(), 0, 0);
            FlowLayoutPanel imagesPane = new FlowLayoutPanel();
            foreach(ImageNode image in images)
            {
                imagesPane.Controls.Add(image.getImage());
            }
            main.Controls.Add(imagesPane, 0, 1);
        }
        public abstract void search(string value);

        Panel Pane.getPanel()
        {
            return this.main;
        }
    }
}
