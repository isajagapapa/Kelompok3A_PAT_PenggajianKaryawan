
namespace ClientGaji
{
    partial class DaftarGaji
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
            this.buttonCari = new System.Windows.Forms.Button();
            this.textBoxNip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewGajiUser = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSemua = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGajiUser)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCari
            // 
            this.buttonCari.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCari.Font = new System.Drawing.Font("Montserrat", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCari.ForeColor = System.Drawing.Color.White;
            this.buttonCari.Location = new System.Drawing.Point(265, 104);
            this.buttonCari.Name = "buttonCari";
            this.buttonCari.Size = new System.Drawing.Size(75, 23);
            this.buttonCari.TabIndex = 16;
            this.buttonCari.Text = "Cari";
            this.buttonCari.UseVisualStyleBackColor = false;
            this.buttonCari.Click += new System.EventHandler(this.buttonCari_Click);
            // 
            // textBoxNip
            // 
            this.textBoxNip.Location = new System.Drawing.Point(75, 104);
            this.textBoxNip.Name = "textBoxNip";
            this.textBoxNip.Size = new System.Drawing.Size(184, 22);
            this.textBoxNip.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "NIP";
            // 
            // dataGridViewGajiUser
            // 
            this.dataGridViewGajiUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGajiUser.Location = new System.Drawing.Point(39, 140);
            this.dataGridViewGajiUser.Name = "dataGridViewGajiUser";
            this.dataGridViewGajiUser.RowHeadersWidth = 51;
            this.dataGridViewGajiUser.RowTemplate.Height = 24;
            this.dataGridViewGajiUser.Size = new System.Drawing.Size(716, 246);
            this.dataGridViewGajiUser.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 47);
            this.label1.TabIndex = 12;
            this.label1.Text = "Daftar Gaji";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSemua
            // 
            this.buttonSemua.BackColor = System.Drawing.Color.Yellow;
            this.buttonSemua.Font = new System.Drawing.Font("Montserrat", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSemua.ForeColor = System.Drawing.Color.Black;
            this.buttonSemua.Location = new System.Drawing.Point(614, 105);
            this.buttonSemua.Name = "buttonSemua";
            this.buttonSemua.Size = new System.Drawing.Size(141, 23);
            this.buttonSemua.TabIndex = 18;
            this.buttonSemua.Text = "Tampilkan Semua";
            this.buttonSemua.UseVisualStyleBackColor = false;
            this.buttonSemua.Click += new System.EventHandler(this.buttonSemua_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonMenu.Font = new System.Drawing.Font("Montserrat", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(713, 406);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(75, 32);
            this.buttonMenu.TabIndex = 40;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // DaftarGaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonSemua);
            this.Controls.Add(this.buttonCari);
            this.Controls.Add(this.textBoxNip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewGajiUser);
            this.Controls.Add(this.label1);
            this.Name = "DaftarGaji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Gaji";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGajiUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCari;
        private System.Windows.Forms.TextBox textBoxNip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewGajiUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSemua;
        private System.Windows.Forms.Button buttonMenu;
    }
}