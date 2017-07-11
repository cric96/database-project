namespace database_project.paneVisualization.selectionVisualizzation
{
    partial class StrumentoVisualizzation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nome = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.descrizione = new System.Windows.Forms.RichTextBox();
            this.immagine = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Elettrodomestico = new System.Windows.Forms.Label();
            this.potenza = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.immagine)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.27536F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.72464F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.nome.Location = new System.Drawing.Point(3, 0);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(86, 31);
            this.nome.TabIndex = 0;
            this.nome.Text = "label1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.4964F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.50359F));
            this.tableLayoutPanel2.Controls.Add(this.descrizione, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.immagine, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 187);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // descrizione
            // 
            this.descrizione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descrizione.Location = new System.Drawing.Point(3, 3);
            this.descrizione.Name = "descrizione";
            this.descrizione.Size = new System.Drawing.Size(76, 181);
            this.descrizione.TabIndex = 0;
            this.descrizione.Text = "";
            // 
            // immagine
            // 
            this.immagine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.immagine.Location = new System.Drawing.Point(85, 3);
            this.immagine.Name = "immagine";
            this.immagine.Size = new System.Drawing.Size(190, 181);
            this.immagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.immagine.TabIndex = 1;
            this.immagine.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.Elettrodomestico, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.potenza, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 37);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(278, 29);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // Elettrodomestico
            // 
            this.Elettrodomestico.AutoSize = true;
            this.Elettrodomestico.Location = new System.Drawing.Point(3, 0);
            this.Elettrodomestico.Name = "Elettrodomestico";
            this.Elettrodomestico.Size = new System.Drawing.Size(35, 13);
            this.Elettrodomestico.TabIndex = 0;
            this.Elettrodomestico.Text = "label1";
            // 
            // potenza
            // 
            this.potenza.AutoSize = true;
            this.potenza.Location = new System.Drawing.Point(3, 14);
            this.potenza.Name = "potenza";
            this.potenza.Size = new System.Drawing.Size(35, 13);
            this.potenza.TabIndex = 1;
            this.potenza.Text = "label2";
            // 
            // StrumentoVisualizzation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "StrumentoVisualizzation";
            this.Text = "StrumentoVisualizzation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.immagine)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox descrizione;
        private System.Windows.Forms.PictureBox immagine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label Elettrodomestico;
        private System.Windows.Forms.Label potenza;
    }
}