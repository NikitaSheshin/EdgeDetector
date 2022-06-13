using OpenCvSharp;
using ClosedXML.Excel;
using System.Text;
using System.IO;

// Перевод из Mat в массив double
static double[,] MatToDouble(Mat mat)
{
    double[,] image = new double[mat.Height, mat.Width];

    for (int i = 0; i < mat.Height; ++i)
        for (int j = 0; j < mat.Width; ++j)
        {
            Vec3b pixel = mat.At<Vec3b>(i, j);
            image[i, j] = pixel[2];
        }

    return image;
}

const int k = 275; // Количество изображений в датасете

for (int i = 10; i < 95; i += 5)
{
    Console.WriteLine("i: " + i);
    for (int j = 15; j < 100; j += 5)
    {
        Console.WriteLine("\tj: " + j);

        // Создание новой таблицы Excel
        IXLWorkbook newExcelFile = new XLWorkbook();
        IXLWorksheet sheet = newExcelFile.Worksheets.Add("List1");
        sheet.Cell("A1").Value = "Image";
        sheet.Cell("B1").Value = "Accuracy";
        sheet.Cell("C1").Value = "F1";
        sheet.Cell("D1").Value = "Time";

        int sumTime = 0;

        for (int l = 1; l <= k; ++l)
        {
            // Открытие исходного изображение
            string fileName = "C:\\Users\\Sheshin\\Desktop\\4Семестр\\Курсовая2\\Фотокарточки\\ForTest\\";
            fileName += l.ToString();
            fileName += ".jpg";

            // Обработка изображения и подсчет времени
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            ConsoleApp1.CannyDetector detetor = 
                new ConsoleApp1.CannyDetector(fileName, (double)j/100, (double)i/100);
            double[,] myRes = detetor.Detect();
            myStopwatch.Stop();


            sumTime += int.Parse(myStopwatch.ElapsedMilliseconds.ToString());


            //Открытие размеченного изображения 
            string fileNameRes = "C:\\Users\\Sheshin\\Desktop\\4Семестр\\Курсовая2\\Фотокарточки\\Results\\";
            fileNameRes += l.ToString();
            fileNameRes += ".jpg";
            Mat checkImg = Cv2.ImRead(fileNameRes, ImreadModes.Grayscale);
            int height = checkImg.Height;
            int width = checkImg.Width;

            double[,] check = MatToDouble(checkImg);


            ConsoleApp1.Comparer comparer = new ConsoleApp1.Comparer(check, myRes, width, height);

            // Получение метрик для текущего изображение
            double accuracy = comparer.GetAccuracy();
            double f1 = comparer.GetF1();

            // Добавление метрик в таблицу
            sheet.Cell($"A{l + 1}").Value = l.ToString();
            sheet.Cell($"B{l + 1}").Value = accuracy.ToString();
            sheet.Cell($"C{l + 1}").Value = f1.ToString();
            sheet.Cell($"D{l + 1}").Value = myStopwatch.ElapsedMilliseconds;
        }

        // Сохранеие таблицы
        newExcelFile.SaveAs($@"C:\Users\Sheshin\Desktop\4Семестр\Курсовая2\Фотокарточки\CannyDetector{i}+{j}.xlsx");
    }
    
}