using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synthesizer
{
    public partial class BasicSynthesiser : Form
    {

        private const int SAMPLE_RATE = 44100;
        private const short BITS_PER_SAMPLE = 16;

        public BasicSynthesiser()
        {
            InitializeComponent();
        }

        private void BasicSynthesiser_KeyDown(object sender, KeyEventArgs e)
        {
            IEnumerable<Oscilator> oscilators = this.Controls.OfType<Oscilator>().Where(o => o.On);
            Random random = new Random();
            short[] wave = new short[SAMPLE_RATE];
            byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
            float frequency = 440f;
            int oscilatorsCount = oscilators.Count();

            switch(e.KeyCode)
            {
                case Keys.Z:
                    frequency = 65.4f;
                    break;
                case Keys.X:
                    frequency = 138.59f;
                    break;
                case Keys.C:
                    frequency = 261.62f;
                    break;
                case Keys.V:
                    frequency = 523.25f;
                    break;
                case Keys.B:
                    frequency = 1046.5f;
                    break;
                case Keys.N:
                    frequency = 2093f;
                    break;
                case Keys.M:
                    frequency = 4186.1f;
                    break;
                default:
                    return;
            }

            foreach (Oscilator oscilator in oscilators)
            {
                int samplesPerWaveLength = (int)(SAMPLE_RATE / frequency);
                short ampStem = (short)((short.MaxValue * 2) / samplesPerWaveLength);
                short tempSample;
                switch(oscilator.WaveForm)
                {
                    case WaveForm.Sine:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i)/oscilatorsCount);
                        }
                        break;
                    case WaveForm.Square:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16((short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * frequency) / SAMPLE_RATE) * i))/oscilatorsCount);
                        }
                        break;
                    case WaveForm.Saw:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            tempSample = -short.MaxValue;
                            for(int j = 0; j<samplesPerWaveLength && i< SAMPLE_RATE;j++)
                            {
                                tempSample += ampStem;
                                wave[i++] += Convert.ToInt16(tempSample/oscilatorsCount);

                            }
                            i--;
                        }
                        break;
                    case WaveForm.Triangle:
                        tempSample = -short.MaxValue;
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            if(Math.Abs(tempSample + ampStem)>short.MaxValue)
                            {
                                ampStem = (short)-ampStem;
                            }
                            tempSample += ampStem;
                            wave[i] += Convert.ToInt16(tempSample / oscilatorsCount);
                        }
                        break;
                    case WaveForm.Noise:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] += Convert.ToInt16(random.Next(-short.MaxValue, short.MaxValue)/oscilatorsCount);
                        }
                        break;
                }

            }
            Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
            using (MemoryStream memorystream = new MemoryStream())
            using (BinaryWriter binarywriter = new BinaryWriter(memorystream))
            {
                short blockAlign = BITS_PER_SAMPLE / 8;
                int subChunckTwoSize = SAMPLE_RATE + blockAlign;
                binarywriter.Write(new[] { 'R', 'I', 'F', 'F' });
                binarywriter.Write(36 + subChunckTwoSize);
                binarywriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't' });
                binarywriter.Write(16);
                binarywriter.Write((short)1);
                binarywriter.Write((short)1);
                binarywriter.Write(SAMPLE_RATE);
                binarywriter.Write(SAMPLE_RATE * blockAlign);
                binarywriter.Write(blockAlign);
                binarywriter.Write(BITS_PER_SAMPLE);
                binarywriter.Write(new[] { 'd', 'a', 't', 'a' });
                binarywriter.Write(subChunckTwoSize);
                binarywriter.Write(binaryWave);
                memorystream.Position = 0;
                new SoundPlayer(memorystream).Play();

            }

        }

        private void oscilator1_Enter(object sender, EventArgs e)
        {

        }
    }

    public enum WaveForm
        {
        Sine,Square,Saw,Triangle,Noise
        }
}
