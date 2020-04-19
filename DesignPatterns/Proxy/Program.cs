using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        public static void Main(string[] args)
        {
            //CalculateManager calculateManager = new CalculateManager();

            CreditBase calculateManager = new CalculateManagerProxy();

            Console.WriteLine(calculateManager.Calculate());
            Console.WriteLine(calculateManager.Calculate());

            Console.ReadLine();
        }
    }

    public abstract class CreditBase
    {
        public abstract int Calculate();
    }

    public class CalculateManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 0;
            for (int i = 1; i < 10; i++)
            {
                result += i;
            }
            return result;
        }
    }

    class CalculateManagerProxy : CreditBase
    {
        private CalculateManager calculateManager;
        private int cachedValue = 0;

        //public CalculateManagerProxy(CalculateManager calculateManager)
        //{
        //    this.calculateManager = calculateManager;
        //}

        public override int Calculate()
        {
            if(calculateManager == null)
            {
                calculateManager = new CalculateManager();
                cachedValue = calculateManager.Calculate();
                Thread.Sleep(5000);
            }
            return cachedValue;
        }
    }


}
