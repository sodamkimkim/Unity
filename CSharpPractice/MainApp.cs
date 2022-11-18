using System;
namespace Throw
{
    class MainApp
    {
        static void DoSomething(int arg)
        {
            if (arg < 10)
                Console.WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 크다.");
        }
        static void Main(string[] args)
        {
            try
            {
                DoSomething(1);
                DoSomething(1);
                DoSomething(11);
                DoSomething(111);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    } // end of class
} // end of namespace
