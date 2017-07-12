using database_project.databaseGestor;
using database_project.formGestor;
using database_project.graphicsUtility;
using database_project.paneVisualization.insertPane;
using database_project.paneVisualization.node;
using database_project.paneVisualization.selectionVisualizzation;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization
{
    class PaneFactory
    {
        public static Pane getMainPane()
        {
            return new MainPanel();
        }

        public static PaneQueryable getIngredientPane()
        {
            List<ImageNode> images = new List<ImageNode>();
            images.Add(new InsertNode((a,b) =>
            {
                MainPaneGestor.getInstance().setPanel(InsertPaneFactory.getInsertIngrediente());
                MainPaneGestor.getInstance().disableShowingSearch();
            }));
            return new SimplePaneImage(images, nodeFactory.createNodeFilter(),(x => { return new List<Control>(); }));
        }

        public static PaneQueryable getRicettaPane()
        {
            List<ImageNode> images = new List<ImageNode>();
            images.Add(new InsertNode((a, b) =>
            {
                MainPaneGestor.getInstance().setPanel(InsertPaneFactory.getInsertRicetta());
                MainPaneGestor.getInstance().disableShowingSearch();
            }));
            ToolTip ricettaTip = TooltipFactory.createBasicTooltip("Ricetta");
            (from c in RicettarioDB.getInstance().Ricetta
             select c).ToList().ForEach(x =>
             {
                 images.Add(getImageNode(x, new Bitmap(x.Immagine), ricettaTip));
             });
            searchElement action = x =>
            {

                List<Ricetta> list = (from c in RicettarioDB.getInstance().Ricetta
                                 where SqlMethods.Like(c.Nome, "%" + x + "%")
                                 select c).ToList();
                List<Control> result = new List<Control>();
               
                list.ForEach(z =>
                {
                    result.Add((getImageNode(z, new Bitmap(z.Immagine), ricettaTip)).getImage());
                });
                return result;
                
            };
            return new SimplePaneImage(images, nodeFactory.createNodeFilter(),action);
        }

        
        public static PaneQueryable getMenuPane()
        {
            bool isClicked = false;
            List<ImageNode> images = new List<ImageNode>();
            images.Add(new InsertNode((a, b) =>
            {
                isClicked = true;
                MainPaneGestor.getInstance().setPanel(InsertPaneFactory.getInsertMenu());
                MainPaneGestor.getInstance().disableShowingSearch();
            }));
            ListBox list = new ListBox();
            List<Menù> menus = (from c in RicettarioDB.getInstance().Menù
                                select c).ToList();
            menus.ForEach(x => list.Items.Add(x.Nome));
            list.Click += (obj, args) =>
            {
                if(list.SelectedItem != null)
                new MenuSelection(menus[list.SelectedIndex].idMenù).ShowDialog();
            }; 
            searchElement action = x =>
            {
                ListBox filterList = new ListBox();
                List<Control> result = new List<Control>();
                result.Add(filterList);
                List<Menù> filterMenus = (from c in RicettarioDB.getInstance().Menù
                                          where SqlMethods.Like(c.Nome, "%" + x + "%")
                                          select c).ToList();
                filterMenus.ForEach(z => filterList.Items.Add(z.Nome));
                filterList.SelectedIndexChanged += (obj, arg) => {
                    if (filterList.SelectedItem != null)
                        new MenuSelection(filterMenus[filterList.SelectedIndex].idMenù).ShowDialog();
                };
                return result;
            };
            return new SimplePaneControl(images, nodeFactory.createNodeFilter(),list, action );
        }
        private PaneFactory() { }
        internal class SimplePaneImage : BasicPanelVisualization
        {
            private List<Button> images;
            private searchElement action;
            public SimplePaneImage(List<ImageNode> images, FilterNode node, searchElement search) : base(images,node)
            {
                this.images = new List<Button>();
                images.ForEach(x => this.images.Add(x.getImage()));
                this.action = search;
            }

            public override void deleteAllControl()
            {
                this.images.ForEach(x => {
                   
                    x.BackgroundImage.Dispose();
                    
                });
            }

            public override void search(string value)
            {
                
                this.getImagePanel().Controls.Clear();
                this.deleteAllControl();
                this.images.Clear();
                this.action.Invoke(value).ForEach(x=> {
                    this.getImagePanel().Controls.Add(x);
                    this.images.Add((Button)x);
                });
                this.getMainPanel().Refresh();
            }
        }

        internal class SimplePaneControl : BasicPanelVisualization
        {
            private FlowLayoutPanel controlsPane;
            private ListBox menu;
            private searchElement action;
            private Label textMenu;
            private List<ImageNode> images;
            public SimplePaneControl(List<ImageNode> images, FilterNode filter, ListBox menu, searchElement action) : base(images, filter)
            {
                this.images = images;
                menu.Size = new Size(250, 200);
                this.menu = menu;
                TableLayoutPanel main = this.getMainPanel();
                controlsPane = new FlowLayoutPanel();
                textMenu = labelFactory.createAdvanceLabel("Scegli un menu da visualizzare", labelFactory.getGeneralFont(),
                                                                            new Size(300,20), Color.Black, ContentAlignment.TopLeft);

                controlsPane.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
                controlsPane.Controls.Add(textMenu);
                controlsPane.Controls.Add(menu);
                main.Controls.Add(controlsPane, 1, 1);
                this.action = action;
            }

            public override void deleteAllControl()
            {
                this.images.ForEach(x => {

                    x.getImage().Dispose();

                });
                this.images.Clear();
                this.menu.Dispose();
                this.controlsPane.Controls.Clear();
                foreach (Control c in this.controlsPane.Controls) c.Dispose();
                
            }
            
            public override void search(string value)
            {
                //this.menu.Items.Clear();
                this.deleteAllControl();
                ListBox newList = (ListBox)this.action.Invoke(value).First();
                newList.Size = this.menu.Size;
                this.menu = newList;
                this.controlsPane.Controls.Add(textMenu);
                this.controlsPane.Controls.Add(this.menu);
            }

        }
        private static ImageNode getImageNode(Ricetta r, Image g, ToolTip t)
        {
            ImageNode node = nodeFactory.createImageNode(((a, b) => new RicettaVisualizzation(r.idRicetta).ShowDialog()), g);
            RicettarioGestorDataContext db = RicettarioDB.getInstance();
            String caratteristiche = "";
            (from rs in db.RicettaStrumento
             join def in db.Definito on rs.idRicettaStrum equals def.idRicettaStrum
             where rs.idRicetta == r.idRicetta && def.idRicetta == r.idRicetta
             select def.Caratteristica).Distinct().ToList().ForEach(x => caratteristiche = caratteristiche + " " + x.Nome);
            double kcal = 0;
            int count = 0;
            (from rs in db.RicettaStrumento where rs.idRicetta == r.idRicetta select rs.Kcal).ToList().ForEach(x => { kcal += x; count++; });
            if (count > 0) kcal = kcal / count;
            t.SetToolTip(node.getImage(), "Nome " + r.Nome +
                                          "\nPortata " + r.portata +
                                          "\nCaratteristiche :" + caratteristiche +
                                          "\nKcal = " + kcal +
                                          "\nPersone = " + r.Persone);
            return node;
        }
        internal delegate List<Control> searchElement(string x);
    }
}
