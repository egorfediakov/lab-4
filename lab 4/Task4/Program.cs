using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationLicense application = new ApplicationLicense();
            Console.WriteLine("Enter access key");
            try
            {
                application.Key = Convert.ToInt32(Console.ReadLine());
                KeyMethod(application.Key);
            }
            catch
            {

                Console.WriteLine("Wrong passkey. Try again!!");
            }
            Console.ReadKey();
        }
        public static void KeyMethod(int key)
        {
            if (key == 1)
            {
                OppinCommonVers();
            }
            else if (key == 2)
            {
                Trial trial = new Trial();
                trial.AllowTrial();
            }
            else if (key == 3)
            {
                Pro prover = new Pro();
                prover.AllowPro();

            }
            else
            {
                OppinCommonVers();
            }
        }
        public static void OppinCommonVers()
        {
            ApplicationLicense applicationLicense = new ApplicationLicense();
            applicationLicense.AllowCommon();
            Console.WriteLine("Many functions are blocked, the ability to use only free...");
        }
    }
    class ApplicationLicense
    {
        public int Key { get; set; }
        public virtual void AllowTrial()
        {
            Console.WriteLine("Trial mode");
        }
        public void AllowCommon()
        {
            Console.WriteLine("Free version");
        }
        public virtual void AllowPro()
        {
            Console.WriteLine("Pro version");
        }

    }
    class Trial : ApplicationLicense
    {
        public readonly int Duration = 2;
        public override void AllowTrial()
        {
            base.AllowTrial();
            Console.WriteLine($"Free trial mode with some restrictions for {Duration} weeks");
        }
    }
    class Pro : ApplicationLicense
    {
        public readonly int Subscription = 6;
        public override void AllowPro()
        {
            base.AllowPro();
            Console.WriteLine($"All features are available to you, a paid monthly subscription includes full program management");
            Console.WriteLine($"Duration of your subscription = {Subscription} month");
        }

    }
}
