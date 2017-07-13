using database_project.databaseGestor;
using database_project.formGestor;
using database_project.graphicsUtility;
using database_project.ricettaUtilities;
using database_project.utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization.insertPane
{
    class RicettaInsert : Pane
    {
        private TableLayoutPanel mainPanel;
        private int ricettaStrumentoIndex = 0;
        

        private RicettarioGestorDataContext db = RicettarioDB.getInstance();
        public RicettaInsert()
        {
            HashSet<RicettaStrumento> rsToInsert = new HashSet<RicettaStrumento>();
            HashSet<Step> stepToInsert = new HashSet<Step>();
            
            mainPanel = new TableLayoutPanel();
            this.mainPanel.AutoScroll = true;
            Size size = new Size(300,20);
            //Label
            Label textRicetta = labelFactory.createAdvanceLabel("Inserisci il nome della ricetta", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);
            Label textTCottura = labelFactory.createAdvanceLabel("Inserisci il tempo di cottura in minuti", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);
            Label textTPreparazione = labelFactory.createAdvanceLabel("Inserisci il tempo di preparazione in minuti", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);
            Label textDifficolta = labelFactory.createAdvanceLabel("Inserisci la difficoltà", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);

            Label textPersone = labelFactory.createAdvanceLabel("Inserisci il numero di persone", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);

            Label textPortata = labelFactory.createAdvanceLabel("Seleziona la portata desiderata", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);

            Label textImage = labelFactory.createAdvanceLabel("", labelFactory.getGeneralFont(),
                                                                        new Size(400,20), Color.Black, ContentAlignment.TopLeft);

            Label textDescrizione = labelFactory.createAdvanceLabel("Inserisci la descrizione", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);

            //TextBox
            TextBox ricettaText = new TextBox();
            ricettaText.Size = size;
            ricettaText.MaxLength = (int)textConst.NOME_RICETTA;

            TextBox cotturaText = new TextBox();
            cotturaText.Size = size;
            cotturaText.MaxLength = 3;

            TextBox preparazioneText = new TextBox();
            preparazioneText.Size = size;
            preparazioneText.MaxLength = 3;

            TextBox personeText = new TextBox();
            personeText.Size = new Size(20,20);
            personeText.MaxLength = 2;

            //RichTextBox

            RichTextBox descrizione = new RichTextBox();
            descrizione.Size = new Size(400, 100);

            //ComboBox
            ComboBox difficoltàBox = new ComboBox();
            DifficoltàUtilities.getDifficulties().ForEach(x => difficoltàBox.Items.Add(DifficoltàUtilities.getDifficulty(x)));

            ComboBox portataBox = new ComboBox();
            portataBox.Items.AddRange((from c in db.Portata
             select c.Nome).ToArray());

            //ListView
            ListView listRs = new ListView();
            listRs.View = View.List;
            //Button
            Button insertImage = new Button();
            insertImage.Text = "Scegli un'immagine per la tua ricetta..";
            insertImage.Size = size;
            insertImage.Click += (obj, arg) =>
            {
                try
                {
                    textImage.Text = UtilityImage.findFileCheckImage();
                }
                catch (ArgumentException exc)
                {
                    textImage.Text = "";
                    AllertGestor.defaultError("Devi selezionare un'immagine valida");
                }
            };

            Button addRicetta = new Button();
            addRicetta.Text = "Aggiungi la ricetta..";
            addRicetta.Size = new Size(200, 25);
            addRicetta.Enabled = false;
            //Cosa fare quando la ricetta deve essere inserita
            addRicetta.Click += (obj, args) =>
            {
                int tcottura, tpreparazione,persone;
                if (ricettaText.TextLength == 0) AllertGestor.defaultError("Devi inserire un nome!");
                else if (cotturaText.TextLength == 0) AllertGestor.defaultError("Devi inserire il tempo di cottura");
                else if (!Int32.TryParse(cotturaText.Text, out tcottura)) AllertGestor.defaultError("il tempo di cottura deve essere numerico");
                else if (preparazioneText.TextLength == 0) AllertGestor.defaultError("Devi inserire il tempo di preparazione");
                else if (!Int32.TryParse(preparazioneText.Text, out tpreparazione)) AllertGestor.defaultError("il tempo di preparazione deve essere numerico");
                else if (textImage.Text.Equals("")) AllertGestor.defaultError("Devi inserire un'immagine");
                else if (descrizione.TextLength == 0) AllertGestor.defaultError("Devi inserire una descrizione!");
                else if (difficoltàBox.SelectedItem == null) AllertGestor.defaultError("Devi inserire una difficoltà!");
                else if (portataBox.SelectedItem == null) AllertGestor.defaultError("Devi inserire una portata!");
                else if(personeText.TextLength == 0) AllertGestor.defaultError("Devi inserire il numero di persone corretto!");
                else if (!Int32.TryParse(personeText.Text, out persone)) AllertGestor.defaultError("le persone devono avere un'indice numerico!");
                else
                {
                    Ricetta ricetta = new Ricetta();
                    ricetta.Nome = ricettaText.Text;
                    ricetta.TCottura = tcottura;
                    ricetta.Persone = persone;
                    ricetta.TPreparazione = tpreparazione;
                    ricetta.Difficoltà = difficoltàBox.SelectedIndex;
                    ricetta.portata = portataBox.SelectedItem.ToString();

                    string localFile = FileGestor.copyFileToLocalFolder(textImage.Text, ricetta.Nome);
                    ricetta.Immagine = localFile;
                    ricetta.Descrizione = descrizione.Text;
                    db.Ricetta.InsertOnSubmit(ricetta);
                    bool insert = true;
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception exc)
                    {
                        insert = false;
                        RicettarioDB.refresh();
                        this.db = RicettarioDB.getInstance();
                        AllertGestor.defaultError("Il nome della ricetta è già stato inserito! controlla nel menù principale\n" + exc);
                    }
                    if (insert)
                    {
                        //Aggiustamento dei vari valori trovati
                        stepToInsert.ToList().ForEach(x => {
                            x.Immagine = FileGestor.copyFileToLocalFolder(x.Immagine, "" + ricetta.idRicetta + "" + x.idRicettaStrum + "" +x.Nome);
                        });
                        rsToInsert.ToList().ForEach(x =>
                        {
                            x.idRicetta = ricetta.idRicetta;
                            x.Presenta.ToList().ForEach(z =>
                            {
                                Presenta p = new Presenta();
                                p.idRicetta = ricetta.idRicetta;
                                p.idRicettaStrum = z.idRicettaStrum;
                                p.idIngrediente = z.idIngrediente;
                                p.Quantità = z.Quantità;
                                p.NomeUDM = z.NomeUDM;
                                x.Presenta.Remove(z);
                                x.Presenta.Add(p);
                            });
                            x.Definito.ToList().ForEach(z => {
                                Definito d = new Definito();
                                d.idRicetta = ricetta.idRicetta;
                                d.idRicettaStrum = z.idRicettaStrum;
                                d.idCaratteristica = z.idCaratteristica;
                                x.Definito.Remove(z);
                                x.Definito.Add(d);
                            });
                            x.Utilizzo.ToList().ForEach(z => {
                                Utilizzo u = new Utilizzo();
                                u.idRicetta = ricetta.idRicetta;
                                u.idRicettaStrum = z.idRicettaStrum;
                                u.idStrumento = z.idStrumento;
                                x.Utilizzo.Remove(z);
                                x.Utilizzo.Add(u);
                            });
                        });
                        stepToInsert.ToList().ForEach(x =>
                        {
                            x.idRicetta = ricetta.idRicetta;
                            x.Uso.ToList().ForEach(z =>
                            {
                                Uso u = new Uso();
                                u.idRicetta = ricetta.idRicetta;
                                u.idRicettaStrum = z.idRicettaStrum;
                                u.idStrumento = z.idStrumento;
                                u.NomeStep = z.NomeStep;
                                x.Uso.Remove(z);
                                x.Uso.Add(u);
                            });
                            x.Consumo.ToList().ForEach(z =>
                            {
                                Consumo p = new Consumo();
                                p.idRicetta = ricetta.idRicetta;
                                p.idRicettaStrum = z.idRicettaStrum;
                                p.idIngrediente = z.idIngrediente;
                                p.Quantità = z.Quantità;
                                p.NomeUDM = z.NomeUDM;
                                p.NomeStep = z.NomeStep;
                                x.Consumo.Remove(z);
                                x.Consumo.Add(p);
                            });
                        });
                        db.RicettaStrumento.InsertAllOnSubmit(rsToInsert.AsEnumerable());
                        db.Step.InsertAllOnSubmit(stepToInsert.AsEnumerable());
                        try
                        {
                            db.SubmitChanges();
                            AllertGestor.defaultShowOk("Ricetta Inserita!");
                        }
                        catch (Exception exc)
                        {
                            AllertGestor.defaultError("errore grave consultare il tecnico: \n traccia : " + exc.ToString());
                        }
                    }
                    RicettarioDB.refresh();
                    MainPaneGestor.getInstance().enableShowingSearch();
                    MainPaneGestor.getInstance().setPanel(PaneFactory.getRicettaPane());

                }
            };
            Button addSteps = new Button();
            addSteps.Text = "Inserisci gli step...";
            addSteps.Size = new Size(200, 25);
            //Cosa fare quando gli step devono essere inseriti
            addSteps.Click += (obj, args) =>
            {
                ricettaStrumentoInsert popup = new ricettaStrumentoInsert(ricettaStrumentoIndex);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.setRicettaStrumento(rsToInsert);
                popup.setSteps(stepToInsert);
                popup.ShowDialog();
                if(rsToInsert.Count != 0)
                {
                    addRicetta.Enabled = true;
                }
                listRs.Items.Clear();
                ricettaStrumentoIndex++;
                rsToInsert.ToList().ForEach(x => listRs.Items.Add("Famiglia Step id :" + x.idRicettaStrum));
            };
            //Name Ricetta
            mainPanel.Controls.Add(textRicetta);
            mainPanel.Controls.Add(ricettaText);
            //Tempo Cottura
            mainPanel.Controls.Add(textTCottura);
            mainPanel.Controls.Add(cotturaText);
            //Tempo Preparazione
            mainPanel.Controls.Add(textTPreparazione);
            mainPanel.Controls.Add(preparazioneText);
            //Difficoltà
            mainPanel.Controls.Add(textDifficolta);
            mainPanel.Controls.Add(difficoltàBox);
            //Persone 
            mainPanel.Controls.Add(textPersone);
            mainPanel.Controls.Add(personeText);
            //portata
            mainPanel.Controls.Add(textPortata);
            mainPanel.Controls.Add(portataBox);
            //Immagine 
            mainPanel.Controls.Add(insertImage);
            mainPanel.Controls.Add(textImage);
            //Descrizione
            mainPanel.Controls.Add(textDescrizione);
            mainPanel.Controls.Add(descrizione);

            //Inserimento
            mainPanel.Controls.Add(addSteps);

            //ListView 
            mainPanel.Controls.Add(listRs);
            //Inserimento Ricetta
            mainPanel.Controls.Add(addRicetta);

        }
        public Panel getPanel()
        {
            return this.mainPanel;
        }
        public void deleteAllControl()
        {
            foreach (Control c in this.mainPanel.Controls) c.Dispose();
            this.mainPanel.Controls.Clear();
        }

    }
}
