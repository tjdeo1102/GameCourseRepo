namespace OOP_Day1
{
    internal class Program
    {
        #region 과제 1. 트레이너와 몬스터 제작하기
        class Trainer
        {
            public string name;
            public Monster[] haveMonsters;

            public Trainer()
            {
                name = "WhoIs?";
                haveMonsters = new Monster[6];
            }
        }

        class Monster
        {
            public int hp;

            public Monster()
            {
                hp = 100;
            }
        }
        static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
        }
        #endregion

        #region 심화과제 1. 소멸자 조사
        /*먼저, C#은 C++과 다르게 GC가 할당된 메모리들을 모니터링하여, 해당 메모리의 참조가 없는 경우에 자동으로 소멸을 시켜주기에 필요가 없다.
         * 또한, 기존 소멸자 ~를 명시적으로 사용하면, 해당 할당된 메모리를 소멸하기 위한, 리소스들이 발생하며, 성능 저하의 확률이 늘어난다. (+ GC가 해당 작업을 바로 수행하지 않음)
         * IDisposable인터페이스를 이용하면, 소멸자를 원하는 시점에 리소스를 해제할 수도 있다.
         */
        #endregion
    }
}
