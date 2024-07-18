namespace Day4_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 과제 1. 입력받은 횟수만큼 반복하는 기능 제작
            //while (true)
            //{
            //    Console.WriteLine("몇회 반복하시겠습니까?");
            //    bool is_collect = int.TryParse(Console.ReadLine(), out int num);
            //    if (is_collect)
            //    {
            //        for (int _i = 0; _i < num; _i++)
            //        {
            //            Console.WriteLine($"{_i + 1}회 반복중입니다");
            //        }
            //        break;
            //    }
            //    else //입력 예외 처리
            //    {
            //        Console.WriteLine("잘못된 입력, 끝내려면 Ctrl+C ");
            //    }
            //}
            #endregion

            #region 과제 2. 다수의 입력을 받아 횟수만큼 반복하는 기능 제작
            //while (true)
            //{
            //    Console.WriteLine("두 수 사이의 합을 구합니다. 시작할 작은 수를 입력하여주세요");
            //    bool is_collect_1 = int.TryParse(Console.ReadLine(), out int start_num);
            //    Console.WriteLine("끝 수를 입력해주세요");
            //    bool is_collect_2 = int.TryParse(Console.ReadLine(), out int end_num);
            //    if (is_collect_1 && is_collect_2)
            //    {
            //        long res = 0; // 주어진 정수의 합이 int의 범위를 넘을 수 있기에 long 자료형 사용

            //        //주어진 입력의 시작값과 끝값에 대한 순서 예외처리
            //        int temp;
            //        if (start_num > end_num)
            //        {
            //            temp = start_num; 
            //            start_num = end_num;
            //            end_num = temp;
            //        }

            //        for (int _i = start_num; _i <= end_num; _i++)
            //        {
            //            res += _i;
            //        }
            //        Console.WriteLine($"{start_num}과 {end_num} 사이 숫자의 합은 {res}입니다");
            //        break;
            //    }
            //    else //입력 예외 처리
            //    {
            //        Console.WriteLine("잘못된 입력, 끝내려면 Ctrl+C ");
            //    }
            //}
            #endregion

            #region 과제 3. 구구단 기능 제작
            //while (true)
            //{
            //    Console.WriteLine("출력하고자 하는 구구단을 입력해주시길 바랍니다");
            //    bool is_collect = int.TryParse(Console.ReadLine(), out int num);
            //    if (is_collect)
            //    {
            //        if (num >= 1 && num <= 9)
            //        {
            //            for (int _i = 1; _i <= 9; _i++)
            //            {
            //                Console.WriteLine($"{num}*{_i} = {num * _i}");
            //            }
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("1~9사이의 숫자를 입력해주세요. 끝내려면 Ctrl+C ");
            //        }
            //    }
            //    else //입력 예외 처리
            //    {
            //        Console.WriteLine("잘못된 입력, 끝내려면 Ctrl+C ");
            //    }
            //}
            #endregion

            #region 과제 4. 별찍기 기능 구현
            //while (true)
            //{
            //    Console.WriteLine("출력하고 싶은 별짓기 종류 번호 입력");
            //    bool is_collect = int.TryParse(Console.ReadLine(), out int num);
            //    if (is_collect)
            //    {
            //        if (num == 1) {
            //            for (int i = 0; i<5;i++)
            //            {
            //                for (int j = 0; j<i+1;j++)
            //                {
            //                    Console.Write("*");
            //                }
            //                Console.WriteLine();
            //            }
            //            break;
            //        }
            //        else if (num == 2)
            //        {
            //            for (int i = 0; i < 5; i++)
            //            {
            //                for (int j = 0; j < 4-i ; j++)
            //                {
            //                    Console.Write(" ");
            //                }
            //                for (int j = 0; j < i + 1; j++)
            //                {
            //                    Console.Write("*");
            //                }
            //                Console.WriteLine() ;
            //            }
            //            break;
            //        }
            //        else if (num == 3)
            //        {
            //            for (int i = 0; i < 5; i++)
            //            {
            //                for (int j = 0; j < 5 - i; j++)
            //                {
            //                    Console.Write("*");
            //                }
            //                Console.WriteLine();
            //            }
            //            break;
            //        }
            //        else if (num == 4)
            //        {
            //            for (int i = 0; i < 5; i++)
            //            {
            //                for (int j = 0; j < i; j++)
            //                {
            //                    Console.Write(" ");
            //                }
            //                for (int j = 0; j < 5 - i; j++)
            //                {
            //                    Console.Write("*");
            //                }
            //                Console.WriteLine();
            //            }
            //            break;
            //        }
            //    }
            //    else //입력 예외 처리
            //    {
            //        Console.WriteLine("잘못된 입력, 끝내려면 Ctrl+C ");
            //    }
            //}
            #endregion

            #region 심화 과제 1. 조건에 따른 무한 반복 기능
            //while (true)
            //{
            //    Console.WriteLine("1. 마을");
            //    Console.WriteLine("2. 사냥터");
            //    Console.WriteLine("3. 상점");

            //    Console.WriteLine("이동 할 장소를 설정해주세요");

            //    int toDetermine;
            //    bool incorrectInput = false;
            //    incorrectInput = int.TryParse(Console.ReadLine(), out toDetermine);

            //    if (incorrectInput == false)
            //    {
            //        while (incorrectInput == false)
            //        {
            //            Console.WriteLine("제대로 된 입력을 다시 해주세요");
            //            incorrectInput = int.TryParse(Console.ReadLine(), out toDetermine);
            //        }

            //    }

            //    Console.Clear();

            //    switch (toDetermine)
            //    {
            //        case 1:
            //            Console.WriteLine("마을로 이동하였습니다");
            //            break;
            //        case 2:
            //            Console.WriteLine("사냥터로 이동하였습니다");
            //            break;
            //        case 3:
            //            Console.WriteLine("상점으로 이동하였습니다");
            //            break;
            //        default:
            //            Console.Clear();
            //            Console.WriteLine("1,2,3 어느것도 아니에요");
            //            Console.WriteLine("올바른 숫자를 입력해주세요");
            //            break;
            //    }
            //}
            #endregion

            #region 심화 과제 2. 입력을 통한 다이아몬드 출력 기능 구현
            Console.WriteLine("출력할 다이아몬드를 홀수로 입력");
            while (true)
            {
                bool is_correct = int.TryParse(Console.ReadLine(), out int num);

                if (is_correct)
                {
                    if (num == 1)
                    {
                        Console.WriteLine("1이 아닌값을 입력하세요");
                    }
                    else if (num % 2 == 0)
                    {
                        Console.WriteLine("홀수를 입력하세요");
                    }
                    else
                    {
                        int mid = num / 2;
                        for (int _i = 0; _i<= mid;_i++)
                        {
                            for(int _j = mid - _i; _j>0 ;_j--)
                            {
                                Console.Write(" ");
                            }
                            Console.Write("*");
                            for(int _j = 0; _j < _i; _j++)
                            {
                                Console.Write("**");
                            }
                            Console.WriteLine();
                        }
                        for (int _i = 0; _i < mid; _i++)
                        {
                            for (int _j = 0; _j < _i+1; _j++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write("*");
                            for (int _j = 0; _j < mid - _i - 1 ; _j++)
                            {
                                Console.Write("**");
                            }
                            Console.WriteLine();

                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력");
                }
            }
            #endregion
        }
    }
}
