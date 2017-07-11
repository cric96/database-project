using database_project.graphicsUtility;
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
            //Creazione dei label : Welcome
            Label welcome = labelFactory.createAdvanceLabel("Benvenuto!", new Font("Times new roman", 20),
                                                            new Size(400, 50), Color.Red,  ContentAlignment.TopCenter);
            
            //Clicca per continuare
            Label clickToContinue = labelFactory.createAdvanceLabel("Clicca un'immagine per iniziare ad usare il ricettario..",
                                                                     new Font("Colibrì", 10),
                                                                     new Size(400, 100),
                                                                     Color.Black,
                                                                     ContentAlignment.TopCenter);
           
            //Aggiunta al panello principale
            main.Controls.Add(welcome);
            main.Controls.Add(clickToContinue);
        }

        public void deleteAllControl()
        {
            
        }

        public Panel getPanel()
        {
            return main;
        }
    }
}
