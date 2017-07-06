using database_project.graphicsUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database_project.databaseGestor;
using System.IO;
using database_project.utilities;
using Microsoft.VisualBasic;

namespace database_project.paneVisualization.insertPane
{
    class IngredientInsert : Pane
    {
        private TableLayoutPanel main;
        private List<Tuple<int, String>> caratteristiche;
        private Dictionary<String, int> ingrUdm;
        private ComboBox categorie;
        private CheckedListBox checkCaratteristiche;
        private CheckedListBox unitàDiMisura;
        private TextBox box;
        private RicettarioGestorDataContext db = RicettarioDB.getInstance();

        public IngredientInsert()
        {
            caratteristiche = createCaratteristiche();
            ingrUdm = new Dictionary<String,int>();
            main = new TableLayoutPanel();
            Size basicSize = new Size(400, 20);
            //LABEL 
            Label textCategorie = labelFactory.createAdvanceLabel("Scegli la categoria..", labelFactory.getGeneralFont(),
                                                                        basicSize, Color.Black, ContentAlignment.TopLeft);
            Label textCaratteristiche = labelFactory.createAdvanceLabel("Scegli le specifiche..", labelFactory.getGeneralFont(),
                                                                        basicSize, Color.Black, ContentAlignment.TopLeft);

            Label textUnitàDiMisura = labelFactory.createAdvanceLabel("Scegli le unità di misura..", labelFactory.getGeneralFont(),
                                                                      basicSize, Color.Black, ContentAlignment.TopLeft);

            Label textIngrNome = labelFactory.createAdvanceLabel("Scegli il nome dell'ingrediente", labelFactory.getGeneralFont(),
                                                                      basicSize, Color.Black, ContentAlignment.TopLeft);

           
            //COMBO
            categorie = createCombo();
            //CHECKLIST
            checkCaratteristiche = createChecked(from c in caratteristiche
                                                           select new String(c.Item2.ToCharArray()));
            unitàDiMisura = createChecked(from c in db.UnitàDiMisura
                                                         select new String (c.Nome.ToCharArray() ));
            unitàDiMisura.ItemCheck += new ItemCheckEventHandler(checkValues);
            
            //TEXT BOX
            box = new TextBox();

            //aggiungi

            Button insert = new Button();
            insert.Text = "Aggiungi..";
            insert.Click += new System.EventHandler(this.queryInsert);
            //AGGIUNTA CONTROLLI
            main.Controls.Add(textCategorie);
            main.Controls.Add(categorie);
            main.Controls.Add(textCaratteristiche);
            main.Controls.Add(checkCaratteristiche);
            main.Controls.Add(textUnitàDiMisura);
            main.Controls.Add(unitàDiMisura);
            main.Controls.Add(textIngrNome);
            main.Controls.Add(box);
           
            main.Controls.Add(insert);

        }

        private void checkValues(object sender, ItemCheckEventArgs e)
        {
            if(e.CurrentValue == CheckState.Unchecked)
            {
                Form input = new Form();
                Size basicSize = new Size(input.Size.Width, 100);
                input.Size = basicSize;
                FlowLayoutPanel pane = new FlowLayoutPanel();
                TextBox box = new TextBox();
                Button click = new Button();
                click.Text = "Aggiungi..";
                click.Click += (o, a) => input.Close();
                box.Size = new Size(100, 20);
                pane.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
                pane.Controls.Add(box);
                pane.Controls.Add(click);
                input.StartPosition = FormStartPosition.CenterParent;
                input.MaximumSize = basicSize;
                input.MinimumSize = basicSize;
                input.Text = "Inserisci le calorie";
                input.Icon = Properties.Resources.iconmain;
                input.Controls.Add(pane);
                int kcal;
                do
                {
                 
                    input.ShowDialog();
                    if (box.Text.Length == 0) AllertGestor.defaultError("Devi almeno una unità di misura");
                    else if (!Int32.TryParse(box.Text, out kcal)) AllertGestor.defaultError("Deve essere numerica!");
                    else this.ingrUdm.Add(this.unitàDiMisura.Items[e.Index].ToString(),kcal);
                    
                } while (box.Text.Length == 0 || !Int32.TryParse(box.Text, out kcal));
            } else
            {
                this.ingrUdm.Remove(this.unitàDiMisura.Items[e.Index].ToString());
            }
        }

        public Panel getPanel()
        {
            return this.main;
        }
        public List<Tuple<int,String>> createCaratteristiche()
        {
            var sql = from c in db.Caratteristica
                      select c;
            List<Tuple<int, String>> res = new List<Tuple<int, String>>();
            foreach(var tupla in sql)
            {
                res.Add(new Tuple<int, string>(tupla.idCaratteristica, tupla.Nome));
            }
            return res;
        }
        private ComboBox createCombo()
        {
            var sql = from c in db.Categoria
                      select c;
            
            ComboBox combo = new ComboBox();
            foreach(var nome in sql)
            {
                combo.Items.Add(nome.Nome);
            }
            return combo;
        }

        private CheckedListBox createChecked(IEnumerable<String> values)
        {
            
            CheckedListBox list = new CheckedListBox();
            foreach(var nome in values)
            {
                list.Items.Add(nome);
            }
            return list;
        }

        private void queryInsert(object sender, EventArgs e)
        {
            if (this.box.Text.Length == 0) AllertGestor.defaultError("Devi scegliere un nome");
            if (this.categorie.SelectedItem == null) AllertGestor.defaultError("Devi scegliere una categoria");
            if (this.checkCaratteristiche.SelectedItems.Count == 0) AllertGestor.defaultError("Devi almeno una caratteristica");
            if (this.unitàDiMisura.SelectedItems.Count == 0) AllertGestor.defaultError("Devi almeno una unità di misura");
            Ingrediente ing = new Ingrediente();
            int max = (from c in db.Ingrediente
                       select c.idIngrediente).Max<int>() + 1;
            ing.Nome = box.Text;
            ing.NomeCat = categorie.SelectedItem.ToString();
            db.Ingrediente.InsertOnSubmit(ing);
            foreach (int i in this.checkCaratteristiche.CheckedIndices)
            {
                Tuple<int, String> value = this.caratteristiche[i];
                Console.WriteLine(i);
                Caratterizzante cat = new Caratterizzante();
                cat.idCaratteristica = value.Item1;
                cat.idIngrediente = max;
                db.Caratterizzante.InsertOnSubmit(cat);
            }

            this.ingrUdm.ToList().ForEach(x =>
            {
                IngrUDM ingUdm = new IngrUDM();
                ingUdm.kcalPerUnità = x.Value;
                ingUdm.NomeUDM = x.Key;
                ingUdm.idIngrediente = max;
                db.IngrUDM.InsertOnSubmit(ingUdm);
            });
            if (this.checkOk() == false) return;
        }
        private bool checkOk()
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception exc)
            {
                AllertGestor.defaultError("Errore nel database contattare il tecnico..");
                return false;
            }
        }
    }
}
