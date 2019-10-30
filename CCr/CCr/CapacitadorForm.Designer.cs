namespace CCr
{
    partial class CapacitadorForm
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxParticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxcerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxhome)).BeginInit();
            this.SuspendLayout();
            // 
            // btnParticipantes
            // 
            this.btnParticipantes.FlatAppearance.BorderSize = 0;
            // 
            // btnNotas
            // 
            this.btnNotas.FlatAppearance.BorderSize = 0;
            // 
            // btncerrar
            // 
            this.btncerrar.FlatAppearance.BorderSize = 0;
            // 
            // pbxhome
            // 
            this.pbxhome.BackColor = System.Drawing.Color.Black;
            this.pbxhome.MouseEnter += new System.EventHandler(this.btnhome_MouseEnter);
            this.pbxhome.MouseLeave += new System.EventHandler(this.btnhome_MouseEnter);
            // 
            // btnhome
            // 
            this.btnhome.BackColor = System.Drawing.Color.Black;
            this.btnhome.FlatAppearance.BorderSize = 0;
            this.btnhome.MouseEnter += new System.EventHandler(this.btnhome_MouseEnter);
            this.btnhome.MouseLeave += new System.EventHandler(this.btnhome_MouseEnter);
            // 
            // btnclose
            // 
            this.btnclose.FlatAppearance.BorderSize = 0;
            // 
            // btnminimyze
            // 
            this.btnminimyze.FlatAppearance.BorderSize = 0;
            // 
            // CapacitadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(966, 628);
            this.Name = "CapacitadorForm";
            this.Load += new System.EventHandler(this.CapacitadorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxParticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxcerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxhome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
