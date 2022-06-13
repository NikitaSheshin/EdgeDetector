using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SobelDetector
    {
        Mat mat;
        int height, width;

        public SobelDetector(String fileName)
        {
            this.mat = Cv2.ImRead(fileName, ImreadModes.Grayscale);
            height = mat.Height;
            width = mat.Width;
        }

        public double[,] Detect()
        {
            double[,] image = new double[height, width];

            for (int i = 0; i < height; ++i)
                for (int j = 0; j < width; ++j)
                {
                    Vec3b pixel = this.mat.At<Vec3b>(i, j);
                    image[i, j] = pixel[2];
                }

            double[,] resImg = FindGradients(image);
            
            return resImg;
        }

        private double[,] HorizontalGradient(double[,] smoothedImage)
        {
            double[,] sobel_gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            double[,] horizontal_gradient = new double[height, width];

            for (int row = 0; row < height; ++row)
                for (int col = 0; col < width; ++col)
                {
                    if ((0 <= row && row < 4) || (height - 4 <= row && row <= height - 1)
                        || (0 <= col && col < 4) || (width - 4 <= col && col <= width - 1))
                        horizontal_gradient[row, col] = 0;

                    else
                    {
                        double x = 0;
                        for (int i = 0; i < 3; ++i)
                            for (int j = 0; j < 3; ++j)
                                x = x + ((smoothedImage[row - 1 + i, col - 1 + j]) * sobel_gx[i, j]);

                        horizontal_gradient[row, col] = x / 3;
                    }
                }

            return horizontal_gradient;
        }

        private double[,] VerticalGradient(double[,] smoothedImage)
        {
            double[,] sobel_gy = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            double[,] vertical_gradient = new double[height, width];

            for (int row = 0; row < height; ++row)
                for (int col = 0; col < width; ++col)
                {
                    if ((0 <= row && row < 4) || (height - 4 <= row && row <= height - 1)
                        || (0 <= col && col < 4) || (width - 4 <= col && col <= width - 1))
                        vertical_gradient[row, col] = 0;

                    else
                    {
                        double x = 0;
                        for (int i = 0; i < 3; ++i)
                            for (int j = 0; j < 3; ++j)
                                x = x + ((smoothedImage[row - 1 + i, col - 1 + j]) * sobel_gy[i, j]);

                        vertical_gradient[row, col] = x / 3;
                    }
                }
            return vertical_gradient;
        }

        private double[,] FindGradients(double[,] smoothedImage)
        {
            double[,] horizontal_gradient = HorizontalGradient(smoothedImage);
            double[,] vertical_gradient = VerticalGradient(smoothedImage);

            for (int row = 0; row < height; ++row)
                for (int col = 0; col < width; ++col)
                {
                    horizontal_gradient[row, col] = Math.Abs(horizontal_gradient[row, col]);
                    vertical_gradient[row, col] = Math.Abs(vertical_gradient[row, col]);
                }


            double[,] gradient_mag = new double[height, width];
            for (int row = 0; row < height; ++row)
                for (int col = 0; col < width; ++col)
                {
                    double x = Math.Pow(horizontal_gradient[row, col], 2);
                    double y = Math.Pow(vertical_gradient[row, col], 2);
                    gradient_mag[row, col] = (Math.Sqrt(x + y) / Math.Sqrt(2));
                }
            return gradient_mag;
        }
    }
}
