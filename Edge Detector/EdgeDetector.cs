using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Edge_Detector
{
    public partial class EdgeDetector : Form
    {
        Detectors.Detector detector;
        String fileName;

        public EdgeDetector()
        {
            InitializeComponent();
        }


        // Открытие изображения из файла
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter =
               "Image Files(*.JPG)|*.JPG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = OpenFileDialog.FileName;
                    InputImagePB.Image = Image.FromFile(OpenFileDialog.FileName);
                    DoButton.Enabled = true;
                    ResultSaveItem.Enabled = false;
                    InputSaveItem.Enabled = true;
                    SaveToolStripItem.Enabled = true;
                    ResultImagePB.Image = null;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Попытка открыть файл некорректного формата.", "Ошибка открытия");
                }
            }
        }

        private void DetectEdges(object sender, EventArgs e)
        {
            // Определение выбранного детектора и выбор соответствующего класса
            if (SobelRadioButton.Checked)
                detector = new Detectors.SobelDetector(fileName);
            else if (CannyRadioButton.Checked)
                detector = new Detectors.CannyDetector(fileName, double.Parse(HighTreshold.Value.ToString()),
                        double.Parse(LowTreshold.Value.ToString()));
            ResultImagePB.Image = detector.Detect();
            ResultSaveItem.Enabled = true;
        }


        // Сохранение изображения в файл
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = 
                "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((sender as ToolStripMenuItem).Text == "Исходное изображение")
                    InputImagePB.Image.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if((sender as ToolStripMenuItem).Text == "Обработанное изображение")
                    ResultImagePB.Image.Save(SaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Очистка PictureBox c результирующим озбражением и отмена возможности сохранить его
            ResultImagePB.Image = null;
            ResultSaveItem.Enabled = false;


            // Для детектора Канни разблокировать возможность настройки либо забликировать при отключении
            bool f;
            if (CannyRadioButton.Checked)
                f = true;
            else 
                f = false;

            HighTreshold.Enabled = f;
            LowTreshold.Enabled = f;
        }

        // Проверка на то, что нижняя граница не стала больше или равна верхней
        private void LowTreshold_ValueChanged(object sender, EventArgs e)
        {
            if (LowTreshold.Value >= HighTreshold.Value)
                LowTreshold.Value = 
                    decimal.Parse((double.Parse(LowTreshold.Value.ToString()) - 0.05).ToString());
        }

        // Проверка на то, что верхняя граница не стала меньше или равна нижней
        private void HighTreshold_ValueChanged(object sender, EventArgs e)
        {
            if (LowTreshold.Value >= HighTreshold.Value)
                HighTreshold.Value =
                    decimal.Parse((double.Parse(LowTreshold.Value.ToString()) + 0.05).ToString());
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process Info = new Process();
            Info.StartInfo.FileName = @"A:\ConsoleApp1\Edge Detector\bin\Debug\Help.txt";
            Info.StartInfo.CreateNoWindow = false;
            Info.Start();
        }
    }
}
