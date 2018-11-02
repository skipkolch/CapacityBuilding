using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СapacityBuilding
{
    public partial class Form1 : Form
    {
        private int NumberChannel;

        List<List<double>> data;

        private bool CanStartWrite;

        private double[] averageValues;

        private StreamWriter streamWriter;

        public Form1()
        {
            InitializeComponent();

            NumberChannel = 0;

            CanStartWrite = false;

            openFileDialog1.Filter = saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
        }
           

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NumberChannel != 0)
            {
                Stream mystr = null;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((mystr = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader myread = new StreamReader(mystr);                       
                        try
                        {
                            data = ReadingFromFile(myread);

                            averageValues = CalculateAverageValues(data);

                            plotGraphic(averageValues);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            mystr.Close();
                            myread.Close();
                        }
                    }
                }                
            }
            else MessageBox.Show("Input Number Channel");
        }

        private void plotGraphic(double[] arr)
        {
            chart1.Series["Values"].Points.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                chart1.Series["Values"].Points.AddXY(i, arr[i]);
            }
        }

        private double[] CalculateAverageValues(List<List<double>> array)
        {
            double[] local = new double[array[0].Count];

            double sum = 0;

            progressBar1.Value = 0;
            progressBar1.Maximum = local.Length;
            
            for (int i = 0; i < local.Length; i++ , progressBar1.Value++)
            {
                try
                {
                    for (int j = 0; j < array.Count; j++)
                    {
                        sum += array[j][i];
                    }

                    sum /= array.Count;
                    local[i] = sum;

                    sum = 0;
                }
                catch (IndexOutOfRangeException ex)
                {
                    break;
                }

            }        
            
            return local;
        }

        private List<List<double>> ReadingFromFile(StreamReader reader)
        {
            List<List<double>> local = new List<List<double>>();
            string[] lineData;

            int i = -1;
            CanStartWrite = false;

            while (!reader.EndOfStream)
            {
                lineData = reader.ReadLine().Split(' ');
              
                if (lineData[0] == "0")
                {
                    if (CanStartWrite)
                        local[i].Add(double.Parse(lineData[NumberChannel]));
                    else continue;
                }
                else
                {
                    local.Add(new List<double>());
                    CanStartWrite = true;
                    i++;
                }
                            
            }
            local.Remove(local[local.Count - 1]);

            return local;
        }

        private void а1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberChannel = 1;
        }

        private void zA2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberChannel = 2;
        }

        private void o2A2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberChannel = 3;
        }

        private void parseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFiles(data);
        }


        private void saveFiles(double[] arr)
        {
            if (arr != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                try
                {// получаем выбранный файл
                    string filename = saveFileDialog1.FileName;

                    streamWriter = new StreamWriter(new FileStream(filename, FileMode.Create));
                    // сохраняем текст в файл
                    for (int i = 0; i < arr.Length; i++)
                        streamWriter.WriteLine(arr[i]);

                    MessageBox.Show("Файл сохранен");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    streamWriter.Close();
                }
            }        
            else MessageBox.Show("Please importing data");
        }

        private void saveFiles(List<List<double>> arr)
        {
            if (arr != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                try
                {
                    streamWriter = new StreamWriter(new FileStream(filename, FileMode.Create));
                    // сохраняем текст в файл

                    string strforSave;

                    for (int i = 0; i < arr[0].Count; i++)
                    {
                        strforSave = "";
                        for (int j = 0; j < arr.Count; j++)
                        {
                            strforSave += arr[j][i].ToString() + "\t";
                        }

                        streamWriter.WriteLine(strforSave);
                    }

                    MessageBox.Show("Файл сохранен");
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    streamWriter.Close();
                }
            }
            else MessageBox.Show("Please importing data");
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFiles(averageValues);
        }
    }
}
