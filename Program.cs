using System.Runtime.ConstrainedExecution;

namespace ERScaling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Base damage -> int
            // Upgrade Mod for 25 -> double
            // Str scaling -> int
            // Upgrade Mod * Str scaling -> double
            //
            {
                double StrScaling = 59;
                double UpMod = 2.2; //2.35;
                double UpStrMod = 2.6;
                double BaseDamage25 = 133 * UpMod; //292; //Math.Floor(133 * UpMod);
                Console.WriteLine("BASE:" + BaseDamage25);

                double ScalingDam = (StrScaling * UpStrMod) / 100;
                double e = GetRatio(50);

                double f = BaseDamage25 * e * ScalingDam;


                Console.WriteLine("SCALING: " + f);
                Console.WriteLine("TOTAL AR: " + (f + BaseDamage25));
            }
            {
                double StrScaling = 59;
                double UpMod = 2.2; //2.35;
                double UpStrMod = 2.6;
                double BaseDamage25 = 133 * UpMod; //292; //Math.Floor(133 * UpMod);
                Console.WriteLine("BASE:" + BaseDamage25);

                double ScalingDam = (StrScaling * UpStrMod) / 100;
                double e = GetRatio(50 * 1.5);

                double f = BaseDamage25 * e * ScalingDam;


                Console.WriteLine("SCALING: " + f);
                Console.WriteLine("TOTAL AR: " + (f + BaseDamage25));
            }

        }
        static double GetRatio(double input)
        {
            const int Stat0 = 1;
            const int Stat1 = 20;
            const int Stat2 = 60;
            const int Stat3 = 80;
            const int Stat4 = 150;

            const int Grow0 = 0;
            const int Grow1 = 35;
            const int Grow2 = 75;
            const int Grow3 = 90;
            const int Grow4 = 110;

            const double Exp0 = 1.2;
            const double Exp1 = -1.2;
            const double Exp2 = 1;
            const double Exp3 = 1;
            const double Exp4 = 1;


            double Exp = 0;
            int MinStat = 0;
            int MaxStat = 0;

            int MinGrowth = 0;
            int MaxGrowth = 0;

            double n = 0;

            if (input > Stat0 && input < Stat1)
            {
                MinStat = Stat0;
                MaxStat = Stat1;
                MinGrowth = Grow0;
                MaxGrowth = Grow1;
                Exp = Exp0;

            }
            else if (input > Stat1 && input < Stat2)
            {
                MinStat = Stat1;
                MaxStat = Stat2;
                MinGrowth = Grow1;
                MaxGrowth = Grow2;
                Exp = Exp1;
            }
            else if (input > Stat2 && input < Stat3)
            {
                MinStat = Stat2;
                MaxStat = Stat3;
                MinGrowth = Grow2;
                MaxGrowth = Grow3;
                Exp = Exp2;
            }
            else if (input > Stat3 && input < Stat4)
            {
                MinStat = Stat3;
                MaxStat = Stat4;
                MinGrowth = Grow3;
                MaxGrowth = Grow4;
                Exp = Exp3;
            }
            else if (input > Stat4)
            {
                Console.WriteLine("ERROR");
                Exp = Exp4;
            }

            double a = (input - MinStat);
            double b = (MaxStat - MinStat);

            double Ratio = a / b;
            Console.WriteLine("RATIO:" +Ratio);
            if (Exp > 0) n = Math.Pow(Ratio, Exp);

            if (Exp < 0) n = 1 - (Math.Pow((1 - Ratio), Math.Abs(Exp)));


            int c = (MaxGrowth - MinGrowth);
            double Out = MinGrowth + c * n;
            return Out / 100;
        }
    }
}