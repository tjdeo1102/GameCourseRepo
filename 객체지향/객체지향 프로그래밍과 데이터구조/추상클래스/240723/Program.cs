namespace OOP_Day2
{
    #region 과제 1. 상속관계 구현하기
    ///*
    // 리그오브레전드의 챔피언과 스킬 및 이동에 대한 예시를 생각해보았습니다.
    // */
    //abstract class Champion
    //{
    //    int level;
    //    int exp;
    //    float hp;
    //    float mp;
    //    //get,setter 일단 미구현

    //    public Champion(int level, int exp, float hp, float mp)
    //    {
    //        this.level = level;
    //        this.exp = exp;
    //        this.hp = hp;
    //        this.mp = mp;
    //    }

    //    public abstract void Move();

    //    public virtual void QSkill() 
    //    {
    //        Console.WriteLine("Q 스킬 미구현");
    //    }

    //    public virtual void WSkill()
    //    {
    //        Console.WriteLine("W 스킬 미구현");
    //    }

    //    public virtual void ESkill()
    //    {
    //        Console.WriteLine("E 스킬 미구현");
    //    }

    //    public virtual void RSkill()
    //    {
    //        Console.WriteLine("R 스킬 미구현");
    //    }

    //    public void Damaged(float damage)
    //    {
    //        // 데미지 기능 구현
    //    }
    //    //이외 기능들 무시
    //}

    //class Darius : Champion
    //{
    //    public Darius(int level, int exp, int hp, int mp) : base(level, exp, hp, mp)
    //    {
    //        Console.WriteLine("챔피언: 다리우스");
    //    }

    //    public override void Move()
    //    {
    //        Console.WriteLine("다리우스는 땅을 걸어다니는 챔피언");
    //    }

    //    public override void QSkill()
    //    {
    //        Console.WriteLine("학살");
    //    }

    //    public override void WSkill()
    //    {
    //        Console.WriteLine("마비의 일격");
    //    }

    //    public override void ESkill()
    //    {
    //        Console.WriteLine("포획");
    //    }

    //    public override void RSkill()
    //    {
    //        Console.WriteLine("녹서스의 단두대");
    //    }
    //}

    //class Malzahar : Champion
    //{
    //    public Malzahar(int level, int exp, int hp, int mp) : base(level, exp, hp, mp)
    //    {
    //        Console.WriteLine("챔피언: 말자하");
    //    }
    //    public override void Move()
    //    {
    //        Console.WriteLine("말자하는 허공을 떠다니는 챔피언");
    //    }
    //    public override void QSkill()
    //    {
    //        Console.WriteLine("공허의 부름");
    //    }

    //    public override void WSkill()
    //    {
    //        Console.WriteLine("공허의 무리");
    //    }

    //    public override void ESkill()
    //    {
    //        Console.WriteLine("재앙의 환상");
    //    }

    //    public override void RSkill()
    //    {
    //        Console.WriteLine("황천의 손아귀");
    //    }
    //}

    //class Aphelios : Champion
    //{
    //    public Aphelios(int level, int exp, int hp, int mp) : base(level, exp, hp, mp)
    //    {
    //        Console.WriteLine("챔피언: 아펠리오스");
    //    }

    //    public override void Move()
    //    {
    //        Console.WriteLine("아펠리오스는 땅을 걷는 챔피언");
    //    }

    //    public override void QSkill()
    //    {
    //        Console.WriteLine("신념의 무기");
    //    }

    //    public override void WSkill()
    //    {
    //        Console.WriteLine("위상 변화");
    //    }
    //    //E 스킬이 없는 챔피언
    //    public override void RSkill()
    //    {
    //        Console.WriteLine("월광포화");
    //    }
    //}

    //class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Darius darius = new Darius(1, 0, 700, 300);
    //        Malzahar malzahar = new Malzahar(1, 0, 620, 270);
    //        Aphelios aphelios = new Aphelios(1, 0, 570, 260);

    //        darius.Move();
    //        malzahar.Move();
    //    }
    //}


    #endregion

    #region 과제 2. 오버로딩과 오버라이딩
    /*
     * 추상 클래스: 미구현된 추상 메소드가 포함되어 있는 미완성 클래스 ==> 해당 상세구현을 자식 클래스에게 맡기기 위해 사용
     * 오버 라이딩: 부모 클래스의 메소드를 자식 클래스에서 재정의하는 것 ==> 기능을 확장하거나, 수정하기 위해 사용
     * 오버 로딩: 동일한 이름의 메소드에 여러 구현을 하도록 만드는 것 ==> 하나의 메소드로 여러 기능을 하도록 구현 가능, 다형성
     */
    #endregion

    #region 심화과제 1. Trainer 구현
    enum MobType
    {
        Electric,Fire,Water,Grass
    }
    abstract class Monster
    {
        int level;
        protected MobType mobType;
        string name;

        public Monster(int level, string name)
        {
            this.level = level;
            this.name = name;
        }

        public abstract void BaseAttack();
    }

    class Pikachu : Monster
    {
        public Pikachu(int level, string name) : base(level, name)
        {
            mobType = MobType.Electric;
            Console.WriteLine($"포켓몬: 피카츄, 레벨: {level} 타입: {mobType} 이름: {name}");
        }

        public override void BaseAttack()
        {
            Console.WriteLine("전광석화");
        }
    }
    class Squirtle : Monster
    {
        public Squirtle(int level, string name) : base(level, name)
        {
            mobType= MobType.Water;
            Console.WriteLine($"포켓몬: 꼬부기, 레벨: {level} 타입: {mobType} 이름: {name}");
        }

        public override void BaseAttack()
        {
            Console.WriteLine("물총발사");
        }
    }
    class Bulbasaur : Monster
    {
        public Bulbasaur(int level, string name) : base(level, name)
        {
            mobType= MobType.Grass;
            Console.WriteLine($"포켓몬: 이상해씨, 레벨: {level} 타입: {mobType} 이름: {name}");
        }

        public override void BaseAttack()
        {
            Console.WriteLine("덩굴채찍");
        }
    }
    class Charmander : Monster
    {
        public Charmander(int level, string name) : base(level, name)
        {
            mobType = MobType.Fire;
            Console.WriteLine($"포켓몬: 파이리, 레벨: {level} 타입: {mobType} 이름: {name}");
        }

        public override void BaseAttack()
        {
            Console.WriteLine("화염방사");
        }
    }
    class Trainer
    {
        Monster[] monsters;

        public Trainer()
        {
            this.monsters = new Monster[6];
            monsters[0] = new Pikachu(5,"카츠");
        }

        public void AddPoketmon(Monster monster)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == null)
                {
                    monsters[i] = monster;
                    return;
                }
            }
        }

        public void AllAttack()
        {
            foreach (Monster monster in this.monsters) {
                monster?.BaseAttack();
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            trainer.AddPoketmon(new Charmander(5, "파이리"));

            trainer.AllAttack();
        }
    }
    #endregion
}
