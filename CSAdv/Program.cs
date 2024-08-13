using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

    class Needed<T, U> //제너릭
    {
        public T Value1;
        public U Value2;
        public Needed(T value1, U value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }

    class SpecialNeeded<T, U>
        where T : IComparable
        where U : IComparable, IDisposable
    {
        public T Value1;
        public U Value2;
        public SpecialNeeded(T value1, U value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }

    class SquareCalculator
    {
        public int this[int i] //Indexer
        {
            get {return i* i; }
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

            Console.WriteLine("--------------------");

            SquareCalculator s = new SquareCalculator();
            Console.WriteLine(s[255]);

            Console.WriteLine("--------------------");

            Console.Write("숫자 입력: ");
            int output;
            bool result = int.TryParse(Console.ReadLine(), out output); // out
            if (result)
            {
                Console.WriteLine("입력한 숫자: " + output);
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요. " + output);
            }
        }
    }
}
