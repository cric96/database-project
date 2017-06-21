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
            welcome.BackColor = System.Drawing.Color.Transparent;
            welcome.TextAlign = ContentAlignment.TopCenter;
            welcome.Text = "Benvenuto!";
            welcome.Font = new Font("Times new roman", 20);
            welcome.ForeColor = Color.Red;
            welcome.Size = new Size(400, 50);
            Label clickToContinue = new Label();
            clickToContinue.BackColor = System.Drawing.Color.Transparent;
            clickToContinue.Text = "Clicca un'immagine per iniziare ad usare il ricettario..";
            clickToContinue.Size = new Size(400, 100);
            clickToContinue.TextAlign = ContentAlignment.TopCenter;
            main.Controls.Add(welcome);
            main.Controls.Add(clickToContinue);
        }
        public Panel getPanel()
        {
            return main;
        }
    }
}
