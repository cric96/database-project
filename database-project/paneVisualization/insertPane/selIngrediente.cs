using database_project.databaseGestor;
using database_project.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_project.paneVisualization.insertPane
{
    public partial class selIngrediente : Form
    {
        private Tuple<String, int> res;
        public selIngrediente(int idIngr)
        {
            InitializeComponent();
            (from c in RicettarioDB.getInstance().IngrUDM
             where c.idIngrediente == idIngr
             select c.NomeUDM).ToList().ForEach(x => comboBox1.Items.Add(x));
            this.button1.Click += (obj, o1) => this.Close();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Icon = Properties.Resources.iconmain;
            this.comboBox1.SelectedIndexChanged += (obj, args) =>
            {
                if (this.comboBox1.SelectedItem.ToString().Equals("q.b.")) {
                    this.textBox1.Enabled = false;
                } else
                {
                    this.textBox1.Enabled = true;
                }
            };
        }

        private void selIngrediente_Load(object sender, EventArgs e)
        {

        }
        public Tuple<String,int> getQuantity()
        {

            int quantity = 1;
            do
            {

                this.ShowDialog();
                
                if (this.comboBox1.SelectedItem == null) AllertGestor.defaultError("Devi inserire l'unità di misura!");
                else if (this.textBox1.Enabled && !Int32.TryParse(this.textBox1.Text, out quantity)) AllertGestor.defaultError("Deve essere numerica!");
                else return new Tuple<String, int>(this.comboBox1.SelectedItem.ToString(), quantity);
            } while (this.comboBox1.SelectedItem == null || !Int32.TryParse(this.textBox1.Text, out quantity));
            return null;
        
        }
    }
}
