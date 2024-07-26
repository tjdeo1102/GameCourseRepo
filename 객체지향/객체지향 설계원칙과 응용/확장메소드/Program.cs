using static OOP_Day4.Program;

namespace OOP_Day4
{
    #region 과제 1. 유효한 아이디 검증
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("아이디를 입력하세요 : ");
            string id = Console.ReadLine();

            if (id.IsAllowedID())
            {
                Console.WriteLine("ID가 유효합니다.");
            }
            else
            {
                Console.WriteLine("ID에 허용되지 않는 특수문자가 있습니다.");
            }
        }
    }

    public static class StringExtension
    {
        public static bool IsAllowedID(this string originStr)
        {
            foreach (char c in originStr)
            {
                switch (c)
                {
                    case '!': return false;
                    case '@': return false;
                    case '#': return false;
                    case '$': return false;
                    case '%': return false;
                    case '^': return false;
                    case '&': return false;
                    case '*': return false;
                    default: break;
                }
            }
            return true;
        }
    }
    #endregion

}
