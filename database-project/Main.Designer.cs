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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.selectionPane = new System.Windows.Forms.FlowLayoutPanel();
            this.rightPane = new System.Windows.Forms.TableLayoutPanel();
            this.searchPane = new System.Windows.Forms.FlowLayoutPanel();
            this.visualizationPane = new System.Windows.Forms.FlowLayoutPanel();
            this.mainLayout.SuspendLayout();
            this.rightPane.SuspendLayout();
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
            this.selectionPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionPane.Location = new System.Drawing.Point(3, 3);
            this.selectionPane.Name = "selectionPane";
            this.selectionPane.Size = new System.Drawing.Size(82, 554);
            this.selectionPane.TabIndex = 0;
            // 
            // rightPane
            // 
            this.rightPane.ColumnCount = 1;
            this.rightPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightPane.Controls.Add(this.searchPane, 0, 0);
            this.rightPane.Controls.Add(this.visualizationPane, 0, 1);
            this.rightPane.Location = new System.Drawing.Point(91, 3);
            this.rightPane.Name = "rightPane";
            this.rightPane.RowCount = 2;
            this.rightPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.956679F));
            this.rightPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.04332F));
            this.rightPane.Size = new System.Drawing.Size(494, 554);
            this.rightPane.TabIndex = 1;
            // 
            // searchPane
            // 
            this.searchPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPane.Location = new System.Drawing.Point(3, 3);
            this.searchPane.Name = "searchPane";
            this.searchPane.Size = new System.Drawing.Size(488, 27);
            this.searchPane.TabIndex = 0;
            // 
            // visualizationPane
            // 
            this.visualizationPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualizationPane.Location = new System.Drawing.Point(3, 36);
            this.visualizationPane.Name = "visualizationPane";
            this.visualizationPane.Size = new System.Drawing.Size(488, 515);
            this.visualizationPane.TabIndex = 1;
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
            this.rightPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel selectionPane;
        private System.Windows.Forms.TableLayoutPanel rightPane;
        private System.Windows.Forms.FlowLayoutPanel searchPane;
        private System.Windows.Forms.FlowLayoutPanel visualizationPane;
    }
}

