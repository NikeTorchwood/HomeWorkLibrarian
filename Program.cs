using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

namespace HomeWorkLibrarian
{
    public class Program
    {
        static void Main()
        {
            var library = new ConcurrentDictionary<string, int>();
            var librarian = new Librarian(library);
            var consoleService = new ConsoleService(librarian);
            var readerService = new ReadingService(librarian);
            var thread1 = new Thread(readerService.StartReading);
            var thread2 = new Thread(consoleService.StartListening);
            Parallel.Invoke(
                ()=> {
                    while (thread2.IsAlive)
                    {
                        readerService.StartReading();
                    }
                }, thread2.Start
                );
            Console.WriteLine("Конец программы");
            Console.ReadKey();
        }


    }
}