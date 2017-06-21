using database_project.paneVisualization.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization
{
    class PaneFactory
    {
        public static Pane getMainPane()
        {
            return new MainPanel();
        }

        public static PaneQueryable getBasic()
        {
            ISet<ImageNode> images = new SortedSet<ImageNode>();
            images.Add(new InsertNode(new EventHandler(stupid_call)));
            FilterNode basic = new SimpleFilter();
            return new SimplePane(images, basic);
        }
        private PaneFactory() { }
        internal class SimplePane : BasicPanelVisualization
        {
            public SimplePane(ISet<ImageNode> images, FilterNode node) : base(images,node)
            {

            }
            public override void search(string value)
            {
                System.Console.Out.WriteLine(value);
            }
        }
        private static void stupid_call(object sender, EventArgs e)
        {
            System.Console.Out.Write("Click");
        }
        internal class SimpleFilter : FilterNode
        {
            public Panel getPanel()
            {
                return new Panel();
            }
        }
    }
}
