using database_project.paneVisualization;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.formGestor
{
    public class MainPaneGestor : PaneGestor
    {
        private static readonly MainPaneGestor SINGLETON = new MainPaneGestor();
        private TableLayoutPanel mainTable;
        private Pane current;
        public static MainPaneGestor getInstance()
        {
            return SINGLETON;
        }
        public void setMainPane(TableLayoutPanel pane)
        {
            if(this.mainTable != null)
            {
                throw new ApplicationException("the table is already set");
            }
            if(pane == null)
            {
                throw new ArgumentNullException();
            }
            this.mainTable = pane;
        }
        private MainPaneGestor() {}
        public Pane getCurrentPanel()
        {
            return this.current;
        }

        public void enableShowingSearch()
        {
            this.getSearchPanel().Show();
        }

        public void disableShowingSearch()
        {
            this.getSearchPanel().Hide();
        }

        public void setPanel(Pane aPane)
        {
            if(aPane == null)
            {
                throw new ArgumentNullException();
            }
            if (this.current != null)
            {
                this.mainTable.Controls.Remove(this.current.getPanel());
            }
            this.clearPane();
            
            this.current = aPane;
            this.mainTable.Controls.Add(aPane.getPanel(), 0, 1);
            aPane.getPanel().Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        }

        public void clearPane()
        {
            Pane last = this.current;
            if (last != null)
            {
                last.deleteAllControl();
                foreach (Control c in last.getPanel().Controls) c.Dispose();
                last.getPanel().Controls.Clear();
            }
        }
        private Panel getSearchPanel()
        {
            return (Panel)this.mainTable.GetControlFromPosition(0, 0);
        }
        private void checkInitilized()
        {
            if(this.mainTable == null)
            {
                throw new ApplicationException("the table is not already set");
            }
        }
    }
}
