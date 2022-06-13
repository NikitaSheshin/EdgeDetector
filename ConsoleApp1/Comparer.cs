using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Comparer
    {
        int truePositive = 0, trueNegative = 0, falsePositive = 0, falseNegative = 0;

        public Comparer(double[,] correct, double[,] inspected, int width, int height)
        {
            // Разбиение всех точек на классы
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (correct[i, j] != 0 && inspected[i, j] != 0) truePositive++;
                    else if (correct[i, j] == inspected[i, j] && correct[i, j] == 0) 
                        trueNegative++;
                    else if (correct[i, j] != inspected[i, j] && correct[i, j] == 0) 
                        falsePositive++;
                    else falseNegative++;
        }

        // Вычисление Accuracy
        public float GetAccuracy()
            => (float)(truePositive + trueNegative) /
                   (truePositive + trueNegative + falsePositive + falseNegative);

        // Вычисление Precision нужно для вычисления F1
        private float GetPrecision()
            => truePositive + falsePositive == 0 ? 0 :
            truePositive / (float)(truePositive + falsePositive);

        // Вычисление Recall нужно для вычисления F1
        private float GetRecall()
            => truePositive + falseNegative == 0 ? 0 :
            truePositive / (float)(truePositive + falseNegative);

        // Вычисление F1
        public float GetF1()
            => GetPrecision() + GetRecall() == 0 ? 0 : 
            (float)(2 * GetPrecision() * GetRecall()) /  (GetPrecision() + GetRecall());
    }
}
