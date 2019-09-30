namespace CCr
{
    partial class AdminForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pbxhome)).BeginInit();
            this.SuspendLayout();
            // 
            // btnhome
            // 
            this.btnhome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnhome.FlatAppearance.BorderSize = 0;
            this.btnhome.Click += new System.EventHandler(this.btnhome_Click);
            this.btnhome.MouseEnter += new System.EventHandler(this.btnhome_MouseEnter);
            this.btnhome.MouseLeave += new System.EventHandler(this.btnhome_MouseLeave);
            // 
            // pbxhome
            // 
            this.pbxhome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.pbxhome.MouseEnter += new System.EventHandler(this.pbxhome_MouseEnter);
            this.pbxhome.MouseLeave += new System.EventHandler(this.pbxhome_MouseLeave);
            // 
            // btnclose
            // 
            this.btnclose.FlatAppearance.BorderSize = 0;
            // 
            // btnminimyze
            // 
            this.btnminimyze.FlatAppearance.BorderSize = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(966, 610);
            this.Name = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbxhome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
