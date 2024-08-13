using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace ConsoleProject.Mangers
{
    //싱글턴
    public class SoundManager
    {
        private static SoundManager instance;
        private SoundPlayer Player = new();
        private Dictionary<string,string> sounds = new();

        // 외부에서 직접 인스턴스 못하도록 막기
        private SoundManager() { }

        // 인스턴스라는 메소드로 SoundManger인스턴스 관리
        public static SoundManager Instance()
        {
            if (instance == null) instance = new SoundManager();
            return instance;
        }

        private bool _IsValidSound(string name , string path)
        {
            if (File.Exists(path) == true)
            {
                if (Path.GetExtension(path) != ".wav")
                {
                    Console.WriteLine("사운드 확장자는 wav만 지원됩니다.");
                    return false;
                }
                return true;
            }
            Console.WriteLine("해당 경로에 사운드가 존재하지 않습니다.");
            return false;
        }

        public void AddSound(string name, string path)
        {
            if (_IsValidSound(name, path) == false) return;
            sounds[name] = path;
        }

        public void PlaySound(string name)
        {
            if (sounds.ContainsKey(name) == true)
            {
                if (_IsValidSound(name, sounds[name]) == false) return;
                Player.SoundLocation = sounds[name];
                Player.Load();
                Player.Play();
                return;
            }
            Console.WriteLine("추가된 사운드가 아닙니다.");
            return;
        }

        public void StopSound()
        {
            Player.Stop();
        }
    }
}
