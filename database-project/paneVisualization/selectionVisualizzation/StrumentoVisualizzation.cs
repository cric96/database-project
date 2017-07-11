using database_project.databaseGestor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization.selectionVisualizzation
{
    public partial class StrumentoVisualizzation : Form
    {

        public StrumentoVisualizzation(int idStrumento)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.iconmain;
            Strumento strumento = (from s in RicettarioDB.getInstance().Strumento
                                  where s.idStrumento == idStrumento
                                  select s).First();
            this.nome.Text = strumento.Nome;
            if(strumento.TipoElettrodom != null)
            {
                this.Elettrodomestico.Text = "Tipo = " + strumento.TipoElettrodom;
                this.potenza.Text = " potenza = " + strumento.Potenza + " Watt";
            } else
            {
                this.Elettrodomestico.Text = "";
                this.potenza.Text = "";
            }
            this.StartPosition = FormStartPosition.CenterParent;
            this.descrizione.ReadOnly = true;
            this.descrizione.Text = strumento.Descrizione;

            this.immagine.Image = (Image)Properties.Resources.ResourceManager.GetObject(strumento.Immagine);

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
