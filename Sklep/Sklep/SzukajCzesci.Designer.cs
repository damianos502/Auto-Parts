namespace Sklep
{
    partial class SzukajCzesci
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
            this.btnSzukaj = new System.Windows.Forms.Button();
            this.cboCzesc = new System.Windows.Forms.ComboBox();
            this.txtCzesc = new System.Windows.Forms.TextBox();
            this.DGW = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSzukaj
            // 
            this.btnSzukaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnSzukaj.Location = new System.Drawing.Point(652, 15);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(124, 39);
            this.btnSzukaj.TabIndex = 9;
            this.btnSzukaj.Text = "Szukaj";
            this.btnSzukaj.UseVisualStyleBackColor = true;
            this.btnSzukaj.Click += new System.EventHandler(this.BtnSzukaj_Click);
            // 
            // cboCzesc
            // 
            this.cboCzesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.cboCzesc.FormattingEnabled = true;
            this.cboCzesc.Items.AddRange(new object[] {
            "Model",
            "Numer Katalogowy",
            "Nazwa Czesci"});
            this.cboCzesc.Location = new System.Drawing.Point(413, 15);
            this.cboCzesc.Name = "cboCzesc";
            this.cboCzesc.Size = new System.Drawing.Size(213, 39);
            this.cboCzesc.TabIndex = 8;
            // 
            // txtCzesc
            // 
            this.txtCzesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.txtCzesc.Location = new System.Drawing.Point(132, 15);
            this.txtCzesc.Name = "txtCzesc";
            this.txtCzesc.Size = new System.Drawing.Size(251, 38);
            this.txtCzesc.TabIndex = 7;
            // 
            // DGW
            // 
            this.DGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW.Location = new System.Drawing.Point(12, 85);
            this.DGW.Name = "DGW";
            this.DGW.Size = new System.Drawing.Size(776, 191);
            this.DGW.TabIndex = 6;
            this.DGW.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Szukaj:";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Sklep.SzukajCzesci);
            // 
            // SzukajCzesci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 294);
            this.Controls.Add(this.btnSzukaj);
            this.Controls.Add(this.cboCzesc);
            this.Controls.Add(this.txtCzesc);
            this.Controls.Add(this.DGW);
            this.Controls.Add(this.label1);
            this.Name = "SzukajCzesci";
            this.Text = "SzukajCzesci";
            this.Load += new System.EventHandler(this.SzukajCzesci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSzukaj;
        private System.Windows.Forms.ComboBox cboCzesc;
        private System.Windows.Forms.TextBox txtCzesc;
        private System.Windows.Forms.DataGridView DGW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}