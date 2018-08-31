using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synthesizer
{
    public class Oscilator : GroupBox
    {
        public Oscilator()
        {
            this.Controls.Add(new Button()
            {
            Name = "Sine",
            Location = new System.Drawing.Point(10, 15),
            Text = "Sine"
            });

            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new System.Drawing.Point(65, 15),
                Text = "Square"
            });

            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new System.Drawing.Point(120, 15),
                Text = "Saw"
            });

            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new System.Drawing.Point(10, 50),
                Text = "Triangle"
            });

            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new System.Drawing.Point(65, 50),
                Text = "Noise"
            }); 
            foreach(Control control in this.Controls)
            {
                control.Size = new System.Drawing.Size(50, 30);
                control.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f);
                control.Click += WaveButton_Click;
            }
            this.Controls.Add(new CheckBox()
            {
                Name = "OscilatorOn",
                Location = new System.Drawing.Point(210, 10),
                Size = new System.Drawing.Size(40, 30),
                Text = "On",
                Checked = true

            });
                
                


            


        }

        public WaveForm WaveForm { get;  private set; }
        public bool On => ((CheckBox)this.Controls["OscilatorOn"]).Checked;
        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);
           // MessageBox.Show($"Button you pressed was {this.WaveForm}");
           // System.Media.SystemSounds.Asterisk.Play();
        }
    }   

}

