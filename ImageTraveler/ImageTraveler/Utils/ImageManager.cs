using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageTraveler
{
    public class ImageManager
    {
        // 如果你想把图片旋转任何角度可以使用System.Drawing.Drawing2D.Matrix类
        /// <summary>
        ///  获得旋转之后的图片对象
        /// </summary>
        /// <param name="bmp">图片对象</param>
        /// <param name="angle">旋转的角度</param>
        /// <param name="bkColor"></param>
        /// <returns></returns>
        //public static Bitmap RotateImg(Bitmap bmp, float angle, Color bkColor)
        //{
        //    // 获得图片的高度和宽度
        //    int width = bmp.Width;
        //    int height = bmp.Height;
        //    // PixelFormat指定图像中每个像素的颜色数据的格式
        //    PixelFormat pixelFormat = default(PixelFormat);
        //    if (bkColor == Color.Transparent)
        //    {
        //        pixelFormat = PixelFormat.Format32bppArgb;
        //    }
        //    else
        //    {
        //        // 获取图像像素格式
        //        pixelFormat = bmp.PixelFormat;
        //    }

        //    Bitmap tempImg = new Bitmap(width, height, pixelFormat);
        //    // 一个 GDI+ 绘图图面
        //    // 创建画布对象
        //    Graphics g = Graphics.FromImage(tempImg);
        //    g.Clear(bkColor);

        //    // 在由坐标对指定的位置，使用图像的原始物理大小绘制指定的图像
        //    g.DrawImageUnscaled(bmp, 1, 1);
        //    g.Dispose();

        //    // 画布路径
        //    GraphicsPath path = new GraphicsPath();
        //    // 向路径添加一个矩形
        //    path.AddRectangle(new RectangleF(0f, 0f, width, height));
        //    // 创建一个单位矩阵
        //    Matrix matrix = new Matrix();
        //    // 沿原点并按指定角度顺时针旋转
        //    matrix.Rotate(angle);

        //    RectangleF rct = path.GetBounds(matrix);
        //    Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pixelFormat);
        //    g = Graphics.FromImage(newImg);
        //    g.Clear(bkColor);
        //    // 平移来更改坐标的原点
        //    g.TranslateTransform(-rct.X, -rct.Y);
        //    g.RotateTransform(angle);
        //    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
        //    g.DrawImageUnscaled(tempImg, 0, 0);
        //    g.Dispose();
        //    tempImg.Dispose();

        //    return newImg;
        //}

        // 獲得預覽圖片文件路徑下的圖片集合
        public static List<string> GetImgCollection(string path)
        {
            string[] imgarray = Directory.GetFiles(path);
            var result = from imgstring in imgarray
                         where imgstring.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                         imgstring.EndsWith("png", StringComparison.OrdinalIgnoreCase) ||
                         imgstring.EndsWith("bmp", StringComparison.OrdinalIgnoreCase) ||
                         imgstring.EndsWith("gif", StringComparison.OrdinalIgnoreCase)
                         select imgstring;
            return result.ToList();
        }

        public static System.Drawing.Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            BitmapSource m = (BitmapSource)imageSource;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb); // 選Format32bppRgb將不帶透明度

            System.Drawing.Imaging.BitmapData data = bmp.LockBits(
            new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            m.CopyPixels(System.Windows.Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);

            return bmp;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
