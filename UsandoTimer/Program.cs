using System;
using System.IO;
using System.Threading;

namespace UsandoTimer
{
    class TimerExample
    {
        static public void Tick(Object stateInfo)
        {
            var tick = $"Tick: {DateTime.Now.ToString("hh:mm:ss")}";
            Console.WriteLine(tick);
            RecordFile(tick);
        }

        static void Main()
        {
            TimerCallback callback = new TimerCallback(Tick);

            Console.WriteLine("Creating timer: {0}\n",
                               DateTime.Now.ToString("hh:mm:ss"));

            // create a one minute timer tick
            Timer stateTimer = new Timer(callback, null, 0, 60000);

            string folder = @"C:\Users\Public\Log"; //nome do diretorio a ser criado

            //Se o diretório não existir...
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            // loop here forever
            for (;;)
            {
                // add a sleep for 100 mSec to reduce CPU usage
                Thread.Sleep(100);
            }
        }

        static void RecordFile(string text)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Public\Log\logBateria.txt", true))
            {
                file.WriteLine(text);
            }

            Console.ReadKey();
        }
    }
}
