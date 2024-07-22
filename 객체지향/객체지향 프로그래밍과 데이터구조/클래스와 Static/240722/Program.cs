namespace OOP_Day1
{
    internal class Program
    {
        #region 과제 1. 계산기 클래스 만들기
        class MyCalculator
        {
            public double Add(double a, double b)
            {

                return a + b;
            }
            public double Substract(double a, double b)
            {
                return a - b;
            }

            public double Multiply(double a, double b)
            {
                return a * b;
            }
            public double Divide(double a, double b)
            {
                if (b == 0)
                {
                    Console.WriteLine("0으로 나눌 수 없습니다.");
                    return 0;
                }
                return a / b;
            }

            public double Squared(double a, double b)
            {
                return Math.Pow(a, b);
            }

        }
        static void Main(string[] args)
        {
            MyCalculator calculator = new MyCalculator();
        }
        #endregion

        #region 심화과제 1. 디자인 패턴 조사
        /*디자인 패턴이란 반복적으로 생기는 문제를 재사용이 가능한 코드 형태로 작성하는 것이다.  
         *공통적으로 생기는 문제들이 있고, 이를 해결한 방법들도 존재한다. 이런 방법들을 패턴화 하여, 같은 문제가 발생할 때, 이용하게 된다.
         */
        #endregion
        #region 심화과제 2. 싱글톤 패턴 조사
        /*객체를 정적으로 할당하며, 하나의 객체에만 접근하도록 구현되어 있다. 해당 객체는 전역으로 접근할 수 있도록한다.
         * 초기 객체 생성을 하여 정적 메모리에 이미 올렸다면, 이후 호출하는 시간이 짤아진다는 점, 생성자를 다른 곳에서 선언해도 중복 생성되는 것을 방지할 수 있다.
         * 다만, 너무 큰 메모리가 할당되어 프로그램 성능이 저하되는 문제, 프로그램이 복잡해지며 유지보수가 어려워지는 문제가 있다.
         */
        #endregion
    }
}
