namespace Synthesizer
{
    partial class BasicSynthesiser
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.oscilator1 = new Synthesizer.Oscilator();
            this.oscilator2 = new Synthesizer.Oscilator();
            this.oscilator3 = new Synthesizer.Oscilator();
            this.SuspendLayout();
            // 
            // oscilator1
            // 
            this.oscilator1.Location = new System.Drawing.Point(47, 27);
            this.oscilator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oscilator1.Name = "oscilator1";
            this.oscilator1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oscilator1.Size = new System.Drawing.Size(267, 123);
            this.oscilator1.TabIndex = 0;
            this.oscilator1.TabStop = false;
            this.oscilator1.Text = "oscilator1";
            this.oscilator1.Enter += new System.EventHandler(this.oscilator1_Enter);
            // 
            // oscilator2
            // 
            this.oscilator2.Location = new System.Drawing.Point(383, 27);
            this.oscilator2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oscilator2.Name = "oscilator2";
            this.oscilator2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oscilator2.Size = new System.Drawing.Size(267, 123);
            this.oscilator2.TabIndex = 1;
            this.oscilator2.TabStop = false;
            this.oscilator2.Text = "oscilator2";
            // 
            // oscilator3
            // 
            this.oscilator3.Location = new System.Drawing.Point(707, 27);
            this.oscilator3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oscilator3.Name = "oscilator3";
            this.oscilator3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oscilator3.Size = new System.Drawing.Size(267, 123);
            this.oscilator3.TabIndex = 2;
            this.oscilator3.TabStop = false;
            this.oscilator3.Text = "oscilator3";
            // 
            // BasicSynthesiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 247);
            this.Controls.Add(this.oscilator3);
            this.Controls.Add(this.oscilator2);
            this.Controls.Add(this.oscilator1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BasicSynthesiser";
            this.Text = "BasicSynthesiser";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicSynthesiser_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Oscilator oscilator1;
        private Oscilator oscilator2;
        private Oscilator oscilator3;
    }
}

