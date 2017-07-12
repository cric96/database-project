using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization.node
{
    class AbstractImageNode : ImageNode
    {
        private Button image;
        public AbstractImageNode(Image image)
        {
            this.image = new Button();
            this.image.BackgroundImage = image;
            this.image.BackgroundImageLayout = ImageLayout.Stretch;
            this.image.Size = new Size(100, 100);
            this.image.FlatStyle = FlatStyle.Flat;
        }
        public virtual Button getImage()
        {
            return this.image;
        }
    }
}
