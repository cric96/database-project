using database_project.formGestor;
using database_project.paneVisualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project
{
    public partial class Main : Form
    {
        private MainPaneGestor gestor;
        public Main()
        {
            InitializeComponent();
            gestor = MainPaneGestor.getInstance();
            gestor.setMainPane(rightPane);
            gestor.setPanel(PaneFactory.getMainPane());
            gestor.disableShowingSearch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gestor.enableShowingSearch();
            gestor.clearPane();
            gestor.setPanel(PaneFactory.getRicettaPane());
        }
        //Ingredienti
        private void button2_Click(object sender, EventArgs e)
        {
            gestor.disableShowingSearch();
            gestor.clearPane();
            gestor.setPanel(PaneFactory.getIngredientPane());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestor.enableShowingSearch();
            gestor.clearPane();
            gestor.setPanel(PaneFactory.getMenuPane());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(MainPaneGestor.getInstance().getCurrentPanel() is PaneQueryable)
            {
                PaneQueryable pane = (PaneQueryable)MainPaneGestor.getInstance().getCurrentPanel();
                pane.search(this.search.Text);
            }
        }
    }
}
