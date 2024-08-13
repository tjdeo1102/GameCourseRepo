using ConsoleProject.Mangers;

namespace ConsoleProject
{
    internal class Program
    {
        public static SoundManager manager = SoundManager.Instance();
        public static void LoadResources()
        {
            manager.AddSound("test", "C:\\Users\\master\\Desktop\\KDT\\GameCourseRepo\\콘솔 프로젝트\\ConsoleProject\\Musics\\Alone Color_Out.wav");
            manager.PlaySound("test");
        }
        static void Main(string[] args)
        {
            LoadResources();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }
            }
        }
    }
}
