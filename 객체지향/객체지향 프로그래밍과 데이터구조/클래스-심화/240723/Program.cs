﻿namespace OOP_Day2
{
    #region 과제 1. Partial 클래스와 협업
    /*
     Partial 클래스는 한 클래스를 여러개로 나눈 클래스 들 중 하나이고, Partial 클래스를 이용하면, 큰규모의 클래스를 여러 파일에 나누어서 작성할 수 있게 된다.
    이는 여러 사람이 한 클래스를 동시에 작업할 수 있도록 만들어 줄 수있기 때문에 협업시 유리하다. 또한, 작은 단위로 작성되기에, 가독성 및 유지보수에 용이하다.
     */
    #endregion

    #region 심화과제 1. 깊은 복사 심화
    /* 
     * 1. 깊은 복사의 경우는 얕은 복사와 다르게, 기존 객체의 내용들을 전부 복사하는 것으로, 복사된 객체들의 내용은 기존 객체와 다른 메모리 공간을 가진다.
        이때, 참조형 변수는 기존 객체가 아닌 복사된 객체가 할당된 메모리 주소를 가르키게 되므로 기존 객체의 변수와 메모리 공간상으로 다른 위치에 존재해야 된다.
     * 2. 기존 플레이어 변수와 복사되어 새로 할당된 변수는 메모리 공간상 독립적으로 존재하기 때문에, 복사된 변수의 값을 바꿔주더라도, 기존 객체에 영향이 가지 않는다.
     * 3. 새로 생성된 참조 타입의 객체는 copy라는 메서드를 이용하여 깊은 복사를 할 수 있다.
    */
    #endregion
}
