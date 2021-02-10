using System;
using System.Threading;

namespace DreamSimulator
{
    class Program
    {
        static int ThreadCount;
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            Max results = new Max();
            Console.WriteLine("How Many 100 Million Iterations do you want");
            string Iterations = Console.ReadLine();
            int it = Convert.ToInt32(Iterations);
            Thread t = new Thread(() => Compute(it, results));
            t.Start();
            t.Join();
            while(t.IsAlive && ThreadCount != 0)
            {
            }
            Console.WriteLine("Execution Finished");
            TimeSpan ts = DateTime.Now - startTime;
            Console.WriteLine($"Time Taken : {ts.TotalSeconds}");
            Console.ReadLine();
        }
        public static void Compute(int it, Max results)
        {
            ThreadCount++;
            for (int i = 0; i < it; i++)
            {
                Thread t = new Thread(() => Million(ref results));
                t.Start();
                if (i == it - 1)
                {
                    t.Join();
                }
            }
            ThreadCount--;
        }
        public static void Million(ref Max result)
        {
            ThreadCount++;
            bool[] Enderpearls = new bool[262];
            bool[] Blazerods = new bool[305];
            int E = 0;
            int B = 0;
            int Emax = 0;
            int Bmax = 0;
            Random Rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            for (int i = 0; i < 100000000; i++)
            {
                int Randomnum = Rand.Next();
                if (Randomnum % 423 < 20 && Enderpearls[i % 262] == false)
                {
                    Enderpearls[i % 262] = true;
                    E++;
                    if (E > Emax)
                    {
                        Emax = E;
                    }
                }
                if (Randomnum % 423 >= 20 && Enderpearls[i % 262] == true)
                {
                    Enderpearls[i % 262] = false;
                    E--;
                }
                if (Randomnum % 2 == 0 && Blazerods[i % 305] == false)
                {
                    Blazerods[i % 305] = true;
                    B++;
                    if (B > Bmax)
                    {
                        Bmax = B;
                    }
                }
                if (Randomnum % 2 == 1 && Blazerods[i % 305] == true)
                {
                    Blazerods[i % 305] = false;
                    B--;
                }
            }
            if(result.SetMaxB(Bmax))
            {
                Console.WriteLine(result.getB() + " Out of 305 Blazerod Drops");
            }
            if(result.SetMaxE(Emax))
            {
                Console.WriteLine(result.getE() + " Out of 262 EnderPearl Trades");
            }
            ThreadCount--;
        }
    }
    public class Max
    {
        int Enderpearl = 0;
        int Blazerods = 0;
        public bool SetMaxE(int newMax)
        {
            if (newMax > Enderpearl)
            {
                Enderpearl = newMax;
                return true;
            }
            return false;
        }
        public int getE() { return Enderpearl; }
        public bool SetMaxB(int newMax)
        {
            if (newMax > Blazerods)
            {
                Blazerods = newMax;
                return true;
            }
            return false;
        }
        public int getB() { return Blazerods; }
    }
}

