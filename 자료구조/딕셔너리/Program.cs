namespace DataStructure_Day2
{
    #region 과제 1. 몬스터 데이터베이스 구현하기
    internal class Program
    {
        public class MonsterData
        {
            Dictionary<string, Monster> dic;
            public MonsterData() 
            { 
                dic = new Dictionary<string, Monster>() {  };
            }

            public bool TryGet(string key, out Monster monster)
            {
                if (dic.ContainsKey(key))
                {
                    monster = dic[key];
                    return true;
                }
                else 
                {
                    monster = null;
                    return false; 
                }
            }

            public void AddData(float Hp,float Mp, string name)
            {
                Monster monster = new Monster(name);
                monster.Hp = Hp;
                monster.Mp = Mp;
                dic[monster.Name] = monster;    
            }
        }

        static public MonsterData data = new MonsterData();

        public class Monster
        {
            public float Hp { get; set; }
            public float Mp { get; set; }
            public string Name { get; set; }
            public Monster(string name)
            {
                if (data.TryGet(name, out Monster monster) == true)
                {
                    Hp = monster.Hp;
                    Mp = monster.Mp;
                }
                Name = name;
            }
        }
        static void Main(string[] args)
        {
            data.AddData(100f, 50f, "m1");
            data.AddData(80f, 30f, "m2");
            data.AddData(90f, 20f, "m3");
            data.AddData(30f, 80f, "m4");
            data.AddData(40f, 60f, "m5");

            Monster monster = new Monster("m5");

        }
    }
    #endregion
}
