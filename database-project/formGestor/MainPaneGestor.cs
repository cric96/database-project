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
        public Panel getCurrentPanel()
        {
            return this.getMainChild();
        }
        
        public void enableShowingSearch()
        {
            this.getSearchPanel().Show();
        }

        public void disableShowingSearch()
        {
            this.getSearchPanel().Hide();
        }

        public void setPanel(Panel aPanel)
        {
            if(aPanel == null)
            {
                throw new ArgumentNullException();
            }
            this.mainTable.Controls.Remove(this.getMainChild());
            this.mainTable.Controls.Add(aPanel,0,1);
            aPanel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        }

        private Panel getMainChild()
        {
           
            return (Panel)this.mainTable.GetControlFromPosition(0,1);
        }

        private Panel getSearchPanel()
        {
            return (Panel)(Panel)this.mainTable.GetControlFromPosition(0, 0);
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
