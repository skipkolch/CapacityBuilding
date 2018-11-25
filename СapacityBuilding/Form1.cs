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
using System.Windows.Forms.DataVisualization.Charting;

namespace СapacityBuilding
{
    public partial class Form1 : Form
    {
        private int NumberChannel;

        List<List<double>> data;

        private bool CanStartWrite;

        private double[] averageValues;

        private StreamWriter streamWriter;

        private int N;

        private double[] ReFm;
        private double[] ImFm;
        private double[] spectr;

        public Form1()
        {
            InitializeComponent();

            NumberChannel = 1;
            N = 10000;

            CanStartWrite = false;

            openFileDialog1.Filter = saveFileDialog1.Filter = "Text files(*.txt)|*.txt";

            chart1.Series[0].ToolTip = "X = #VALX, Y = #VALY";
            chart1.GetToolTipText += chart_GetToolTipText;
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
                        try
                        {
                            data = ReadingFromFile(mystr);

                            averageValues = CalculateAverageValues(data);

                            ReFm = InitReFm(averageValues);
                            ImFm = InitImFm(averageValues);

                            spectr = CalculateSpectr(ReFm, ImFm);

                            label1.Text = "Done!";
                            label1.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            mystr.Close();
                        }
                    }
                }                
            }
            else MessageBox.Show("Input Number Channel");
        }


        private void DrawFunc(double[] array, string str)
        {
            if (array != null)
            {
                chart1.Series[0].Name = str;
                chart1.Series[0].Points.Clear();
                int size = 50;
                //int size = spectr.Lenght;
                for (int i = 0; i < size; i++)
                {
                    chart1.Series[0].Points.AddXY(i, array[i]);
                }
            }
            else
                MessageBox.Show("Нет данных для чтения", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private double[] CalculateAverageValues(List<List<double>> array)
        {
            double[] local = new double[array[0].Count];

            double sum = 0;

            progressBar1.Value = 0;
            progressBar1.Maximum = local.Length;
            label1.Text = "Calculate Average Values";
            label1.Refresh();

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

        private double[] CalculateSpectr(double[] RM, double[] IM)
        {
            int N = RM.Length;
            double[] spectr = new double[N];


            for (int i = 0; i < N; i++)
                spectr[i] = Math.Sqrt(Math.Pow(ReFm[i], 2) + Math.Pow(ImFm[i], 2));

            return spectr;
        }

        private List<List<double>> ReadingFromFile(Stream filename)
        {
            List<List<double>> local = new List<List<double>>();
            StreamReader reader = new StreamReader(filename);
            string[] lineData;

            int oldNumber = 0;
            int j = -1;
            CanStartWrite = false;

            while (!reader.EndOfStream)
            {
                lineData = reader.ReadLine().Split(' ');
                oldNumber++;

                if (lineData[0] == "0")
                {
                    continue;
                }
                else
                {
                    local.Add(new List<double>());
                    j++;

                    for(int i = 0; (i < N) && (!reader.EndOfStream); i++)
                    {
                        lineData = reader.ReadLine().Split(' ');
                        local[j].Add(double.Parse(lineData[NumberChannel]));
                    }

                    reader = new StreamReader(filename);
                    for (int i = 1; i < oldNumber; i++)
                        reader.ReadLine();           
                }
                            
            }

            local.Remove(local[local.Count - 1]);

            reader.Close();

            return local;
        }

        private double[] InitReFm(double[] Fk)
        {
            double sum;
            int size = Fk.Length;
            double[] localReF = new double[size];

            double h = 2 * Math.PI / Fk.Length;

            progressBar1.Maximum = size;
            progressBar1.Value = 0;
            label1.Text = "Calculate Re in Furie Transform";
            label1.Refresh();

            for (int i = 0; i < size; i++)
            {
                sum = 0;

                for (int j = 0; j < size; j++)
                    sum += Fk[j] * Math.Cos(h * i * j);

                localReF[i] = sum / Math.Sqrt(size);

                progressBar1.Value++;
            }

            return localReF;
        }

        private double[] InitImFm(double[] Fk)
        {
            double sum;
            int size = Fk.Length;
            double[] localImF = new double[size];

            double h = 2 * Math.PI / Fk.Length;

            progressBar1.Maximum = size;
            progressBar1.Value = 0;
            label1.Text = "Calculate Im in Furie Transform";
            label1.Refresh();

            for (int i = 0; i < size; i++)
            {
                sum = 0;

                for (int j = 0; j < size; j++)
                    sum += Fk[j] * Math.Sin(h * i * j);

                localImF[i] = -sum / Math.Sqrt(size);


                progressBar1.Value++;
            }

            return localImF;
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

        private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Если текст в подсказке уже есть, то ничего не меняем.
            if (!String.IsNullOrWhiteSpace(e.Text))
                return;

            Console.WriteLine(e.HitTestResult.ChartElementType);

            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                case ChartElementType.DataPointLabel:
                case ChartElementType.Gridlines:
                case ChartElementType.Axis:
                case ChartElementType.TickMarks:
                case ChartElementType.PlottingArea:
                    // Первый ChartArea
                    var area = chart1.ChartAreas[0];

                    // Его относительные координаты (в процентах от размеров Chart)
                    var areaPosition = area.Position;

                    // Переводим в абсолютные
                    var areaRect = new RectangleF(areaPosition.X * chart1.Width / 100, areaPosition.Y * chart1.Height / 100,
                        areaPosition.Width * chart1.Width / 100, areaPosition.Height * chart1.Height / 100);

                    // Область построения (в процентах от размеров area)
                    var innerPlot = area.InnerPlotPosition;

                    double x = area.AxisX.Minimum +
                                (area.AxisX.Maximum - area.AxisX.Minimum) * (e.X - areaRect.Left - innerPlot.X * areaRect.Width / 100) /
                                (innerPlot.Width * areaRect.Width / 100);
                    double y = area.AxisY.Maximum -
                                (area.AxisY.Maximum - area.AxisY.Minimum) * (e.Y - areaRect.Top - innerPlot.Y * areaRect.Height / 100) /
                                (innerPlot.Height * areaRect.Height / 100);

                    Console.WriteLine("{0:F2} {1:F2}", x, y);
                    e.Text = String.Format("{0:F2} {1:F2}", x, y);
                    break;
            }
        }

        private void furieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawFunc(ReFm, "ReFm");
        }

        private void spectrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawFunc(spectr, "Spectr");
        }

        private void averageValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawFunc(averageValues, "Average Values");
        }
    }
}
