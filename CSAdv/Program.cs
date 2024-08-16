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
        struct Point
        {
            public int x;
            public int y;
            public string testA;
            public string testB;
            //public string testB = "init"; //구조체 내 변수는 선언과 동시에 초기화 불가능

            //public Point() {} //구조체 -> 기본생성자 정의 불가능
            // 왜 정의가 불가능한가? class는 오버라이드가 되지만 구조체는 그런거 없다.
            // 그래서 이미 자동으로 만들어진 기본생성자가 있기 때문에 또 기본생성자를 정의할 수 없다.

            public Point(int x, int y) // 구조체 생성자 -> 모든 변수 초기화 해주어야 함
            {
                this.x = x;
                this.y = y;
                testA = "initA";
                testB = "initB";
            }
        }

        static void NextPos(int x, int y, int vx, int vy, out int rx, out int ry)
        {
            rx = x + vx;
            ry = y + vy;
        }

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

            int x = 0;
            int y = 0;
            int vx = 1;
            int vy = 1;

            Console.WriteLine("현재좌표 x: {0}, y: {1}", x, y);
            NextPos(x, y, vx, vy, out x, out y);
            Console.WriteLine("다음좌표 x: {0}, y: {1}", x, y);

            //Point 구조체 실습
            Point point; // 구조체 변수 선언. 0바이트 집합
            point.x = 10; //구조체 변수는 반드시 초기화 해야한다. (안 할 시 컴파일 에러)
            point.y = 10;
            Console.WriteLine("point.x: {0}, point.y: {1}", point.x, point.y);
        }
    }
}
