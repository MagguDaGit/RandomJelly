using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RandomJelly_Classes
{
    class PixelCalculator
    {


        public ulong CalculateSeed(Bitmap bitmap)
        {
            ulong seed = 0;
            string binaryString = "";
           
            //Loop gjennom hele bildet
            int teller = 0;
            for(int y = 0; y < bitmap.Height-2; y += bitmap.Height/8)
            {
                for(int x = 0; x < bitmap.Width; x += bitmap.Width/8)
                {
                    teller++;
                    // Steg 1: Velg rute som tilsvarer 5265px 
                    Rute rute = new Rute(bitmap, x, y, teller);

                    //Steg 2: Inneholder ruten nokk farger til å si manet befinner seg i ruten 
                    //Steg 3: Lagre resultat i en datatype 

                    if (rute.ContainsJelly())
                    {
                        binaryString = "1" + binaryString;
                       
                    }
                    else
                    {
                        binaryString = "0" + binaryString;
                      
                    }

                }
                //Steg 5: Gå til steg 1, velg ny rute || Hvis alle ruter er gått gjennom gå videre til 6
            }
          
            //Steg 6: Alle ruter er gått gjennom kalkuler verdi av 64bit / 2 - 1 (Dette er fordi max Long verdi er halvparten av 64 bit max)
            //Konverterer binær tekst til en ulong 
            seed = Convert.ToUInt64(binaryString,2);

            return seed;

        }

        protected class Rute
        {
            List<Pixel> pixelArr = new List<Pixel>();
            int bredde = 100;
            int høyde = 56;
            public int ruteNr;
            public Rute(Bitmap source, int startX, int startY, int ruteNr)
            {
                this.ruteNr = ruteNr;
                int teller = 0;
                for (int i = startY; i < høyde+startY; i++)
                {
                    for (int j = startX; j < bredde+ startX; j++)
                    {
                        //Console.WriteLine("Henter pixel med pos: " + "X=" + j + " Y=" + i  + "Rute nr: " + ruteNr);
                        pixelArr.Add(new Pixel(source.GetPixel(j, i), j, i, teller, ruteNr));
                        teller++;
                    }
                }
                //Console.WriteLine("Pixel nr:" + ruteNr + " inneholder : " + pixelArr.Count); 
               
            }


            // Hjelpemetode 
            public void PrintPixels()
            {
                for(int i = 0; i < pixelArr.Count; i++)
                {
                    Console.WriteLine(pixelArr[i].ToString());   
                }
                Console.WriteLine("Totalt pixler i rute: " + pixelArr.Count);
            }

            bool ColorsAreLogo(Color a, Color z, int threshold = 100)
            {
                int r = (int)a.R - z.R,
                    g = (int)a.G - z.G,
                    b = (int)a.B - z.B;
                return (r * r + g * g + b * b) <= threshold * threshold;
            }


            public bool ContainsJelly()
            {
                
                int antallTreff = 0;
                //Teller antall pixler som er hav
                for(int i = 0; i < pixelArr.Count; i++)
                {
                    if (pixelArr[i].pixelColor.R > 7 && pixelArr[i].pixelColor.R < 100 && pixelArr[i].pixelColor.G < 100 && pixelArr[i].pixelColor.B < 120)
                    {
                        //Console.WriteLine("Fant pixel med glassmanet på pos:" + pixelArr[i].x + ", " + pixelArr[i].y + " i rutenr:" + ruteNr); 
                        antallTreff++;
                    }
                }
               
                return antallTreff > 0;             
            }
        
        
        
        } 


        protected class Pixel
        {
            public Color pixelColor { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            int id { get; set; }
            int ruteNr { get; set; }

            public Pixel(Color pixelColor, int x, int y, int id, int ruteNr)
            {
                this.pixelColor = pixelColor;
                this.x = x;
                this.y = y;
                this.id = id;
                this.ruteNr = ruteNr;
            }

            public override string ToString()
            {
                string s = "Pixel id: " + id + " Pos: x = "+x +" y = "+y +" "+ pixelColor.ToString() + " Tilhører rute nr: " + ruteNr;
                return s;
            }

        }

    }
}
