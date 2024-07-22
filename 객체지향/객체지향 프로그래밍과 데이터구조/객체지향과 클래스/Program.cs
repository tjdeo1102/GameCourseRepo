namespace OOP_Day1
{
    internal class Program
    {
        #region 과제 1.Chracter 클래스 선언하기
        class Character
        {
            public int level;
            public int hp;
            public float speed;
            public float attack;

            public void Forward()
            {
                //구현
            }
            public void Backward()
            {
                //구현
            }
            public void TurnLeft()
            {
                //구현
            }
            public void TurnRight()
            {
                //구현
            }
            public void Attack()
            {
                //구현
            }
            public void Damaged()
            {
                //구현
            }
        }
        #endregion

        #region 심화과제 1. 가비지 컬렉터
        /*가비지 컬렉터(GC)는 특정 시점에서 호출되어, 참조되고 있지 않은 메모리들을 수집하여 할당 해제하는 역할을 수행한다.
         세대에 따라서, 높은 세대일 수록 긴 수명을 가진 객체로 구분한다. 해당 세대는 0,1,2로 구분된다.
         GC의 호출이 잦을 수록, 비용이 많이 들기 때문에, 메모리 누수가 없도록 만드는 것이 중요하다. ==> 유니티에서, 특정 프레임에 프레임 드랍이 일어나는 원인
        또한, 잦은 생성과 소멸이 발생하는 객체라면, 객체 풀링을 하는 것이 바람직하다고 한다. */
        #endregion


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
