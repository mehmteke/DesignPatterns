using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager _cus = new CustomerManager(new LoggerFactory2());
            _cus.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Web config de kontrol edilerek loglamanın nasıl yapılacağına burda karar verilebilri.
            return new EdLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Web config de kontrol edilerek loglamanın nasıl yapılacağına burda karar verilebilri.
            return new LogfNetLogger();
        }
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public interface ILogger
    {
        void Log();     
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("EdLogger Çalıştı..."); 
        }
    }

    public class LogfNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("LogfNetLogger Çalıştı...");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory = null;

        public CustomerManager (ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Save");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
