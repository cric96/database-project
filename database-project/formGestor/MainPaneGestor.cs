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
        private TableLayoutPanel mainTable;

        public MainPaneGestor(TableLayoutPanel main)
        {
            if(main == null)
            {
                throw new ArgumentNullException();
            }
            this.mainTable = main;
        }
        public Panel getCurrentPanel()
        {
            return this.getMainChild();
        }

        public void enableShowing()
        {

        }

        public void disableShowing()
        {

        }

        public void setPanel(Panel aPanel)
        {
            if(aPanel == null)
            {
                throw new ArgumentNullException();
            }
            this.mainTable.Controls.Add(aPanel,0,1); 
        }

        private Panel getMainChild()
        {
           
            return (Panel)this.mainTable.GetControlFromPosition(0,1);
        }

        private Panel getSearchPanel()
        {
            return (Panel)this.mainTable.Controls.GetEnumerator().Current;
        }
    }
}
