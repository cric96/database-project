using database_project.databaseGestor;
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

namespace database_project.paneVisualization.insertPane
{
    class RicettaInsert : Pane
    {
        private TableLayoutPanel mainPanel;
        private RicettarioGestorDataContext db = RicettarioDB.getInstance();
        public RicettaInsert()
        {
            mainPanel = new TableLayoutPanel();
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

            Label textImage = labelFactory.createAdvanceLabel("...", labelFactory.getGeneralFont(),
                                                                        size, Color.Black, ContentAlignment.TopLeft);

            //TextBox
            TextBox ricettaText = new TextBox();
            ricettaText.Size = size;

            TextBox cotturaText = new TextBox();
            cotturaText.Size = size;
            cotturaText.MaxLength = 3;

            TextBox preparazioneText = new TextBox();
            preparazioneText.Size = size;
            cotturaText.MaxLength = 3;

            TextBox personeText = new TextBox();
            personeText.Size = new Size(20,20);
            personeText.MaxLength = 2;


            //ComboBox
            ComboBox difficoltàBox = new ComboBox();
            DifficoltàUtilities.getDifficulties().ForEach(x => difficoltàBox.Items.Add(DifficoltàUtilities.getDifficulty(x)));

            ComboBox portataBox = new ComboBox();
            portataBox.Items.AddRange((from c in db.Portata
             select c.Nome).ToArray());

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
                    AllertGestor.defaultError("Devi selezionare un'immagine valida");
                }
            };
            
            //Nome Ricetta
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
        }
        public Panel getPanel()
        {
            return this.mainPanel;
        }

        
    }
}
