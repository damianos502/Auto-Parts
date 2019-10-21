namespace Sklep
{
    partial class RapOk
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMiesiac = new System.Windows.Forms.ComboBox();
            this.cmbRok = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz miesiąc dla którego ma zostać wygenerowany raport:";
            // 
            // cmbMiesiac
            // 
            this.cmbMiesiac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cmbMiesiac.FormattingEnabled = true;
            this.cmbMiesiac.Items.AddRange(new object[] {
            "Styczeń",
            "Luty",
            "Marzec",
            "Kwiecień",
            "Maj",
            "Czerwiec",
            "Lipiec",
            "Sierpień",
            "Wrzesień",
            "Październik",
            "Listopad",
            "Grudzień"});
            this.cmbMiesiac.Location = new System.Drawing.Point(16, 53);
            this.cmbMiesiac.Name = "cmbMiesiac";
            this.cmbMiesiac.Size = new System.Drawing.Size(192, 32);
            this.cmbMiesiac.TabIndex = 1;
            // 
            // cmbRok
            // 
            this.cmbRok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cmbRok.FormattingEnabled = true;
            this.cmbRok.Items.AddRange(new object[] {
            "2017",
            "2018",
            "2019"});
            this.cmbRok.Location = new System.Drawing.Point(214, 53);
            this.cmbRok.Name = "cmbRok";
            this.cmbRok.Size = new System.Drawing.Size(121, 32);
            this.cmbRok.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(366, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(16, 105);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(772, 386);
            this.DGV.TabIndex = 4;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(Sklep.RapOk);
            // 
            // RapOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbRok);
            this.Controls.Add(this.cmbMiesiac);
            this.Controls.Add(this.label1);
            this.Name = "RapOk";
            this.Text = "RapOk";
            this.Load += new System.EventHandler(this.RapOk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMiesiac;
        private System.Windows.Forms.ComboBox cmbRok;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}