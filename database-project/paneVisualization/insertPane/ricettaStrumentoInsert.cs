using database_project.databaseGestor;
using database_project.utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace database_project.paneVisualization.insertPane
{
    public partial class ricettaStrumentoInsert : Form
    {
        //External table
        private HashSet<Step> steps;
        private HashSet<RicettaStrumento> ricettaStrumentoSet;
        //Internal table
        private HashSet<Step> currentStep;
        //other value to create te correct tuple
        private Dictionary<Tuple<String, int>, int> ingredientiSelezionati;
        private Dictionary<int, Tuple<String,int>> stepIngredientiSelezionati;
        private int idRicettaStrumento;
        private RicettarioGestorDataContext db = RicettarioDB.getInstance();
        private int countStep = 0;
        public ricettaStrumentoInsert(int idRicettaStrumento)
        {
            
            InitializeComponent();
            //Initializzation
            this.currentStep = new HashSet<Step>();
            this.ingredientiSelezionati = new Dictionary<Tuple<String, int>, int>();
            this.stepIngredientiSelezionati = new Dictionary<int, Tuple<String, int>>();
            this.idRicettaStrumento = idRicettaStrumento;
            this.ingredientVisualizzator.HorizontalScrollbar = true;
            
            //Strumenti
            List<Strumento> strumenti = (from c in db.Strumento select c).ToList();
            List<Strumento> elettrodomestici = (from c in strumenti
                                                where c.Tipo.Equals("Elettrodomestico")
                                                select c).ToList();
            elettrodomestici.ForEach(x => this.RSStrumentiSelector.Items.Add(x.Nome));
            strumenti.ForEach(x => this.strumentiStep.Items.Add(x.Nome + " " + x.Tipo));

            List<Ingrediente> ingredienti = (from c in db.Ingrediente select c).ToList();
            ingredienti.ForEach(x => this.ingredientiSelector.Items.Add(x.Nome));
            this.nomeStep.MaxLength = (int)textConst.NOME_STEP;

            //gestione list
            this.stepListing.HorizontalScrollbar = true;
            //Action
            this.ingredientiSelector.ItemCheck += (obj, args) =>
            {
                int keyIndex = ingredienti[args.Index].idIngrediente;
                if (args.CurrentValue == CheckState.Unchecked)
                {
                    Tuple<String, int> res = new selIngrediente(keyIndex).getQuantity();
                    Tuple<String, int> key = new Tuple<string, int>(res.Item1, keyIndex);
                    this.stepIngredientiSelezionati.Add(keyIndex, res);
                    if (this.ingredientiSelezionati.ContainsKey(key))
                    {
                        int qnt = this.ingredientiSelezionati[key];
                        qnt += res.Item2;
                        this.ingredientiSelezionati.Remove(key);
                        this.ingredientiSelezionati.Add(key, qnt);
                    } else
                    {
                        this.ingredientiSelezionati.Add(key, res.Item2);
                    }
                    this.ingredientVisualizzator.Items.Clear();
                    this.refreshIngredient();
                } else
                {

                    Tuple<String, int> qnt = this.stepIngredientiSelezionati[keyIndex];
                    this.stepIngredientiSelezionati.Remove(keyIndex);
                    Tuple<String, int> key = new Tuple<String, int>(qnt.Item1, keyIndex);
                    int qntTot = this.ingredientiSelezionati[key];
                    if (qnt.Item2 == qntTot)
                    {
                        this.ingredientiSelezionati.Remove(key);
                    } else
                    {
                        qntTot -= qnt.Item2;
                        this.ingredientiSelezionati.Remove(key);
                        this.ingredientiSelezionati.Add(key, qntTot);
                    }
                    this.ingredientVisualizzator.Items.Clear();
                    this.refreshIngredient();
                }
            };
            //Aggiungi step
            this.AggiungiStep.Click += (obj, args) =>
            {
                //Controllo dei parametri esatti
                if (this.nomeStep.TextLength == 0) AllertGestor.defaultError("Devi inserire un nome univoco per ogni step");
                else if (this.descrizione.TextLength == 0) AllertGestor.defaultError("Devi inserire una descrizione");
                else if (this.Immagine.Text.Equals("")) AllertGestor.defaultError("Devi inserire un'immagine");
                else
                {
                    //Inserisco nello step le caratteristiche principali
                    Step main = new Step();
                    main.idRicettaStrum = this.idRicettaStrumento;
                    main.Nome = this.nomeStep.Text;
                    main.Immagine = this.Immagine.Text;
                    main.NumOrdine = countStep;
                    main.Descrizione = this.descrizione.Text;
                    this.currentStep.Add(main);
                    //Consumo table
                    this.stepIngredientiSelezionati.ToList().ForEach(x =>
                    {
                        Consumo cons = new Consumo();

                        cons.idIngrediente = x.Key;
                        cons.idRicettaStrum = this.idRicettaStrumento;
                        cons.NomeStep = this.nomeStep.Text;
                        cons.Quantità = x.Value.Item2;
                        cons.NomeUDM = x.Value.Item1;
                        main.Consumo.Add(cons);
                    });

                    //Uso table
                    foreach (int i in this.strumentiStep.CheckedIndices)
                    {
                        Uso uso = new Uso();
                        uso.idRicettaStrum = this.idRicettaStrumento;
                        uso.NomeStep = this.nomeStep.Text;
                        uso.idStrumento = strumenti[i].idStrumento;
                        main.Uso.Add(uso);
                    }
                    //Pulisco la pagina corrente
                    this.strumentiStep.Items.Clear();
                    strumenti.ForEach(x => this.strumentiStep.Items.Add(x.Nome + " " + x.Tipo));
                    this.ingredientiSelector.Items.Clear();
                    ingredienti.ForEach(x => this.ingredientiSelector.Items.Add(x.Nome));
                    this.nomeStep.Clear();
                    this.descrizione.Clear();
                    this.Immagine.Text = "";
                    this.stepIngredientiSelezionati.Clear();
                    this.countStep++;
                    this.stepListing.Items.Add(main.Nome + " " + main.NumOrdine);
                    //aggiungo lo step ai step da aggiungere 
                    this.steps.Add(main);
                }
            };
            //Azione per aggiungere un'immagine
            this.immageOpen.Click += (obj, args) => {
                try
                {
                    this.Immagine.Text = UtilityImage.findFileCheckImage();
                }catch(ArgumentException exc)
                {
                    this.Immagine.Text = "";
                    AllertGestor.defaultError("Devi selezionare un'immagine valida!");
                }
            };
            //Azione per aggiungere la ricetta strumento
            this.addRS.Click += (obj, args) =>
            {
                if (this.currentStep.Count == 0) AllertGestor.defaultError("Devi inserire almeno uno step ");
                else
                {
                    RicettaStrumento rs = new RicettaStrumento();
                    rs.idRicettaStrum = this.idRicettaStrumento;
                    try
                    {
                        rs.Kcal = (int)Double.Parse(this.kcalTot.Text);
                    } catch (Exception e)
                    {
                        rs.Kcal = 0;
                    }
                    

                    bool begin = true;
                    foreach (int i in this.RSStrumentiSelector.CheckedIndices)
                    {
                        Utilizzo utilizzo = new Utilizzo();
                        utilizzo.idRicettaStrum = this.idRicettaStrumento;
                        utilizzo.idStrumento = elettrodomestici[i].idStrumento;
                        rs.Utilizzo.Add(utilizzo);
                    }
                    HashSet<int> specifiche = new HashSet<int>();
                    this.ingredientiSelezionati.ToList().ForEach(x =>
                    {
                        Presenta presenta = new Presenta();
                        presenta.idIngrediente = x.Key.Item2;
                        presenta.idRicettaStrum = this.idRicettaStrumento;
                        presenta.NomeUDM = x.Key.Item1;
                        presenta.Quantità = x.Value;
                        rs.Presenta.Add(presenta);
                        if (begin)
                        {
                            specifiche = this.populateCatatteristiche(x.Key.Item2);
                            begin = false;
                        }
                        else
                        {
                            HashSet<int> otherSpecifiche = this.populateCatatteristiche(x.Key.Item2);
                            specifiche.ToList().ForEach(z =>
                            {
                                if (!otherSpecifiche.Contains(z))
                                {
                                    specifiche.Remove(z);
                                }
                            });
                        }

                    });
                    specifiche.ToList().ForEach(x => Console.WriteLine(x));
                    specifiche.ToList().ForEach(x =>
                    {
                        Definito def = new Definito();
                        def.idCaratteristica = x;
                        def.idRicettaStrum = this.idRicettaStrumento;
                        rs.Definito.Add(def);
                    });
                    this.ricettaStrumentoSet.Add(rs);
                    this.Close();
                }
                
            };
            
        }
        private HashSet<int> populateCatatteristiche( int key)
        {
            HashSet<int> specifiche = new HashSet<int>();
            (from c in db.Caratterizzante
             where c.idIngrediente == key
             select c.idCaratteristica).ToList().ForEach(y => {
                 specifiche.Add(y);
             });
            return specifiche;
        }
        public void setSteps(HashSet<Step> steps)
        {
            this.steps = steps;
        }

        public void setRicettaStrumento(HashSet<RicettaStrumento> ricettaTables)
        {
            this.ricettaStrumentoSet = ricettaTables;
        }
        private void refreshIngredient()
        {
            this.ingredientiSelezionati.ToList().ForEach(x => this.ingredientVisualizzator.Items.Add((from c in db.Ingrediente
                                                                                                     where c.idIngrediente == x.Key.Item2
                                                                                                     select c.Nome).First() +" " + x.Value + " " + x.Key.Item1));
            float kcalTot = 0;
            this.ingredientiSelezionati.ToList().ForEach(x =>
            {
                kcalTot += x.Value * (from c in db.IngrUDM
                                      where c.idIngrediente == x.Key.Item2
                                      && c.NomeUDM.Equals(x.Key.Item1)
                                      select c.kcalPerUnità).First();
            });
            this.kcalTot.Text = kcalTot + "";
        }

    }
}
