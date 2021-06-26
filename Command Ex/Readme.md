#Unity 커맨드 패턴

커맨드 패턴으로 만든 간단한 조작 쳬게

![demo 1](https://user-images.githubusercontent.com/39051679/122658507-17912b00-d1a9-11eb-9200-00d8a5e9c918.gif)

![demo 2](https://user-images.githubusercontent.com/39051679/122658508-1d870c00-d1a9-11eb-882f-cf0f42a8463f.gif)


![bandicam 2021-06-20 09-15-06-687](https://user-images.githubusercontent.com/39051679/122658514-2e378200-d1a9-11eb-816f-db2ad707e5fc.jpg)

Abstract로 만든 Command 클래스를 각각의 애니메이션에서 상속을 받고 구현한다.

![bandicam 2021-06-20 09-15-22-294](https://user-images.githubusercontent.com/39051679/122658526-54f5b880-d1a9-11eb-9f77-8272900673dd.jpg)

만든 커맨드 클래스를 통하여 New를 이용해서 원하는 키에 원하는 액션을 할당하고 List를 이용하여 모든 커맨드를 기록해 특정 커맨드가 순서대로 입력될시 콤보 애니메이션 실행

![bandicam 2021-06-20 09-15-46-332](https://user-images.githubusercontent.com/39051679/122658542-84a4c080-d1a9-11eb-9e8d-608e7888e6f7.jpg)

콤보는 특정 시간내에 제대로 입력되어야만 함

![bandicam 2021-06-20 09-16-09-788](https://user-images.githubusercontent.com/39051679/122658549-97b79080-d1a9-11eb-99fd-c65b574f2ff3.jpg)

간단하게 해쉬를 통하여 카운트를 증가시키고 카운트 값이 해당 값과 동일하다면 콤보 애니메이션을 실행시킨다.
