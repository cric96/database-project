using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization
{
    class MainPanel : Pane
    {
        private TableLayoutPanel main;
        
        public MainPanel()
        {
            main = new TableLayoutPanel();
            Label welcome = new Label();
            welcome.Text = "Benvenuto!";
            Label clickToContinue = new Label();
            clickToContinue.Text = "Clicca un'immagine per iniziare ad usare il ricettario..";
            clickToContinue.Size = new Size(400, 100);
            main.Controls.Add(welcome);
            main.Controls.Add(clickToContinue);
        }
        public Panel getPanel()
        {
            return main;
        }
    }
}
