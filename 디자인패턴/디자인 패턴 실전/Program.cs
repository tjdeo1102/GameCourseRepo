using System.Xml.Linq;

namespace DesignPatern
{
    internal class Program
    {
        #region 과제 1. 팩토리 메소드 패턴 활용하기
        //public class Item
        //{
        //    public string name { get; set; }
        //}
        //class Food : Item
        //{
        //    public Food() 
        //    {
        //        name = "쿠키";
        //    }
        //}

        //class Armor : Item
        //{
        //    public Armor()
        //    {
        //        name = "태양불꽃방패";
        //    }
        //}

        //class Weapon : Item
        //{
        //    public Weapon()
        //    {
        //        name = "공허의 지팡이";
        //    }
        //}

        //class Potion : Item
        //{
        //    public Potion()
        //    {
        //        name = "강철의 영약";
        //    }
        //}
        //public enum ItemType
        //{
        //    Potion,Weapon,Armor,Food
        //}
        //public class ItemFactory
        //{
        //    public Item Create(ItemType itemType)
        //    {
        //        switch (itemType)
        //        {
        //            case ItemType.Potion: return new Potion();
        //            case ItemType.Weapon: return new Weapon();
        //            case ItemType.Armor: return new Armor();
        //            case ItemType.Food: return new Food();
        //            default: return null;
        //        }
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    ItemFactory factory = new ItemFactory();
        //    Console.WriteLine(factory.Create(ItemType.Weapon).name);
        //    Console.WriteLine(factory.Create(ItemType.Armor).name);
        //    Console.WriteLine(factory.Create(ItemType.Food).name);
        //    Console.WriteLine(factory.Create(ItemType.Potion).name);
        //}

        #endregion

        #region 과제 2. 빌더패턴 활용하기

        public interface ICharacterBuilder
        {
            void SetName();
            void SetWeapon();
            void SetArmor();
            void SetAccessory();
        }

        public class Character
        {
            public string Name;
            public List<string> Equipments { get; set; }

            public Character() 
            {
                Equipments = new List<string>();
            }
        }

        public class WarriorBuilder : ICharacterBuilder
        {
            public Character character;
            public WarriorBuilder()
            {
                character = new Character();
            }
            public void SetName() 
            {
                character.Name = "전사";
            }
            public void SetWeapon()
            {
                character?.Equipments.Add("롱소드");
            }

            public void SetArmor()
            {
                character?.Equipments.Add("강철 갑옷");
            }

            public void SetAccessory()
            {
                character?.Equipments.Add("원기회복의 구슬");
            }
        }

        public class ArcherBuilder : ICharacterBuilder
        {
            public Character character;
            public ArcherBuilder()
            {
                character = new Character();
            }
            public void SetName()
            {
                character.Name = "궁수";
            }
            public void SetWeapon()
            {
                character?.Equipments.Add("곡궁");
            }

            public void SetArmor()
            {
                character?.Equipments.Add("대자연의 힘");
            }

            public void SetAccessory()
            {
                character?.Equipments.Add("요정의 부적");
            }

        }

        public class CharacterManager
        {
            public void MakeCharacter(ICharacterBuilder builder)
            {
                builder.SetName();
                builder.SetWeapon();
                builder.SetArmor();
                builder.SetAccessory();
            }

        }

        static void Main(string[] args)
        {
            CharacterManager manager = new CharacterManager();
            List<Character> list = new List<Character>();
            WarriorBuilder warrior = new WarriorBuilder();
            ArcherBuilder archer = new ArcherBuilder();
            manager.MakeCharacter(warrior);
            manager.MakeCharacter(archer);
            list.Add(warrior.character);
            list.Add(archer.character);

            foreach (Character c in list)
            {
                Console.WriteLine($"{c.Name}가 보유한 장비");
                foreach(var equipment in c.Equipments)
                {
                    Console.WriteLine(equipment);
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
