using database_project.graphicsUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database_project.databaseGestor;


namespace database_project.paneVisualization.insertPane
{
    class IngredientInsert : Pane
    {
        private TableLayoutPanel main;
        private RicettarioGestorDataContext db = new RicettarioGestorDataContext();
        public IngredientInsert()
        {
            List<Tuple<int, String>> caratteristiche = createCaratteristiche();
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
            ComboBox categorie = createCombo();
            //CHECKLIST
            CheckedListBox checkCaratteristiche = createChecked(from c in caratteristiche
                                                           select new String(c.Item2.ToCharArray()));
            CheckedListBox unitàDiMisura = createChecked(from c in db.UnitàDiMisura
                                                         select new String (c.Nome.ToCharArray() ));
            //TEXT BOX
            TextBox box = new TextBox();

            //Folder Dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //AGGIUNTA CONTROLLI
            main.Controls.Add(textCategorie);
            main.Controls.Add(categorie);
            main.Controls.Add(textCaratteristiche);
            main.Controls.Add(checkCaratteristiche);
            main.Controls.Add(textUnitàDiMisura);
            main.Controls.Add(unitàDiMisura);
            main.Controls.Add(textIngrNome);
            main.Controls.Add(box);


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
    }
}
