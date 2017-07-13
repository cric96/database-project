using System;
using System.Drawing;
using System.Windows.Forms;

namespace database_project.paneVisualization.node
{

    public class nodeFactory 
    {
        private nodeFactory() { }

        public static ImageNode createInsertNode(EventHandler action)
        {
            return new InsertNode(action);
        }

        public static ImageNode createImageNode(EventHandler action, Image image)
        {
            return new StandardImageNode(image, action);
        }

        public static FilterNode  createNodeFilter()
        {
            return new DummyFilterNode();
        }

        internal class DummyFilterNode : FilterNode
        {
            public Panel getPanel()
            {
                return new FlowLayoutPanel();
            }
        }
    }

}