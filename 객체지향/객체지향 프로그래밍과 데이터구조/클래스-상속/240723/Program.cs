namespace OOP_Day2
{
    #region 과제 1. 상속 활용 실전
    /*
     리그오브레전드의 챔피언과 스킬 및 이동에 대한 예시를 생각해보았습니다.
     */
    class Champion
    {
        int level;
        int exp;
        float hp;
        float mp;
        //get,setter 일단 미구현

        public Champion(int level, int exp, float hp, float mp)
        {
            this.level = level;
            this.exp = exp;
            this.hp = hp;
            this.mp = mp;
        }

        public void Move()
        {
            Console.WriteLine("기본적인 움직임");
        }

        public virtual void QSkill() 
        {
            Console.WriteLine("Q 스킬 미구현");
        }

        public virtual void WSkill()
        {
            Console.WriteLine("W 스킬 미구현");
        }

        public virtual void ESkill()
        {
            Console.WriteLine("E 스킬 미구현");
        }

        public virtual void RSkill()
        {
            Console.WriteLine("R 스킬 미구현");
        }

        public void Damaged(float damage)
        {
            // 데미지 기능 구현
        }
        //이외 기능들 무시
    }

    class Darius : Champion
    {
        public Darius(int level, int exp, int hp, int mp) : base(level, exp, hp, mp)
        {
            Console.WriteLine("챔피언: 다리우스");
        }

        public override void QSkill()
        {
            Console.WriteLine("학살");
        }

        public override void WSkill()
        {
            Console.WriteLine("마비의 일격");
        }

        public override void ESkill()
        {
            Console.WriteLine("포획");
        }

        public override void RSkill()
        {
            Console.WriteLine("녹서스의 단두대");
        }
    }

    class Malzahar : Champion
    {
        public Malzahar(int level, int exp, int hp, int mp) : base(level, exp, hp, mp)
        {
            Console.WriteLine("챔피언: 말자하");
        }

        public override void QSkill()
        {
            Console.WriteLine("공허의 부름");
        }

        public override void WSkill()
        {
            Console.WriteLine("공허의 무리");
        }

        public override void ESkill()
        {
            Console.WriteLine("재앙의 환상");
        }

        public override void RSkill()
        {
            Console.WriteLine("황천의 손아귀");
        }
    }

    class Aphelios : Champion
    {
        public Aphelios(int level, int exp, int hp, int mp) : base(level, exp, hp, mp)
        {
            Console.WriteLine("챔피언: 아펠리오스");
        }

        public override void QSkill()
        {
            Console.WriteLine("신념의 무기");
        }

        public override void WSkill()
        {
            Console.WriteLine("위상 변화");
        }
        //E 스킬이 없는 챔피언
        public override void RSkill()
        {
            Console.WriteLine("월광포화");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Darius darius = new Darius(1, 0, 700, 300);
            Malzahar malzahar = new Malzahar(1, 0, 620, 270);
            Aphelios aphelios = new Aphelios(1, 0, 570, 260);

            darius.ESkill();
            aphelios.ESkill();
        }
    }


    #endregion

}
