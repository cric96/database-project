using database_project.databaseGestor;
using database_project.graphicsUtility;
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
    public partial class MenuSelection : Form
    {
        private int idMenu;
        public MenuSelection(int idMenu)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.iconmain;
            this.idMenu = idMenu;
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.menu.TextAlign = ContentAlignment.MiddleCenter;
            this.StartPosition = FormStartPosition.CenterParent;
            Menù menu = (from m in RicettarioDB.getInstance().Menù
                        where m.idMenù == idMenu
                        select m).First();
            this.menu.Text = menu.Nome;
            this.tipo.Text = "Tipo :" + menu.Tipo;
            this.immageGestor.Dock = DockStyle.Top;
            ToolTip ricettaTip = TooltipFactory.createBasicTooltip("Ricette");

            menu.Assemblaggio.ToList().ForEach(x =>
            {

                PictureBox picture = new PictureBox();
                picture.Size = new Size(100, 100);
                picture.Image = new Bitmap(x.Ricetta.Immagine);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.immageGestor.Controls.Add(picture);
                ricettaTip.SetToolTip(picture, "Nome " + x.Ricetta.Nome +
                                          "\nPortata " + x.Ricetta.portata +
                                          "\nPersone = " + x.Ricetta.Persone);
                picture.Click += (obj, arg) => new RicettaVisualizzation(x.Ricetta.idRicetta).ShowDialog();
            });
        }
    }
}
