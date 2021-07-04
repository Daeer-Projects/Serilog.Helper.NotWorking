using System;
using System.Diagnostics;

namespace LogTestApplication
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello.");
            Serilog.Debugging.SelfLog.Enable(message => Debug.WriteLine(message));
            Serilog.Debugging.SelfLog.Enable(Console.Error);

            var logTester = new LogTester();

            logTester.LogSystemMessage("Hello from the main application.");
            logTester.LogSystemMessage("Still in the main application...");

            logTester.LogLocationMessage("We have changed location.  Can you see it?");
            var exception = new Exception("Um, not sure about this exception being here!");
            logTester.LogLocationMessage($"We had an exception - {exception.Message}");

            logTester.LogOptionMessage("The user chose something...");

            //logTester.LogSimpleMessage("I don't think this will work either!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
