using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Day5_Assignment
{
    internal class Program
    {
        struct XYCoord
        {
            public short x, y;
        }
        struct Weapon
        {
            public int Dmg;
            public float Critical;
            public string Name;
        }
        enum Company
        {
            Honda,Audi,BMW,Kia
        }
        struct Car
        {
            public float velocity;
            public int car_num;
            Company company;
        }

        enum ItemType
        {
            armor,weapon, use_item
        }

        struct Item
        {
            public string name;
            public int price;
            public ItemType type;
        }

        struct Solider
        {
            public int cur_wepon_idx;
            public Weapon[] weapons; 
        }

        static void Main(string[] args)
        {
            #region 과제 1. 구조체 활용하기

            //Weapon sword = new Weapon();
            //sword.Dmg = 13;
            //sword.Critical = 10.5f;
            //sword.Name = "sword";

            //Weapon katana = new Weapon();
            //katana.Dmg = 50;
            //katana.Critical = 30;
            //katana.Name = "katana";

            //Item[] inven = new Item[3];
            //inven[0].name = "공허한 가면";
            //inven[0].price = 350;
            //inven[0].type = ItemType.weapon;

            //inven[1].name = "기사의 맹세";
            //inven[1].price = 450;
            //inven[1].type = ItemType.armor;

            //inven[2].name = "악몽의 꽃 견갑";
            //inven[2].price = 500;
            //inven[2].type = ItemType.armor;

            //foreach (Item item in inven)
            //{
            //    Console.WriteLine(item.name);
            //    Console.WriteLine(item.price);
            //    Console.WriteLine(item.type);
            //}
            #endregion

            #region 심화과제 1. 무기 교체 기능 제작
            Solider solider = new Solider();
            solider.cur_wepon_idx = -1;
            
            //무기 구현
            Weapon weapon_1 = new Weapon();
            Weapon weapon_2 = new Weapon();
            Weapon weapon_3 = new Weapon();
            weapon_1.Name = "여신의 눈물";
            weapon_1.Dmg = 10;
            weapon_1.Critical = 10;
            weapon_2.Name = "태양불꽃 방패";
            weapon_2.Dmg = 5;
            weapon_2.Critical = 0;
            weapon_3.Name = "무한의 대검";
            weapon_3.Dmg = 10;
            weapon_3.Critical = 25;
            solider.weapons = [weapon_1,weapon_2,weapon_3];


            int cnt = 0;
            while(cnt < 3)
            {
                Console.WriteLine("바꿀 아이템 번호 (1~3번 사이)를 입력해주세요.");
                bool isCorrect = int.TryParse(Console.ReadLine(),out int num);
                if(isCorrect)
                {
                    // idx에 맞게 num 보정
                    num -= 1;
                    if (num >= 0 && num <= 3)
                    {
                        if (num != solider.cur_wepon_idx)
                        {
                            solider.cur_wepon_idx = num;
                            Console.WriteLine($"{solider.weapons[solider.cur_wepon_idx].Name}으로 무기가 교체되었습니다.");
                            cnt++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"같은 무기를 교체할 수 없습니다. \n 현재무기 {solider.weapons[solider.cur_wepon_idx].Name}");
                            continue;
                        }
                        
                    }
                }
                Console.WriteLine("잘못된 입력");
            }


            #endregion

        }
    }
}
