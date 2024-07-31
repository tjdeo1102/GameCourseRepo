using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static DataStructure_Day1.DataStructure_Dayt1;

namespace DataStructure_Day1
{
    internal class DataStructure_Dayt1
    {
        #region 과제 1. 동적 인벤토리 구현하기

        //public enum ItemType
        //{
        //    Potion,Weapon,Armor,Accessory, Food, end
        //}

        //public class Item
        //{
        //    public string Name { get; set; }
        //    public ItemType ItemType { get; set; }
        //    public Item(string name)
        //    {
        //        Name = name;
        //    }
        //}

        //public class Potion : Item
        //{
        //    public Potion(string name) : base(name) { ItemType = ItemType.Potion; }
        //}

        //public class Weapon : Item
        //{
        //    public Weapon(string name) : base(name) { ItemType = ItemType.Weapon; }
        //}

        //public class Armor : Item
        //{
        //    public Armor(string name) : base(name) { ItemType = ItemType.Armor; }
        //}

        //public class Accessory : Item
        //{
        //    public Accessory(string name) : base(name) { ItemType = ItemType.Accessory; }
        //}
        //public class Food : Item
        //{
        //    public Food(string name) : base(name) { ItemType = ItemType.Food; }
        //}

        //public class Inventory
        //{
        //    List<Item> list;


        //    public void addRandomItem()
        //    {
        //        if (list.Count > 8)
        //        {
        //            Console.WriteLine("아이템이 가득 찼습니다.");
        //            return;
        //        }
        //        int r = new Random().Next((int)ItemType.end);
        //        Item curItem = null;
        //        switch ((ItemType)r)
        //        {
        //            case ItemType.Potion:
        //                curItem = new Potion("분노의 영약");
        //                break;
        //            case ItemType.Weapon:
        //                curItem = new Weapon("칠흑의 양날도끼");
        //                break;
        //            case ItemType.Armor:
        //                curItem = new Armor("천갑옷");
        //                break;
        //            case ItemType.Accessory:
        //                curItem = new Accessory("제어 와드");
        //                break;
        //            case ItemType.Food:
        //                curItem = new Food("완전한 비스킷");
        //                break;
        //        }
        //        if (curItem != null) list.Add(curItem);
        //    }

        //    public void removeItem(int idx)
        //    {
        //        if (idx > list.Count)
        //        {
        //            Console.WriteLine("해당하는 아이템이 없습니다.");
        //            return;
        //        }
        //        list.RemoveAt(idx - 1); // 0번 부터 시작 고려
        //    }
        //    public Inventory()
        //    {
        //        list = new List<Item>(9);
        //    }
        //    public void PrintStatus()
        //    {
        //        int idx = 0;
        //        foreach (Item item in list)
        //        {
        //            Console.WriteLine($"{idx + 1}번 | {item.Name} ");
        //            idx ++;
        //        }
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    Inventory inventory = new Inventory();
        //    while (true)
        //    {
        //        //여기에 업데이트된 인벤토리 현황 표시
        //        Console.WriteLine("──────────────────────");
        //        Console.WriteLine("슬롯 번호 | 아이템  ");
        //        Console.WriteLine("──────────────────────");
        //        inventory.PrintStatus();

        //        ConsoleKey key = Console.ReadKey(true).Key;
        //        Console.Clear();
        //        switch (key)
        //        {
        //            case ConsoleKey.D0:
        //            case ConsoleKey.NumPad0:
        //                inventory.addRandomItem();
        //                break;
        //            case ConsoleKey.D1:
        //            case ConsoleKey.NumPad1:
        //                inventory.removeItem(1);
        //                break;
        //            case ConsoleKey.D2:
        //            case ConsoleKey.NumPad2:
        //                inventory.removeItem(2);
        //                break;
        //            case ConsoleKey.D3:
        //            case ConsoleKey.NumPad3:
        //                inventory.removeItem(3);
        //                break;
        //            case ConsoleKey.D4:
        //            case ConsoleKey.NumPad4:
        //                inventory.removeItem(4);
        //                break;
        //            case ConsoleKey.D5:
        //            case ConsoleKey.NumPad5:
        //                inventory.removeItem(5);
        //                break;
        //            case ConsoleKey.D6:
        //            case ConsoleKey.NumPad6:
        //                inventory.removeItem(6);
        //                break;
        //            case ConsoleKey.D7:
        //            case ConsoleKey.NumPad7:
        //                inventory.removeItem(7);
        //                break;
        //            case ConsoleKey.D8:
        //            case ConsoleKey.NumPad8:
        //                inventory.removeItem(8);
        //                break;
        //            case ConsoleKey.D9:
        //            case ConsoleKey.NumPad9:
        //                inventory.removeItem(9);
        //                break;
        //        }

        //    }
        //}
        #endregion

        #region 과제 2. 요세푸스 순열
        //static void Main(string[] args)
        //{
        //    int n, k;
        //    if (int.TryParse(Console.ReadLine(), out n) == false) return;
        //    if (int.TryParse(Console.ReadLine(), out k) == false) return;

        //    LinkedList<int> list = new LinkedList<int>();
        //    List<int> res = new List<int>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        list.AddLast(i+1);
        //    }
        //    LinkedListNode<int> curNode = list.Last; // 첫번째 요소부터 카운트에 포함되므로 Last부터 시작
        //    int curCnt = k; 
        //    while(list.Count > 0)
        //    {
        //        curCnt--;
        //        LinkedListNode<int> nxtNode;
        //        if (curNode == list.Last) nxtNode = list.First; // 현재 노드가 마지막이면 다음 노드는 처음 노드
        //        else nxtNode = curNode.Next;

        //        if (curCnt == 0)
        //        {
        //            res.Add(nxtNode.Value); // 다음 노드의 값을 결과에 추가
        //            list.Remove(nxtNode); // 다음 노드가 카운트됐으므로 제거, 그리고, 현재노드에서 다시 카운트 시작
        //            curCnt = k; // 현재 카운트가 0인 경우 다시 k만큼를 채우기
        //        }
        //        else curNode = nxtNode; // 카운트에 해당하지 않으면 현재노드 상태 바꾸기
        //    }

        //    Console.Write("<");
        //    for(int i = 0; i < res.Count; i++)
        //    {
        //        if (i == res.Count - 1) 
        //        { 
        //            Console.Write($"{res[i]}"); //마지막 , 없음
        //            break;  
        //        }
        //        Console.Write($"{res[i]},");
        //    }
        //    Console.Write(">");
        //}
        #endregion

        #region 심화과제 1.List<T> 구현하기
        //public class List<T>
        //{
        //    T[] list;
        //    int Length { get; set; }

        //    public List()
        //    {
        //        list = new T[10];
        //        Length = 0;
        //    }

        //    public void Add(T element)
        //    {
        //        if (list.Length <= Length) 
        //        {
        //            T[] new_list = new T[list.Length * 2];
        //            Array.Copy(list,new_list,list.Length); // 기존 요소 복사
        //            list = new_list;
        //        }
        //        list[Length] = element;
        //        Length++;
        //    }

        //    public void Remove (T element) 
        //    {
        //        int findIdx;
        //        for (findIdx = 0; findIdx < list.Length; findIdx++)
        //        {
        //            if (list[findIdx].Equals(element))
        //            {
        //                RemoveAt(findIdx);
        //                break;
        //            }
        //        }
        //    }

        //    public void RemoveAt(int index)
        //    {
        //        if (index < 0 || index >= Length) return;
        //        list[index] = default; //T를 null로 초기화하기 위해 default
        //        for (int i = index+1; i< list.Length; i++)
        //        {
        //            list[i-1] = list[i]; // 뒤의 요소들을 하나씩 앞으로 위치 이동
        //        }
        //        Length--;
        //    }

        //    public void Clear () 
        //    {
        //        for (int i = 0; i < Length; i++)
        //        {
        //            list[i] = default;
        //        }
        //        Length = 0;
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    List<int> list = new List<int>();

        //    list.Add(0);
        //    list.Remove(2);
        //    list.RemoveAt(5);
        //    list.Clear();
        //}
        #endregion

        #region 심화과제 2.LinkedList<T> 구현하기
        public class LinkedList<T>
        {
            LinkedListNode<T> First;
            LinkedListNode<T> Last;

            public void AddFirst(T element)
            {
                var newNode = new LinkedListNode<T>();
                newNode.data = element;
                newNode.next = First;
                if (First != null) First.prev = newNode; //첫 노드가 비어있지 않은 경우에만 첫 노드의 prev수정
                First = newNode;
                if (Last == null) Last = newNode; // 마지막 노드도 비어있는 경우에는 첫노드가 곧 마지막 노드
            }

            public void AddLast(T element)
            {
                var newNode = new LinkedListNode<T>();
                newNode.data = element;
                newNode.prev = Last;
                if (Last != null) Last.next = newNode;
                Last = newNode;
                if (First == null) First = newNode;
            }

            public void RemoveFirst()
            {
                if (First != null)
                {
                    if (First.next == null) //첫 노드이자 마지막 노드
                    {
                        First = null;
                        Last = null;
                    }
                    else
                    {
                        First = First.next;
                        First.prev = null;
                    }
                }
            }

            public void RemoveLast()
            {
                if (Last != null)
                {
                    if (Last.prev == null) //마지막 노드이자 첫 노드
                    {
                        First = null;
                        Last = null;
                    }
                    else
                    {
                        Last = Last.prev;
                        Last.next = null;
                    }
                }
            }

            public void Remove(T element)
            {
                var cur = First;
                while(cur != null)
                {
                    if (cur.data.Equals(element))
                    {
                        var prev = cur.prev;
                        var next = cur.next;
                        if (prev == null) First = null; // 앞 노드의 없는 경우 curNode가 첫 노드이므로, null처리
                        else prev.next = next;
                        if (next == null) Last = null; // 뒤 노드가 없는 경우 curNode가 마지막 노드이므로, null처리
                        else next.prev = prev;

                        prev = null; next = null; //노드 삭제 (next,prev 지운 후, cur_node 제거)
                        break;
                    }
                    cur = cur.next;
                }
            }

            public void Clear()
            {
                First = null;
                Last = null;
            }
        }

        public class LinkedListNode<T>
        {
            public T data {  get; set; }
            public LinkedListNode<T> next { get; set; }
            public LinkedListNode<T> prev { get; set; }

        }

        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);

            list.Remove(2);
            list.Clear();

        }
        #endregion
    }
}
