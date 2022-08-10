// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Runtime.InteropServices;
using RandomJelly_Classes; 


namespace RandomJelly_Classes
{
    class Program
    {
        readonly protected static string originalImagePath = "./../../../selenium-screenshot.png";
        readonly protected static string croppedImagePath = "./../../../selenium-screenshot-cropped.png";
        static void Main(string[] args)
        { 
            if(!File.Exists(originalImagePath))
            {
                var webCrawler = new WebCrawler();
                webCrawler.GrabSceenshotEmbeded();
           
                Image screenshot = Image.FromFile(originalImagePath);

                Rectangle cropBounds = new Rectangle(0, 75, 800, 450);
                Image croppedImage = cropImage(screenshot,cropBounds);
                croppedImage.Save("./../../../selenium-screenshot-cropped.png"); 
            }
            else
            {
                //Kilde for effektiv looping av bitmap: https://stackoverflow.com/questions/6020406/travel-through-pixels-in-bmp
                Console.WriteLine("Hentet ikke ny screenshoot, fantes fra før"); 

                Bitmap bitmap = new Bitmap(croppedImagePath);
                PixelCalculator pixelCalculator = new PixelCalculator();
                ulong seed = pixelCalculator.CalculateSeed(bitmap);
                Console.WriteLine(seed);
                LFSR lfsr = new LFSR(seed);
                lfsr.GenerateStream(5000);
                             
            }
            
            Console.WriteLine("Program avsluttes med utførelse"); 
                  
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        //Kilde: https://stackoverflow.com/questions/5283180/how-can-i-convert-bitarray-to-single-int

    }
}
