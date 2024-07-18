namespace _1_SpecificOutputByCondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("성공한 갯수를 입력하여 주세요");
            bool isRight = int.TryParse(Console.ReadLine(), out num);
            if (isRight)
            {
                if (num >= 100)
                {
                    Console.WriteLine("SS 등급입니다");
                }
                else if (num >= 90)
                {
                    Console.WriteLine("S등급 입니다");
                }
                else if (num >= 70)
                {
                    Console.WriteLine("A등급 입니다");
                }
                else if (num >= 40)
                {
                    Console.WriteLine("B등급 입니다");
                }
                else
                {
                    Console.WriteLine("F등급 입니다");
                }
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}
