# Flyweight Pattern
메모리 사용을 최소화 하기 위한 패턴의 일종이다. 예들 들면 Unity에서 제공하는 Prefab도 Flyweight 패턴의 일종이라 볼 수 있겠다. 또한 Scriptable object도 이 Flyweight 패턴의 일종이고
이것을 이용해 간단한 예제를 연습해봤다.

![bandicam 2021-06-28 14-40-05-467](https://user-images.githubusercontent.com/39051679/123585799-bf000480-d81e-11eb-949c-a88acf2e2f1a.jpg)

위와 같이 객체의 정보를 저장할 Scriptable object를 만든다.

![bandicam 2021-06-28 14-41-11-033](https://user-images.githubusercontent.com/39051679/123585880-e3f47780-d81e-11eb-9a1d-71678b33389b.jpg)

해당 Scriptable object를 이용해 여러 다른 객체의 정보를 담을 Scriptable object를 만들고 데이터를 그에 맞게 수정한다. 이런식으로 하면 비록
오브젝트의 수는 다양해져도 하나의 기본 Scriptable object를 가리키게 된다. 안에 든 데이터는 물론 조금씩 달라지지만 이러한 방식으로 메모리를 아낄 수 있다.

![ezgif-7-cc37b14393a2](https://user-images.githubusercontent.com/39051679/123585618-7c3e2c80-d81e-11eb-8c7b-e46e008b6863.gif)


해당 예제에서는 최근에 나온 Unity starter aasset을 이용했다. 유저가 특정 물체에 충돌할때 만약 그 물체가 Scriptable object를 가지고 있다면 해당 Scriptable object에 담긴 내용이 캔버스에 뜨게된다.
