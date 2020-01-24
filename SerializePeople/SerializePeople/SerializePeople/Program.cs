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
            Person bela = new Person("Bela", new DateTime(1991, 06, 19), Genders.Male);
            Console.WriteLine(bela.ToString());
            Console.ReadKey();
        }
    }
}
