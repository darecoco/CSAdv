using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAdv
{
    class Wanted<T> //Generic T -> U -> V ....
    {
        public T Value;
        public Wanted(T value)
        {
            Value = value;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Wanted<string> wantedString = new Wanted<string>("String");
            Wanted<int> wantedInt = new Wanted<int>(9090);
            Wanted<double> wantedDouble = new Wanted<double>(21.457);

            Console.WriteLine(wantedString.Value);
            Console.WriteLine(wantedInt.Value);
            Console.WriteLine(wantedDouble.Value);
        }
    }
}
