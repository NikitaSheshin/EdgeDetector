using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Analize
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            // Создание нового документа Excel
            IXLWorkbook ResultExcelFile =
                        new XLWorkbook();
            IXLWorksheet resSheet = ResultExcelFile.Worksheets.Add("Result");

            double sumAccuracy = 0, sumF1 = 0, sumTime = 0, bestAccValue = 0, bestF1Value = 0;
            const int len = 275;
            double totalAcc = 0, totalF1 = 0;

            // Добавление обозначения столбцов
            resSheet.Cell($"A1").Value = "Low";
            resSheet.Cell($"B1").Value = "Best High Accuracy";
            resSheet.Cell($"C1").Value = "Best High F1";
            resSheet.Cell($"D1").Value = "Mean Accuracy";
            resSheet.Cell($"E1").Value = "Mean F1";
            resSheet.Cell($"F1").Value = "Mean Time";

            int l = 2;
            for (int i = 10; i < 95; i += 5)
            {
                // Добавление номера нижней границы
                resSheet.Cell($"A{l}").Value = ((double)i/100).ToString();

                double bestMeanAcc = 0;
                double bestMeanF1 = 0;
                totalAcc = 0;
                totalF1 = 0;

                for (int j = i + 5; j < 100; j += 5)
                {
                    sumAccuracy = 0;
                    sumF1 = 0;
                    sumTime = 0;

                    // Открытие таблицы Excel
                    IXLWorkbook ExcelFile =
                        new XLWorkbook($@"C:\Users\Sheshin\Desktop\4Семестр\Курсовая2\Фотокарточки\CannyDetector{i}+{j}.xlsx");
                    IXLWorksheet sheet = ExcelFile.Worksheets.First();

                    // Подсчет суммы для каждой метрики
                    for (int k = 2; k <= 276; k++)
                    {
                        sumAccuracy += double.Parse(sheet.Cell($"B{k}").Value.ToString());
                        sumF1 += double.Parse(sheet.Cell($"C{k}").Value.ToString());
                        sumTime += double.Parse(sheet.Cell($"D{k}").Value.ToString());
                    }

                    // Проверки на обновление лучшего значения для верхней границы
                    if (bestMeanAcc < sumAccuracy / len)
                    {
                        bestMeanAcc = (sumAccuracy / len);
                        bestAccValue = j;
                    }

                    if(bestMeanF1 < sumF1 / len)
                    {
                        bestMeanF1 = (sumF1 / len);
                        bestF1Value = j;
                    }

                    // Подсчет сумм средних для каждой метрики
                    totalF1 += (sumF1 / len);
                    totalAcc += (sumAccuracy / len);
                }

                // Добавление в таблицу значений для текущего значения нижней границы
                resSheet.Cell($"B{l}").Value = bestMeanAcc.ToString() + " " + bestAccValue;
                resSheet.Cell($"C{l}").Value = bestMeanF1.ToString() + " " + bestF1Value;
                resSheet.Cell($"D{l}").Value = totalAcc / ((100 - i) / 5 - 1);
                resSheet.Cell($"E{l}").Value = totalF1 / ((100 - i) / 5 - 1);
                resSheet.Cell($"F{l}").Value = (double)sumTime / len;

                l++;
            }

            // Сохранение файла с результатами
            ResultExcelFile.SaveAs($@"C:\Users\Sheshin\Desktop\4Семестр\Курсовая2\Фотокарточки\Results.xlsx");
        }
    }
}
