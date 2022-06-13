using OpenCvSharp;

//Mat img = Cv2.ImRead("A:\\Papka\\2.jpg", ImreadModes.Grayscale);
var img = Cv2.ImRead("A:\\Papka\\2.jpg", ImreadModes.Grayscale);

int height = img.Height;
int width = img.Width;

double[,] image = new double[height, width];

for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
    {
        Vec3b pixel = img.At<Vec3b>(i, j);
        image[i, j] = pixel[2];
    }

// Step1

double[,] gaussian_mask =
        {
            { 1, 1, 2, 2, 2, 1, 1 },
            { 1, 2, 2, 4, 2, 2, 1 },
            { 2, 2, 4, 8, 4, 2, 2 },
            { 2, 4, 8, 16, 8, 4, 2 },
            { 2, 2, 4, 8, 4, 2, 2 },
            { 1, 2, 2, 4, 2, 2, 1 },
            { 1, 1, 2, 2, 2, 1, 1 }
        };

double[,] convoluted_gaussian_arr = new double[height, width];

for (int row = 0; row < height; ++row)
    for (int col = 0; col < width; ++col)
    {
        double x = 0;
        if ((0 <= row && row < 3) || (height - 3 <= row && row <= height)
            || (0 <= col && col < 3) || (width - 3 <= col && col < width))
            convoluted_gaussian_arr[row, col] = 0;
        else
        {
            x = 0;


            for (int k = 0; k < 7; ++k)
                for (int l = 0; l < 7; ++l)
                    x = x + (image[row - 3 + k, col - 3 + l] * gaussian_mask[k, l]);

            convoluted_gaussian_arr[row, col] = x / 140;
        }
    }

double[,] resImg = convoluted_gaussian_arr;
image = convoluted_gaussian_arr;
Mat mat = img;
double[,] smoothed_image = convoluted_gaussian_arr;


// Step2

double[,] sobel_gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
double[,] sobel_gy = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

double[,] horizontal_gradient = new double[height, width];
double[,] vertical_gradient = new double[height, width];

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
                    x = x + ((smoothed_image[row - 1 + i, col - 1 + j]) * sobel_gx[i, j]);

                horizontal_gradient[row, col] = x / 3;
        }
    }

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
                    x = x + ((smoothed_image[row - 1 + i, col - 1 + j]) * sobel_gy[i, j]);

            vertical_gradient[row, col] = x / 3;
        }
    }


double[,] gradient_angle = new double[height, width];

for (int row = 0; row < height; ++row)
    for (int col = 0; col < width; ++col)
        if (horizontal_gradient[row, col] == 0)
            gradient_angle[row, col] = 90;
        else
        {
            double x = Math.Atan(vertical_gradient[row, col] / horizontal_gradient[row, col]);
            gradient_angle[row, col] = x * 180 / Math.PI;
        }


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


// Step3

double[,] suppressed_arr = new double[height, width];


for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
        if ((0 <= i && i < 5) || (height - 5 <= i && i <= height - 1)
        || (0 <= j && j < 5) || (width - 5 <= j && j <= width - 1))
            suppressed_arr[i, j] = 0;
        else
        {
            double x = gradient_angle[i, j];
            double y = gradient_mag[i, j];

            if ((-22.5 < x && x <= 22.5) || ((180 >= x && x > 157.5) && (-180 <= x && x <= -157.5)))
            {
                if (y >= gradient_mag[i, j - 1] && y >= gradient_mag[i, j + 1])
                    suppressed_arr[i, j] = (int)Math.Round(y);
            }
            else if ((22.5 < x && x <= 67.5) || (-112.5 >= x && x > -157.5))
            {
                if (y >= gradient_mag[i - 1, j + 1] && y >= gradient_mag[i + 1, j - 1])
                    suppressed_arr[i, j] = (int)Math.Round(y);
            }
            else if ((67.5 < x && x <= 112.5) || (-67.5 >= x && x > -112.5))
            {
                if (y >= gradient_mag[i - 1, j] && y >= gradient_mag[i + 1, j])
                    suppressed_arr[i, j] = (int)Math.Round(y);
            }
            else if ((112.5 < x && x <= 157.5) || (-22.5 >= x && x > -67.5))
            {
                if (y >= gradient_mag[i - 1, j - 1] && y >= gradient_mag[i + 1, j + 1])
                    suppressed_arr[i, j] = (int)Math.Round(y);
            }
        }



// Step4

double maximum_value = -1;

for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
        if (suppressed_arr[i, j] > maximum_value)
            maximum_value = suppressed_arr[i, j];



double high_threshold_ratio = 0.20, low_threshold_ratio = 0.10;

double high_threshold = maximum_value * high_threshold_ratio;
double low_threshold = maximum_value * low_threshold_ratio;

double[,] output_image = new double[height, width];

for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
        if(suppressed_arr[i, j] > high_threshold)
            output_image[i,j] = 255;


for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
        if(suppressed_arr[i, j] < low_threshold)
            output_image[i, j] = 0;

int count = 0;

for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
        if(suppressed_arr[i, j] <= high_threshold && suppressed_arr[i, j] >= low_threshold)
            count++;

int[,] index_weak_edge_pixel = new int[count, 2];
int q = 0;

for (int i = 0; i < height; ++i)
    for (int j = 0; j < width; ++j)
        if (suppressed_arr[i, j] <= high_threshold && suppressed_arr[i, j] >= low_threshold)
        {
            index_weak_edge_pixel[q, 0] = i;
            index_weak_edge_pixel[q, 1] = j;
            q++;
        }
var suppressed_image = suppressed_arr;

for (int i = 0; i < count; ++i)
{
    int x = index_weak_edge_pixel[i, 0];
    int y = index_weak_edge_pixel[i, 1];
    double pixel_gradient = gradient_angle[x, y];

    if (0 < x && x < width && 0 < y && y < height)
    {
        if (((suppressed_image[x - 1, y] > high_threshold) && Math.Abs(
            gradient_angle[x - 1, y] - pixel_gradient) > 45) ||
       ((suppressed_image[x + 1, y] > high_threshold) && Math.Abs(
       gradient_angle[x + 1, y] - pixel_gradient) > 45) ||
((suppressed_image[x, y + 1] > high_threshold) && Math.Abs(
gradient_angle[x, y + 1] - pixel_gradient) > 45) ||
((suppressed_image[x, y - 1] > high_threshold) && Math.Abs(
gradient_angle[x, y - 1] - pixel_gradient) > 45) ||
((suppressed_image[x - 1, y + 1] > high_threshold) && Math.Abs(
gradient_angle[x - 1, y + 1] - pixel_gradient) > 45) ||
((suppressed_image[x - 1, y - 1] > high_threshold) && Math.Abs(
gradient_angle[x - 1, y - 1] - pixel_gradient) > 45) ||
((suppressed_image[x + 1, y - 1] > high_threshold) && Math.Abs(
gradient_angle[x + 1, y - 1] - pixel_gradient) > 45) ||
((suppressed_image[x + 1, y - 1] > high_threshold) && Math.Abs(
gradient_angle[x + 1, y - 1] - pixel_gradient) > 45))
            output_image[x, y] = 255;
    }
}

resImg = output_image;

for (int i = 0; i < height - 2; ++i)
    for (int j = 0; j < width - 2; ++j)
    {
        Vec3b pixel = new Vec3b();
        pixel[0] = (byte)resImg[i, j];
        pixel[1] = (byte)resImg[i, j + 1];
        pixel[2] = (byte)resImg[i, j + 2];
        mat.At<Vec3b>(i, j) = pixel;
    }

Cv2.ImShow("Image in grayscale", mat);
Cv2.WaitKey(0);