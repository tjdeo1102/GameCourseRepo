﻿namespace OOP_Day3
{

    #region 과제 1. 추상클래스와 인터페이스 차이
    /*
    추상클래스 vs 인터페이스

    추상클래스는 추상 메소드를 포함하는 클래스로 일반 메소드들도 포함 할 수 있다.
    추상클래스는 일부 구현도 가능하지만 다중 상속이 불가능하다.
    주로, 클래스들에서 공통된 특성이나 기능을 추출할 때, 사용하는 경우가 많다. (추상화)

    인터페이스는 메소드, 속성의 정의(선언)만 하고 구현은 제공하지 않는다.(기본 구현 메소드는 제외)
    인터페이스는 다중상속을 지원한다. 다만, 해당 인터페이스를 가진 클래스에서 인터페이스의 멤버들을 전부 구현해야한다.
    주로, 고수준의 모듈을 저수준의 모듈에 의존하지 않도록 하는 의존성 역전 원칙을 구현하는 데 사용하는 경우도 많다.
     */
    #endregion

    #region 과제 2. 인터페이스의 실전 활용 예시
    /*
    리그 오브 레전드라는 게임을 예시로 들겠습니다.
    리그오브레전드에서는 감정 표현 기능이 있어서 웃음,도발 등의 감정에 따라 챔피언의 애니메이션이 동작합니다.
    이럴때, 각 감정상태에 따른 인터페이스를 구성하여, 해당 감정에 따른 애니메이션의 세부 동작(재생, 일시정지 등)을 구현한다면 좋을 거라 생각합니다.
     */
    #endregion
}
