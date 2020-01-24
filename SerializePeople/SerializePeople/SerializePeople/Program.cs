using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person bela = Person.Deserialize("Bela.txt");
            Console.WriteLine(bela.ToString());
            Console.ReadKey();
        }
    }
}
