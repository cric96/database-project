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
using database_project.formGestor;


namespace database_project.paneVisualization.insertPane
{

    public class MenuInsert : Pane
    {
        private TableLayoutPanel pane = new TableLayoutPanel();
        private RicettarioGestorDataContext db = RicettarioDB.getInstance();
        public MenuInsert()
        {
            pane.AutoScroll = true;
            Size basicSize = new Size(400, 20);
            List<Ricetta> listRicette = (from c in db.Ricetta select c).ToList();
            //Label
            Label textNome = labelFactory.createAdvanceLabel("Scegli il nome del menu..", labelFactory.getGeneralFont(),
                                                                        basicSize, Color.Black, ContentAlignment.TopLeft);

            Label textTipo = labelFactory.createAdvanceLabel("Scegli il tipo del menu..", labelFactory.getGeneralFont(),
                                                                        basicSize, Color.Black, ContentAlignment.TopLeft);

            Label textRicette = labelFactory.createAdvanceLabel("Scegli ricette.", labelFactory.getGeneralFont(),
                                                                        basicSize, Color.Black, ContentAlignment.TopLeft);

            //TextBox

            TextBox nomeText = new TextBox();
            nomeText.Size = basicSize;
            nomeText.MaxLength = (int)textConst.NOME_MENU;

            TextBox tipoText = new TextBox();
            tipoText.Size = basicSize;
            tipoText.MaxLength = (int)textConst.NOME_TIPO;

            //List view
            CheckedListBox ricette = new CheckedListBox();
            ricette.Size = new Size(400, 150);

            //Button
            Button aggiunge = new Button();
            aggiunge.Text = "Inserisci il menu";
            aggiunge.Size = basicSize;

            listRicette.ForEach(x => ricette.Items.Add(x.Nome));
            //nome
            this.pane.Controls.Add(textNome);
            this.pane.Controls.Add(nomeText);
            //tipo
            this.pane.Controls.Add(textTipo);
            this.pane.Controls.Add(tipoText);
            //ricette
            this.pane.Controls.Add(textRicette);
            this.pane.Controls.Add(ricette);
            //Inserimento
            this.pane.Controls.Add(aggiunge);

            //action
            aggiunge.Click += (obj, args) =>
            {
                if (nomeText.Text.Length == 0) AllertGestor.defaultError("Devi scegliere un nome");
                else if (tipoText.Text.Length == 0) AllertGestor.defaultError("Devi scegliere un tipo");
                else if (ricette.SelectedItems.Count == 0) AllertGestor.defaultError("Devi almeno una ricetta");
                else
                {
                    Menù menu = new Menù();
                    menu.Nome = nomeText.Text;
                    menu.Tipo = tipoText.Text;
                    db.Menù.InsertOnSubmit(menu);
                    db.SubmitChanges();
                    foreach(int i in ricette.CheckedIndices)
                    {
                        Assemblaggio assemblaggio = new Assemblaggio();
                        assemblaggio.idMenù = menu.idMenù;
                        assemblaggio.idRicetta = listRicette[i].idRicetta;
                        db.Assemblaggio.InsertOnSubmit(assemblaggio);
                    }
                    db.SubmitChanges();
                    AllertGestor.defaultShowOk("Menu inserito correttamente");
                    MainPaneGestor.getInstance().setPanel(PaneFactory.getMenuPane());
                    MainPaneGestor.getInstance().enableShowingSearch();
                    RicettarioDB.refresh();
                }
            };
        }
        public Panel getPanel()
        {
            return this.pane;
        }
        public void deleteAllControl()
        {
            foreach (Control c in this.pane.Controls) c.Dispose();
            this.pane.Controls.Clear();
        }
    }

}