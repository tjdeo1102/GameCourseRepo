using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Day5_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("숫자 야구");
            //컴퓨터의 정답생성
            Random random = new Random();

            int[] computer_ans = new int[3]; // 각 자리 저장
            while (true) //중복 검사
            {
                int r = random.Next(100, 1000);
                computer_ans[2] = r % 10; //1의 자리
                computer_ans[1] = (r / 10) % 10; //10의 자리
                computer_ans[0] = (r / 100) % 10; //100의 자리
                if ((computer_ans[2] != computer_ans[1]) && (computer_ans[1] != computer_ans[0]) && computer_ans[0] != computer_ans[2]) // 각 자리 중복인지 확인
                {
                    break;
                }
            }
            //중복 숫자 처리
            for (int i = 1; i <= 11; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=========================");
                Console.WriteLine($"\t{i}이닝 시작\t");
                Console.WriteLine("=========================");
                Console.ForegroundColor = ConsoleColor.Gray;


                int[] user_ans = new int[3];
                Console.WriteLine("임의의 중복되지 않고 1~9로 표현되는 세자리 숫자를 입력해주세요! \n (Ex. 172)");

                while (true) //입력 예외 처리
                {
                    bool isCorrect = int.TryParse(Console.ReadLine(), out int num);

                    if (isCorrect) //잘못된 입력 예외 처리
                    {
                        if (num >= 100 && num < 1000)
                        {
                            user_ans[2] = num % 10; //1의 자리
                            user_ans[1] = (num / 10) % 10; //10의 자리
                            user_ans[0] = (num / 100) % 10; //100의 자리
                            if ((user_ans[2] != user_ans[1]) && (user_ans[1] != user_ans[0]) && user_ans[0] != user_ans[2]) // 각 자리 중복인지 확인
                            {
                                break;
                            }
                            Console.WriteLine("중복되지 않는 숫자를 입력하세요");
                            continue;
                        }
                        Console.WriteLine("올바른 세자리의 숫자를 입력하세요");
                        continue;
                    }
                    Console.WriteLine("잘못된 입력입니다.\n (Ex. 172)");
                }

                int strike = 0;
                int ball = 0;
                for (int j=0; j<computer_ans.Length; j++)
                {
                    for (int k = 0; k < user_ans.Length; k++)
                    {
                        if (computer_ans[j] == user_ans[k]) //숫자 맞은 경우
                        {
                            if (j == k) // 자리까지 맞는 경우 스트라이크
                            {
                                strike++;
                            }
                            else
                            {
                                ball++;
                            }
                        }
                    }
                }
                if (strike >0 || ball >0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (strike == 3)
                    {
                        Console.WriteLine("유저의 승리");
                        return;
                    }
                    Console.WriteLine($"{strike}스트라이크 {ball}볼");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("아웃");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("컴퓨터의 승리");
            return;
        }
    }
}
