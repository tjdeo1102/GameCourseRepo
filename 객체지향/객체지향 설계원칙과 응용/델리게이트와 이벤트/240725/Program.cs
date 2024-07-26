using static OOP_Day4.Program;

namespace OOP_Day4
{
    internal class Program
    {
        #region 과제 1. 갑옷과 내구도
        public class Player
        {
            private Armor curArmor;
            public Action OnArmorStateChanged;

            public void Equip(Armor armor)
            {
                if (armor == null)
                {
                    Console.WriteLine("잘못된 갑옷 착용");
                    return;
                }

                Console.WriteLine($"플레이어가 {armor.name} 을/를 착용합니다.");
                curArmor = armor;
                OnArmorStateChanged += curArmor.DecreaseDurability;
                curArmor.OnBreaked += UnEquip;
            }

            public void UnEquip()
            {
                if (curArmor == null) 
                {
                    Console.WriteLine("비어있는 장비");
                    return; 
                }

                Console.WriteLine($"플레이어가 {curArmor.name} 을/를 해제합니다.");
                OnArmorStateChanged -= curArmor.DecreaseDurability;
                curArmor.OnBreaked -= UnEquip;
                curArmor = null;
            }

            public void Hit()
            {
                OnArmorStateChanged?.Invoke();
            }
        }

        public class Armor
        {
            public string name;
            private int durability;

            public event Action OnBreaked;

            public Armor(string name, int durability)
            {
                this.name = name;
                this.durability = durability;
            }

            public void DecreaseDurability()
            {
                durability--;
                if (durability <= 0)
                {
                    Break();
                }
            }

            private void Break()
            {
                OnBreaked?.Invoke();
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Armor ammor = new Armor("갑옷", 3);

            player.Equip(ammor);

            player.Hit();
            player.Hit();
            player.Hit();
        }
    }
    #endregion

    #region 심화과제. 옵저버 패턴 조사
    /*
     * 옵저버 패턴의 특징은 상태변화가 있을 때, 다른 객체에 해당 변화 사실을 알려주는 특징을 가지고 있다.
     * 옵저버 패턴은 주체와 옵저버로 구성되어, 주체가 상태 변화를 감지하여 옵저버들에게 통지한다.
     * 그리고, 옵저버는 주체가 상태변화를 알려주면, 그에 맞는 동작을 하도록 한다.
     * 
     * 장점
     * 1.주체와 옵저버의 결합이 느슨해져서, 느슨한 결합, 복잡성이 감소, 객체간 의존성을 줄어듬
     * 2.실시간으로 상태변화를 전달해줄 수 있다. 
     * 
     * 단점
     * 1. 옵저버의 수가 많아 질 수록, 관리 어려움
     * 2. 많은 옵저버가 있는 경우, 상태 변화를 통지하는 데 오랜 시간이 걸림.
     * 3. 문제가 생긴 경우, 디버깅하기 어려움 (콜백 지옥..)
     */
    #endregion
}
