using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomJelly_Classes
{
    class LFSR 
    {
        ulong seed;
       
        public LFSR(ulong seed)
        {
            this.seed = seed;
        }


        //Kilde: https://github.com/xudonax/LFSR-RNG-CS/blob/master/ConsoleApplication1/LinearFeedbackShiftRegister.cs
        public  void  GenerateStream(ulong streamlength)
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string file = projectDirectory + "/output.txt";
            using StreamWriter sw = new(file, append: true);
            ulong state = seed;
            ulong count = 0;
            if(!File.Exists(file))
            {
                Console.WriteLine(file);
                File.Create(file);
            }
            if (File.Exists(file))
            {
                Console.WriteLine("Output fil finnes fra før");
                
            }

            
            
            //hver iteasjon genererer 20 * streamlenght tall
            do
            {
                // Get the bits at position 60, 61, 63 and 64:
                var bit60 = (state & (1uL << 4 - 1)) != 0;
                var bit61 = (state & (1uL << 3 - 1)) != 0;
                var bit63 = (state & (1uL << 1 - 1)) != 0;
                var bit64 = (state & (1uL << 0 - 1)) != 0;

                // XOR 64 with 63, that with 61 and that with 60
                var immediate1 = bit64 ^ bit63;
                var immediate2 = immediate1 ^ bit61;
                var immediate3 = immediate2 ^ bit60;
                var shiftMeIn = (immediate3 ^ bit60 ? 1uL : 0uL) & 1;

                // Shift the bit into shiftRegister
                state = (state >> 1) | (shiftMeIn << 63);

                // Let's see what the period is
                count++;


                //Console.WriteLine(state);
                try
                {
                    string numberstring = state.ToString();
                    if(count % 20 == 0) sw.Write("\n");
                    sw.Write(numberstring);

                    //File.WriteAllText("output.txt", state.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                
                if (count == streamlength)
                {
                    Console.WriteLine("Nådde enden av stream lenght, slutter utregning");                  
                    return;
                }
            }
            while (state != seed || count < streamlength);            
        }

    }
}
