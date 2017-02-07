using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace QueueSystem
{
    class Program
    {
        private int _currentTicket = 5;
        private int _highestQueuNumber = 5;
        private int _customerInterval = 1000;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
    }

        public void Run()
        {
            Thread t1 = new Thread(new ThreadStart(DoCurrentTicket));
            Thread t2 = new Thread(new ThreadStart(DoNewCustomer));
            t1.Start();
            t2.Start();
            
        }

        public void DoCurrentTicket()
        {
            while (true)
            {
                HandleCurrentTicket();
                
            }
        }

        public void DoNewCustomer()
        {
            while (true)
            {
                NewCustomer();
            }
        }

        public void HandleCurrentTicket()
        {
            if (_currentTicket > _highestQueuNumber)
            {
                Console.WriteLine("No Customers Currently.");
                Thread.Sleep(2000);
            }
          
            else
            {
                Console.WriteLine("Currently handling Ticket number: " + _currentTicket);
                Console.WriteLine("Next Ticket: " + (_currentTicket + 1));
                Thread.Sleep(2000);
                _currentTicket++;
            }
            
        }

        public void NewCustomer()
        {
            _highestQueuNumber++;
            Console.WriteLine("A Customer arrived.");
            Thread.Sleep(_customerInterval);

        }


    }
}
