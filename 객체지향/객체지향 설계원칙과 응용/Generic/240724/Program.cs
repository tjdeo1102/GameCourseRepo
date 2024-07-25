namespace OOP_Day3
{
    #region 과제 1. 제네릭 주석 달기 과제
    //// swap 제네릭 함수
    //public static class Util
    //{
    //    //<T>를 통해 어떤 타입이 들어오는지 체크, where을 통해 제약사항 설정 (현재는 값 타입 제약)
    //    public static void Swap<T>(ref T a, ref T b) where T : struct
    //    {

    //        T temp = a; //T로 들어온 타입으로 temp 변수 생성하여 a할당
    //        a = b; // 해당 a에 b를 할당
    //        b = temp; // b에 저장했던 temp할당
    //    }
    //}

    ////아이템 관련 클래스들
    //public abstract class Item //public한 추상 클래스 Item정의
    //{
    //    public string Name { get; private set; } // 이름 필드를 getter setter로 구현, set은 private로 접근제한

    //    public Item(string name) //아이템 생성자 (이름을 인자로 입력 받는다.)
    //    {
    //        Name = name; // 입력된 이름 매개변수를 Name에 할당
    //    }
    //}

    //public class Potion : Item //추상 클래스 Item을 상속받는 Potion 클래스 정의
    //{
    //    public Potion(string name) : base(name) { } //Potion 생성자, Item 생성자 기능을 그대로 사용
    //}

    //public class Inventory<T> where T: Item // Item 클래스로 T타입을 제한한 제네릭 클래스 Inventory 정의
    //{
    //    private T[] _list; //Item 클래스로 명시된 T타입의 private 배열 _list 생성
    //    private int _index; //list의 인덱스에 해당하는 private _index 생성

    //    public Inventory(int size) //인벤토리 생성자, size를 매개변수로 입력받는
    //    {
    //        _list = new T[size]; // 해당 사이즈만큼의 _list배열 메모리 할당
    //    }

    //    public void Add(T item) //Item타입의 item을 매개변수로 받는 Add메소드 정의
    //    {
    //        if (_index < _list.Length) //_index가 _list의 크기보다 작은 경우
    //        {
    //            _list[_index] = item; //해당 인덱스에 item을 할당
    //            _index++; // _index값을 증가
    //        }
    //    }

    //    public void Remove() //item을 제거하는 Remove메소드 정의
    //    {
    //        if (_index > 0) // _index가 0보다 큰 경우 (아이템이 list에 존재하는 경우)
    //        {
    //            _index--; // 현재 _index 감소 
    //            _list[_index] = null; // 해당되는 인덱스이 아이템 제거
    //        }
    //    }

    //    public void PrintItemNames() //이름을 출력하는 PrintItemNames메소드 정의
    //    {
    //        Console.WriteLine("아이템 목록 :"); //아이템 목록 출력

    //        foreach (T item in _list) // _list에 대한 반복문
    //        {
    //            if (item != null) //아이템이 _list에 존재하는 경우에만
    //            {
    //                Console.WriteLine(item.Name); //아이템 이름을 출력
    //            }
    //        }
    //    }
    //}
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Inventory<Potion> potionInventory = new(10); // 10개의 Potion클래스 메모리 공간을 할당

    //        potionInventory.Add(new Potion("체력 포션")); // 체력 포션 추가
    //        potionInventory.Add(new Potion("마나 포션")); // 마나 포션 추가
    //        potionInventory.Add(new Potion("경험치 포션")); // 경험치 포션 추가
    //        potionInventory.Add(new Potion("활력 포션")); // 활력 포션 추가

    //        potionInventory.Remove(); // 최근 아이템 제거
    //        potionInventory.Remove(); // 최근 아이템 제거

    //        potionInventory.PrintItemNames(); //아이템 이름들 출력
    //    }
    //}
    #endregion

    #region 과제 2. 제네릭의 장점 및 활용 방안
    /*
    1. 제네릭은 어디에 왜 사용되는가?
    여러 타입들에 대한 동일 로직을 적용하거나, 각 타입에 따라 다른 연산을 수행하려 할때 유용하다.
    2. 사용 시 어떤 이점을 제공하는가?
    위를 통해 얻을 수 있는 이점으로 코드 재사용성을 높여주고 잘못된 타입 사용에 의한 오류를 방지할 수 있다.
    3. 제네릭에서 형식 제약 조건은 무엇이며 왜 사용하는가?
    제네릭의 타입 매개변수의 타입을 제한하기 위해 사용된다. 
    이의 제약 종류는 클래스 제약, 인터페이스 제약, 생성자 제약, 값 타입 제약, 참조 타입 제약이 있다.
    where T : <제한 조건>과 같이 만들어 줄 수 있다.
    4. 제네릭과 박싱/언박싱의 관계는 무엇인가?
    제네릭이 없던 경우에, 값 타입이 object같은 참조타입에 할당되는 박싱이 적용되는 상황이 있다.(ex. ArrayList)
    하지만, 제네릭의 경우 이런 박싱 언박싱이 불필요하다.
    4-1. 제네릭을 사용 시 박싱을 어떻게 줄여주는 가
    제네릭을 이용하여 T를 명시해줄 때 (ex. T가 int인 경우), 추후, int형 타입의 매개변수가 들어오더라도, 이미 명시된 타입이 있어서, 박싱의 과정이 필요 없게 된다.
     */
    #endregion

    #region 심화과제 1. C# 제네릭과 C++ 템플릿 조사
    /*
     1. 컴파일, 런타임
        c++의 경우 컴파일 시점에 템플릿이 인스턴스화가 된다.
        C#의 경우 런타임 시점에 제네릭이 작동하게 된다. 그리고, 해당 작업을 JIT(Just-In-Time)컴파일러가 담당한다.
     2. 템플릿에 비해 허용되지 않는 부분이 많은 제네릭
     - 제네릭은 template <int i> C{}와 같이 템플릿에 매개변수가 오는걸 허용하지 않음
     - 제네릭은 명시적 특수화, 부분 특수화, 형식 매개변수, 템플릿-템플릿 매개변수 들을 헝용하지 않음     
     */
    #endregion
}
