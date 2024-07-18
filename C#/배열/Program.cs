using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Day5_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 과제 1. 고정 배열 생성 및 출력
            //int[] int_arr = new int[4];
            //for (int i= 1; i <= int_arr.Length; i++)
            //{
            //    Console.WriteLine($"{i}번 요소를 입력하여주십시오");
            //    while (!int.TryParse(Console.ReadLine(), out int_arr[i-1]))
            //    {
            //        Console.WriteLine("잘못된 입력이므로 다시 입력해주세요.");
            //    }
            //}
            //Console.WriteLine("입력된 요소는 다음과 같습니다");

            //foreach (int i in int_arr)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region 과제 2. 배열의 요소 변경 및 출력
            //int[,] int_arr = new int[4,4];
            //for (int i = 1; i <= int_arr.Length; i++)
            //{
            //    int_arr[(i - 1) / 4, (i - 1) % 4] = i*3;
            //}
            //int temp = int_arr[2, 3];
            //int_arr[2,3] = int_arr[3, 2];
            //int_arr[3, 2] = temp;

            //Console.WriteLine("입력된 요소는 다음과 같습니다");
            //foreach (int i in int_arr)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region 심화 과제 1. 유저의 요구사항에 맞는 배열 및 기능 제작
            int inven_size = 0;
            string[] inven;
            Console.WriteLine("원하는 인벤토리의 크기를 입력하세요");
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out inven_size))
                {
                    Console.WriteLine("잘못된 입력이므로 다시 입력해주세요.");
                }
                if (inven_size < 1 || inven_size > 10)
                {
                    Console.WriteLine("숫자 범위 1~10사이로 입력해주세요.");
                }
                else
                {
                    Console.WriteLine($"{inven_size}개 만큼의 인벤토리가 생성되었습니다");
                    inven = new string[inven_size];
                    for (int i = 0; i<inven.Length;i++)
                    {
                        inven[i] = Console.ReadLine();
                    }
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("열람을 원하는 번호를 입력해주시기 바랍니다.");
                int inven_idx = -1;
                while (!int.TryParse(Console.ReadLine(), out inven_idx))
                {
                    Console.WriteLine("잘못된 입력이므로 다시 입력해주세요.");
                }
                if (inven_idx == 0) return; // 0 입력시 종료

                if (inven_idx < 1 || inven_idx > 10)
                {
                    Console.WriteLine("숫자 범위 1~10사이로 입력해주세요.");
                }
                else
                {
                    if (inven[inven_idx-1] == "")
                    {
                        Console.WriteLine("칸이 비었습니다. 값을 입력하세요");
                        continue;
                    }
                    Console.WriteLine($"{inven[inven_idx-1]}");
                }
            }

            #endregion
        }
    }
}
