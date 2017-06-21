using database_project.formGestor;
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
            gestor = new MainPaneGestor(rightPane);

            Console.Out.Write(gestor.getCurrentPanel().Name);
            Panel pane = new Panel();
            pane.Name = "myPane";
            gestor.setPanel(pane);
            Console.Out.Write(gestor.getCurrentPanel().Name);
            FlowLayoutPanel test = new FlowLayoutPanel();
            test.Name = "Apane";
            gestor.setPanel(test);
            Console.Out.Write(gestor.getCurrentPanel().Name);
        }
        
    }
}
