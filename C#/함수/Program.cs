namespace Day6_Assignments
{
    internal class Program
    {
        /// <summary>
        /// 과제 1. 다수의 인자값 요구 함수 구현
        /// </summary>
        static void MaxInFourNumbers(int n1,int n2,int n3,int n4)
        {
            int[] four_nums = { n1, n2, n3, n4 };
            int max = n1;
            foreach (int i in four_nums)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            Console.WriteLine(max);
        }

        /// <summary>
        /// 과제 2. 다수의 인자값 및 반환형을 가진 함수 구현
        /// </summary>
        static float MaxInFiveNumbers(float n1, float n2, float n3, float n4, float n5)
        {
            float[] five_nums = { n1, n2, n3, n4, n5 };
            float first_max=n2, second_max=n1;
            if (n1 > n2)
            {
                first_max = n1;
                second_max = n2;
            }
            for (int i=2; i< five_nums.Length; i++) //n1,n2에 대한 비교는 끝났으므로 i는 2부터 시작
            {
                if (five_nums[i] > first_max)
                {
                    // 가장 큰수보다 크면, 자연스럽게 기존 큰수는 두번째 큰수
                    second_max = first_max;
                    first_max = five_nums[i];
                }
                else if (five_nums[i] > second_max)
                { 
                    second_max = five_nums[i];
                }
            }
            return first_max+second_max;
        }

        /// <summary>
        /// 과제 3. 특정 조건을 포함한 함수 제작
        /// </summary>
        static bool DiffTwoNumbers(int n1,int n2)
        {
            int max_i=n1, min_i=n2;
            if (n1 < n2)
            {
                max_i = n2;
                min_i = n1;
            }
            return ((max_i - min_i) / 100) < 1;
        }

        /// <summary>
        /// 심화 과제 1. 복합조건을 가진 함수 제작
        /// 1. 입력된 값을 3으로 나눈 몫을 1부터 전부 더하고, 3을 곱함
        /// 2. 5의 경우도 같은 과정
        /// 3. 15의 경우도 같은 과정
        /// 4. 1,2의 값을 더한 후, 15의 배수가 중복해서 더해졌으므로 3을 한번 빼기
        /// * 정수형의 합이 int의 범위를 넘어갈 수 있으므로 long으로 반환
        /// </summary>
        static long ComplexConditonSum(int n)
        {
            long sum_3 = (n/3) * (n / 3 + 1) / 2 * 3; // 1부터 n/3까지의 합 공식 * 3
            long sum_5 = (n/5) * (n / 5 + 1) / 2 * 5; // 1부터 n/5까지의 합 공식 * 5
            long sum_15 = (n / 15) * (n / 15 + 1) / 2 * 15; // 1부터 n/15까지의 합 공식 * 15
            return sum_3 + sum_5 - sum_15;
        }

        /// <summary>
        /// 심화 과제 2. 자릿수 합 디코더 제작
        /// 1. do while을 이용하여 먼저, 나머지 연산으로 자릿수를 더함
        /// 2. while 조건에서, 해당 수를 10씩 나누어, 몫이 0이 되는 순간 반복문 탈출
        /// </summary>
        static int DigitsSum(int n)
        {
            int sum = 0;
            do
            {
                sum += n % 10;
                n/= 10;
            } while (n!=0);
            return sum;
        }

        /*
        심화 과제 3. 재귀함수 조사
        재귀 함수: 함수 내에 자기 자신의 함수를 호출하는 함수
        꼬리 재귀: 재귀 호출이 끝날 때, 다른 연산을 하지않고 바로 반환해주는 것 (ex. return recursion(n,n-1); || 일반 재귀의 경우 return n * recursion(n-1); )
        문제점: 
        1. 계층이 깊어질수록, 스택 메모리를 많이 차지하면서 스택 오버플로우의 위험 존재
        2. 함수를 이용한 재귀의 경우, 오버헤드의 문제
         */


        /// <summary>
        /// 심화 과제 4. 피보나치 함수 제작
        /// 1. 종료 조건은 입력된 정수 n이 1,2인 경우 1을 반환하며 종료
        /// 2. 입력된 정수 n에 대해, n-1, n-2번째의 값을 반환하도록 설계
        /// 3. 추후, Memoization기법을 적용할 필요 존재
        /// *반환값이 int의 범위를 넘어갈 수 있으므로 long으로 설정
        /// </summary>
        static long Fibo(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            return Fibo(n-1) + Fibo(n-2);
        }

        /*
        심화 과제 5. main문 조사
        Main문 내의 args 배열은 프로그램을 시작하면서 전달되는 매개변수(ex. main.exe를 실행하는 경우: main.exe arg1 arg2)들을 전달받는 역할을 한다.
        해당 args에서는 전달받는 매개변수들을 공백을 기준으로 분류하며, 매개변수 순서대로, args의 배열의 값으로 담긴다.
         */



        static void Main(string[] args)
        {
            Console.WriteLine(Fibo(20));
        }
    }
}
