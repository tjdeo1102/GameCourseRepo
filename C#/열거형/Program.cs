using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Day5_Assignment
{
    internal class Program
    {
        enum Spots
        {
            Contry=1, Battle, Store
        }

        enum States
        {
            idle=1,run,walk,die=9
        }
        static void Main(string[] args)
        {
            #region 과제 1. 열거형 리팩토링
            //Console.WriteLine("이동 할 장소를 설정해주세요");
            //Console.WriteLine($"{(int)Spots.Contry}. 마을");
            //Console.WriteLine($"{(int)Spots.Battle}. 사냥터");
            //Console.WriteLine($"{(int)Spots.Store}. 상점");

            //Spots toDetermine;

            //Enum.TryParse(Console.ReadLine(), out toDetermine);
            //Console.Clear(); //화면을 지워줍니다
            //switch (toDetermine)
            //{
            //    case Spots.Contry:
            //        Console.WriteLine("마을로 이동합니다");
            //        break;
            //    case Spots.Battle:
            //        Console.WriteLine("사냥터로 이동합니다");
            //        break;
            //    case Spots.Store:
            //        Console.WriteLine("상점으로 이동합니다");
            //        break;
            //    default:
            //        Console.WriteLine("1,2,3 어느것도 아니에요");
            //        break;
            //}
            #endregion

            #region 과제 2. 상태를 열거형으로 구현
            Console.WriteLine("행동방식을 선택해주세요");
            Console.WriteLine($"{(int)States.idle}. {States.idle}");
            Console.WriteLine($"{(int)States.run}. {States.run}");
            Console.WriteLine($"{(int)States.walk}. {States.walk}");
            Console.WriteLine($"{(int)States.die}. {States.die}");

            States toDetermine;
         
            while (true)
            {
                while(!Enum.TryParse(Console.ReadLine(), out toDetermine)) 
                { 
                    Console.WriteLine("옳지 못한 입력"); 
                }
                if(Enum.IsDefined(typeof(States), toDetermine))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("옳지 못한 입력");
                }
            }
            Console.Clear(); //화면을 지워줍니다

            Console.WriteLine(toDetermine);
            #endregion
        }
    }
}
