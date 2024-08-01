namespace DataStructure_Day1
{
    #region 과제 1. 괄호 검사기
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Stack<char> stack = new Stack<char>();
    //        string s = Console.ReadLine();
    //        foreach (char c in s)
    //        {
    //            switch (c)
    //            {
    //                case '(':
    //                case '[':
    //                case '{':
    //                    stack.Push(c);
    //                    break;
    //                case ')':
    //                    if (stack.TryPeek(out char o_c))
    //                    {
    //                        if (o_c != '(')
    //                        {
    //                            Console.WriteLine("비정상");
    //                            return;
    //                        }
    //                        stack.Pop();
    //                    }
    //                    break;
    //                case ']':
    //                    if (stack.TryPeek(out char o_c2))
    //                    {
    //                        if (o_c2 != '[')
    //                        {
    //                            Console.WriteLine("비정상");
    //                            return;
    //                        }
    //                        stack.Pop();
    //                    }
    //                    break;
    //                case '}':
    //                    if (stack.TryPeek(out char o_c3))
    //                    {
    //                        if (o_c3 != '{')
    //                        {
    //                            Console.WriteLine("비정상");
    //                            return;
    //                        }
    //                        stack.Pop();
    //                    }
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
    //        //스택에 아직도 괄호가 남았다면 비정상
    //        if (stack.Count == 0) Console.WriteLine("정상");
    //        else Console.WriteLine("비정상");
    //    }
    //}
    #endregion

    #region 과제 2. 작업 일정 계산기
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long> res = new List<long>();
            long cumullativeSum = 0;
            Console.WriteLine("프로그램 종료: 숫자 아닌 아무거나 입력");
            while (int.TryParse(Console.ReadLine(),out int input))
            {
                cumullativeSum += input;
                var workDay = cumullativeSum / 8 + 1;
                if (cumullativeSum % 8 == 0) //해당 8시간을 딱 채운경우에도 작업 날짜 1이 증가하는 부분 보정
                {
                    workDay -= 1;
                }
                res.Add(workDay);
            }

            foreach (var item in res)
            {
                Console.Write($"{item} ");
            }
        }
    }
    #endregion
}
