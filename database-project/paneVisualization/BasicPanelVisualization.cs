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
        private FlowLayoutPanel imagesPane;
        protected BasicPanelVisualization(List<ImageNode> images, FilterNode filter)
        {
            main = new TableLayoutPanel();
            main.Controls.Add(filter.getPanel(), 0, 0);
            this.imagesPane = new FlowLayoutPanel();
            imagesPane.AutoScroll = true;
            foreach(ImageNode image in images)
            {
                imagesPane.Controls.Add(image.getImage());
            }
            
            main.Controls.Add(imagesPane, 0, 1);
            imagesPane.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        }

        public abstract void search(string value);
        
        protected TableLayoutPanel getMainPanel()
        {
            return this.main;
        }
        protected FlowLayoutPanel getImagePanel()
        {
            return this.imagesPane;
        }
        Panel Pane.getPanel()
        {
            return this.main;
        }

        public virtual void deleteAllControl()
        {

            foreach (Control c in this.getImagePanel().Controls)
            {
                c.Dispose();
            }
            this.getImagePanel().Controls.Clear();

            foreach (Control c in this.getMainPanel().Controls)
            {
                c.Dispose();
            }
            this.getMainPanel().Controls.Clear();
        }
    }
}
