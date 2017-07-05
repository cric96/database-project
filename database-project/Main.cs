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
            gestor.setPanel(PaneFactory.getBasic());
        }
        //Ingredienti
        private void button2_Click(object sender, EventArgs e)
        {
            gestor.disableShowingSearch();
            gestor.setPanel(PaneFactory.getIngredientPane());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gestor.enableShowingSearch();
            gestor.setPanel(PaneFactory.getBasic());
        }
    }
}
