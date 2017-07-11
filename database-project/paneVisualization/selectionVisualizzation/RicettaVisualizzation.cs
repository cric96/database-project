using database_project.databaseGestor;
using database_project.formGestor;
using database_project.graphicsUtility;
using database_project.ricettaUtilities;
using database_project.utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization.selectionVisualizzation
{
    public partial class RicettaVisualizzation : Form
    {
        private int idRicetta;
        private int indexStep = 0;
        private List<Step> stepToShow = new List<Step>();
        private List<int> idRicette = new List<int>();
        private List<int> strumenti = new List<int>();
        private RicettarioGestorDataContext db = RicettarioDB.getInstance();
        public RicettaVisualizzation(int idRicetta)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.iconmain;
            //modifica stile schermata : pulsanti
            this.idRicetta = idRicetta;
            this.forward.BackColor = Color.Transparent;
            this.back.BackColor = Color.Transparent;
            this.forward.FlatStyle = FlatStyle.Flat;
            this.back.FlatStyle = FlatStyle.Flat;
            this.StartPosition = FormStartPosition.CenterParent;
            //descrizione
            //prendo la ricetta selezionata
            Ricetta ricetta = new Ricetta();
            ricetta = (from r in db.Ricetta where r.idRicetta == idRicetta select r).First();
            this.desc.Text = ricetta.Descrizione;
            this.desc.ReadOnly = true;
            this.descrizione.ReadOnly = true;
            this.back.Enabled = false;
            this.forward.Enabled = false;
            this.ricettaNome.Text = ricetta.Nome;
            this.immagine.SizeMode = PictureBoxSizeMode.StretchImage;
            List<RicettaStrumento> rsRicetta = ricetta.RicettaStrumento.ToList();
            int count = 0;
            //Creazione tabella ricetta strumento
            rsData.AutoGenerateColumns = false;
            rsData.RowHeadersVisible = false;
            rsData.MultiSelect = false;
            rsData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            rsData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            rsData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            rsRicetta.ForEach(x =>
            {
                String ricettaStrumento = "Strumenti utilizzati:\n";
                x.Utilizzo.ToList().ForEach(z => ricettaStrumento = ricettaStrumento + z.Strumento.Nome + "\n");
                ricettaStrumento = ricettaStrumento + "Kcal = " + x.Kcal;
                ricettaStrumento = ricettaStrumento + "\nCaratteristiche: \n";
                x.Definito.ToList().ToList().ForEach(z => ricettaStrumento = ricettaStrumento + z.Caratteristica.Nome + " ,");
                ListViewItem item = new ListViewItem(ricettaStrumento);
                this.rsData.Rows.Add();
                this.rsData.Rows[count ++].Cells[0].Value = ricettaStrumento;
                
            });
            this.ingrTot.View = View.List;
            this.rsData.RowStateChanged += (obj,args) =>
            {
                this.ingrTot.Items.Clear();
                if(args.StateChanged == DataGridViewElementStates.Selected && args.Row.Index != count )
                {
                    rsRicetta[args.Row.Index].Presenta.ToList().ForEach(x =>  {
                        String ingr = (from ing in db.Ingrediente where ing.idIngrediente == x.idIngrediente select ing.Nome).First();
                        ingr += " " + x.NomeUDM;
                        ingr += " " + x.Quantità;
                        this.ingrTot.Items.Add(ingr);
                    });
                    stepToShow = rsRicetta[args.Row.Index].Step.ToList();
                    this.stepToShow.Sort((x,y) => x.NumOrdine - y.NumOrdine);
                    this.indexStep = 0;
                    this.refreshStep();
                }
            };

            this.strumStep.SelectedIndexChanged += (obj, arg) =>
            {
                if (this.strumStep.SelectedItem != null)
                {
                    new StrumentoVisualizzation(this.strumenti[this.strumStep.SelectedIndex]).ShowDialog();
                }
            };

            ToolTip tip = TooltipFactory.createBasicTooltip("Alternative:");
            this.ingrStep.SelectedIndexChanged += (obj, arg) =>
            {
                if (this.ingrStep.SelectedItem != null)
                {
                    string alternative = "";
                    (from alt in db.Alternativo
                     where alt.idIngrediente == idRicette[this.ingrStep.SelectedIndex]
                     select alt.Ingrediente1).ToList().ForEach(z => alternative += z.Nome + ",");
                    Point p = ingrStep.FindForm().PointToClient(
                    ingrStep.Parent.PointToScreen(ingrStep.Location));

                    tip.Show(alternative, this, new Point(p.X, p.Y));

                }
            };
            this.forward.Click += (obj, args) => { this.indexStep++; this.refreshStep(); };
            this.back.Click += (obj, args) => { this.indexStep--; this.refreshStep(); };
        }
        private void refreshStep()
        {
            this.idRicette.Clear();
            this.strumenti.Clear();
            
            if (this.indexStep == 0)
                this.back.Enabled = false;
            else
                this.back.Enabled = true;
            
            if (this.indexStep == (from s in this.stepToShow select s.NumOrdine).Max())
                this.forward.Enabled = false;
            else
                this.forward.Enabled = true;
            this.descrizione.Text = this.stepToShow[this.indexStep].Descrizione;

            if(this.immagine.Image != null) this.immagine.Image.Dispose();
            Image img = new Bitmap(this.stepToShow[this.indexStep].Immagine);
            this.immagine.Image = img;
            this.strumStep.Items.Clear();
            this.ingrStep.Items.Clear();
            this.Nome.Text = this.stepToShow[this.indexStep].Nome;
            this.stepToShow[this.indexStep].Uso.ToList().ForEach(x =>
            {
                this.strumStep.Items.Add(x.Strumento.Nome);
                this.strumenti.Add(x.idStrumento);
            });
            this.stepToShow[this.indexStep].Consumo.ToList().ForEach(x =>
            {
                this.ingrStep.Items.Add(x.IngrUDM.Ingrediente.Nome + " " + x.IngrUDM.NomeUDM + " " + x.Quantità);
                this.idRicette.Add(x.IngrUDM.idIngrediente);
            });
            
        }

       
    }
}
