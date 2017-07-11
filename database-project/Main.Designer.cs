using database_project.formGestor;

namespace database_project
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.selectionPane = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rightPane = new System.Windows.Forms.TableLayoutPanel();
            this.visualizationPane = new System.Windows.Forms.FlowLayoutPanel();
            this.searchPane = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.ricettaTip = new System.Windows.Forms.ToolTip(this.components);
            this.ingredientiTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainLayout.SuspendLayout();
            this.selectionPane.SuspendLayout();
            this.rightPane.SuspendLayout();
            this.searchPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.96599F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.03401F));
            this.mainLayout.Controls.Add(this.selectionPane, 0, 0);
            this.mainLayout.Controls.Add(this.rightPane, 1, 0);
            this.mainLayout.Location = new System.Drawing.Point(-1, 1);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.82143F));
            this.mainLayout.Size = new System.Drawing.Size(588, 560);
            this.mainLayout.TabIndex = 0;
            // 
            // selectionPane
            // 
            this.selectionPane.Controls.Add(this.button3);
            this.selectionPane.Controls.Add(this.button2);
            this.selectionPane.Controls.Add(this.button1);
            this.selectionPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionPane.Location = new System.Drawing.Point(3, 3);
            this.selectionPane.Name = "selectionPane";
            this.selectionPane.Size = new System.Drawing.Size(82, 554);
            this.selectionPane.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::database_project.Properties.Resources.ricetta;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 77);
            this.button3.TabIndex = 3;
            this.ricettaTip.SetToolTip(this.button3, "ricette");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::database_project.Properties.Resources.ingredienti;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 77);
            this.button2.TabIndex = 2;
            this.ingredientiTip.SetToolTip(this.button2, "ingredienti");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::database_project.Properties.Resources.menu;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 77);
            this.button1.TabIndex = 0;
            this.menuTip.SetToolTip(this.button1, "menu");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rightPane
            // 
            this.rightPane.ColumnCount = 1;
            this.rightPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightPane.Controls.Add(this.visualizationPane, 0, 1);
            this.rightPane.Controls.Add(this.searchPane, 0, 0);
            this.rightPane.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightPane.Location = new System.Drawing.Point(91, 3);
            this.rightPane.Name = "rightPane";
            this.rightPane.RowCount = 2;
            this.rightPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.956679F));
            this.rightPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.04332F));
            this.rightPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightPane.Size = new System.Drawing.Size(494, 554);
            this.rightPane.TabIndex = 1;
            // 
            // visualizationPane
            // 
            this.visualizationPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizationPane.Location = new System.Drawing.Point(3, 36);
            this.visualizationPane.Name = "visualizationPane";
            this.visualizationPane.Size = new System.Drawing.Size(488, 515);
            this.visualizationPane.TabIndex = 1;
            // 
            // searchPane
            // 
            this.searchPane.Controls.Add(this.button5);
            this.searchPane.Controls.Add(this.search);
            this.searchPane.Controls.Add(this.button4);
            this.searchPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPane.Location = new System.Drawing.Point(3, 3);
            this.searchPane.Name = "searchPane";
            this.searchPane.Size = new System.Drawing.Size(488, 27);
            this.searchPane.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::database_project.Properties.Resources.ingradimento;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 20);
            this.button5.TabIndex = 0;
            this.ingredientiTip.SetToolTip(this.button5, "ricerca");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(30, 3);
            this.search.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(449, 20);
            this.search.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.mainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Main";
            this.Text = "Ricettario";
            this.mainLayout.ResumeLayout(false);
            this.selectionPane.ResumeLayout(false);
            this.rightPane.ResumeLayout(false);
            this.searchPane.ResumeLayout(false);
            this.searchPane.PerformLayout();
            this.ResumeLayout(false);

        }

       
        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel selectionPane;
        private System.Windows.Forms.TableLayoutPanel rightPane;
        private System.Windows.Forms.FlowLayoutPanel visualizationPane;
        private System.Windows.Forms.FlowLayoutPanel searchPane;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ToolTip ricettaTip;
        private System.Windows.Forms.ToolTip ingredientiTip;
        private System.Windows.Forms.ToolTip menuTip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}

