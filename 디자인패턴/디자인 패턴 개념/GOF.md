# 생성 패턴
1. 팩토리 메서드
   - 부모 클래스는 객체를 생성할 인터페이스를 제공, 자식 클래스는 객체의 유형에 따라 해당 객체의 생성을 구현하게 된다.
   
     **(예시)** 
      
     몬스터를 상속받는 고블린, 슬라임이 있을때, 팩토리가 있고, 몬스터 유형에 따른 팩토리에서 생성 로직이 구현되어 있다.
      <details>
        <summary>구현 예시</summary>
   
        ```csharp
        public interface IMonster
        {
           int Health { get; set; }
           int AttackPower { get; set; }
           int DefensePower { get; set; }
   
           void Move();
           // 그 외 코드들
        }
   
        class Slime : IMonster
        {
           // 여러 코드 구현
        }
   
        class Goblin : IMonster
        {
           // 여러 코드 구현
        }
   
        public abstract class MonsterFactory
        {
           public abstract IMonster CreateMonster(); // 팩토리 메서드
        }
   
        public class SlimeFactory : MonsterFactory
        {
           public override IMonster CreateMonster()
           {
              return new Slime();
           }
        }
   
        public class GoblinFactory : MonsterFactory
        {
           public override IMonster CreateMonster()
           {
              return new Goblin();
           }
        }
        ```
        
        </details>
2. 추상 팩토리
   - 객체들의 조합을 만들 필요가 있을 때, 객체의 조합에 대한 인터페이스를 제공한다.
     
     **(예시)** 
      
      각 단계에 대한 생성 메소드가 있는 추상 팩토리가 있어서, 스테이지에 따라 여러 팩토리들을 제작할 수 있다.
      <details>
     <summary>구현 예시</summary>

     ```csharp
     public interface IMonster
     {
        int Health { get; set; }
        int AttackPower { get; set; }
        int DefensePower { get; set; }

        void Move();
        // 그 외 코드들
     }

     class Slime : IMonster
     {
        // 여러 코드 구현
     }

     class Goblin : IMonster
     {
        // 여러 코드 구현
     }

     public interface IMonsterFactory
     {
        IMonster CreateFirstStep();   // 1단계 스텝의 몬스터들 생성
        IMonster CreateSecondStep();  // 2단계 스텝의 몬스터들 생성
        IMonster CreateFinalStep();   // 마지막 단계의 몬스터들 생성
     }

     public class StageAMonsterFactory : IMonsterFactory
     {
        public List<IMonster> CreateFirstStep()
        {
           List<IMonster> monsters = new List<IMonster>();
           monsters.Add(new Slime());
           return monsters;
        }

        public List<IMonster> CreateSecondStep()
        {
           List<IMonster> monsters = new List<IMonster>();
           monsters.Add(new Slime());
           monsters.Add(new Slime());
           return monsters;
        }

        public List<IMonster> CreateFinalStep()
        {
           List<IMonster> monsters = new List<IMonster>();
           monsters.Add(new Slime());
           monsters.Add(new Slime());
           monsters.Add(new Slime());
           return monsters;
        }
     }

     public class StageBMonsterFactory : IMonsterFactory
     {
        public List<IMonster> CreateFirstStep()
        {
           List<IMonster> monsters = new List<IMonster>();
           monsters.Add(new Goblin());
           return monsters;
        }

        public List<IMonster> CreateSecondStep()
        {
           List<IMonster> monsters = new List<IMonster>();
           monsters.Add(new Slime());
           monsters.Add(new Goblin());
           return monsters;
        }

        public List<IMonster> CreateFinalStep()
        {
           List<IMonster> monsters = new List<IMonster>();
           monsters.Add(new Slime());
           monsters.Add(new Slime());
           monsters.Add(new Goblin());
           monsters.Add(new Goblin());
           return monsters;
        }
     }
     ```

     </details>
3. 빌더
   - 복잡한 객체를 구성하는 부분들을 단계별로 생성하고, 이를 조합해서 복잡한 객체를 생성하는 방식
   
     **(예시)** 

      캐릭터가 여러개의 장비를 장착할 수 있는 경우, 각 직업별로 다른 캐릭터 장비가 장착되도록 구현

      <details>
      <summary>구현 예시</summary>

      ```csharp
      public interface ICharacterBuilder
      {
         void SetWeapon();
         void SetArmor();
         void SetAccessory();

         // 그 외 코드 생략
      }

      public class Character
      {
         public List<string> Equipments { get; set; }

         // 그 외 코드 생략
      }

      public class WarriorBuilder : ICharacterBuilder
      {
         public Character character;
         public WarriorBuilder()
         {
               character = new Character();
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

         // 그 외 코드 생략

      }

      public class ArcherBuilder : ICharacterBuilder
      {
         public Character character;
         public ArcherBuilder()
         {
               character = new Character();
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

         // 그 외 코드 생략

      }

      //캐릭터 매니저에서, 미리 정한 빌더에 따라 캐릭터를 생성
      public class CharacterManager
      {
         public void MakeCharacter(ICharacterBuilder builder)
         {
               builder.SetWeapon();
               builder.SetArmor();
               builder.SetAccessory();
         }

         //그 외 코드 생략
      }

      // 실제 캐릭터 매니저로 캐릭터 생성하는 코드 생략
      ```
      </datails>
4. 프로토 타입
   - 해당 클래스에 의존하지 않고 객체를 복사 하기 위해 사용
   
      **(예시)**

      장비랑 캐릭터가 있고 캐릭터에 장비관련 필드가 있는 경우, 해당 복제본을 만들고 원래의 게임 오브젝트에 의존하지 않도록 구현

      <details>
      <summary>구현 예시</summary>

      ```csharp
      public class Equipment
      {
         public string Name { get; set; }

         public Equipment(string name)
         {
            Name = name;
         }

         // 그 외 코드 생략
      }

      public class Character: GameObject
      {
         public float Hp { get; set; }
         public float Mp { get; set; }
         public Equipmnet Equipment;

         public Character DeepCopy()
         {
            Character clone = (Character) this.MemberwiseClone();
            clone.Equipment = new Equipment(Equipment.Name)'
            return clone;
         }

         // 그 외 코드 생략
      }

      // 실제 캐릭터 매니저로 캐릭터 생성하는 코드 생략

      ```

      </datails>

5. 싱글턴
   - 클래스에 인스턴스가 하나만 있도록 하면서 이 인스턴스에 대한 전역 접근​(액세스) 지점을 제공하는 생성 디자인 패턴


# 구조 패턴

- 추후 상세 구현 코드 추가 필요

1. 어댑터
   - 호환되지 않는 인터페이스를 가진 객체들이 협업할 수 있도록 하는 구조적 디자인 패턴
2. 브릿지
   - 큰 클래스 또는 밀접하게 관련된 클래스들의 집합을 두 개의 개별 계층구조​(추상화 및 구현)​로 나눈 후 각각 독립적으로 개발할 수 있도록 하는 구조 디자인 패턴
3. 복합체
   - 객체들을 트리 구조들로 구성한 후, 이러한 구조들과 개별 객체들처럼 작업할 수 있도록 하는 구조 패턴
4. 데코래이터
   - 객체들을 새로운 행동들을 포함한 특수 래퍼 객체들 내에 넣어서 위 행동들을 해당 객체들에 연결시키는 구조적 디자인 패턴
5. 퍼사드
   - 라이브러리에 대한, 프레임워크에 대한 또는 다른 클래스들의 복잡한 집합에 대한 단순화된 인터페이스를 제공하는 구조적 디자인 패턴
6. 플라이웨이트
   각 객체에 모든 데이터를 유지하는 대신 여러 객체들 간에 상태의 공통 부분들을 공유하여 사용할 수 있는 RAM에 더 많은 객체들을 포함할 수 있도록 하는 구조
7. 프록시
   - 다른 객체에 대한 대체 또는 자리표시자를 제공할 수 있는 구조 디자인 패턴

# 행동 패턴

- 추후 상세 구현 코드 추가 필요

1. 책임 연쇄
   - 핸들러들의 체인​(사슬)​을 따라 요청을 전달할 수 있게 해주는 행동 디자인 패턴
2. 커맨드
   - 요청을 요청에 대한 모든 정보가 포함된 독립실행형 객체로 변환하는 행동 디자인 패턴
3. 반복자
   - 컬렉션의 요소들의 기본 표현​(리스트, 스택, 트리 등)​을 노출하지 않고 그들을 하나씩 순회할 수 있도록 하는 행동 디자인 패턴
4. 중재자
   - 객체 간의 혼란스러운 의존 관계들을 줄일 수 있는 행동 디자인 패턴
5. 메멘토
   - 객체의 구현 세부 사항을 공개하지 않으면서 해당 객체의 이전 상태를 저장하고 복원할 수 있게 해주는 행동 디자인 패턴
6. 옵서버
   - 당신이 여러 객체에 자신이 관찰 중인 객체에 발생하는 모든 이벤트에 대하여 알리는 구독 메커니즘을 정의할 수 있도록 하는 행동 디자인 패턴
7. 상태
   - 객체의 내부 상태가 변경될 때 해당 객체가 그의 행동을 변경할 수 있도록 하는 행동 디자인 패턴
8.  전략
    - 알고리즘들의 패밀리를 정의하고, 각 패밀리를 별도의 클래스에 넣은 후 그들의 객체들을 상호교환할 수 있도록 하는 행동 디자인 패턴
9.  템플릿 메서드
    - 부모 클래스에서 알고리즘의 골격을 정의하지만, 해당 알고리즘의 구조를 변경하지 않고 자식 클래스들이 알고리즘의 특정 단계들을 오버라이드​(재정의)​할 수 있도록 하는 행동 디자인 패턴
10. 비지터
    - 알고리즘들을 그들이 작동하는 객체들로부터 분리할 수 있도록 하는 행동 디자인 패턴
