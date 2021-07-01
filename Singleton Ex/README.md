# Unity Singleton 패턴

## Singleton 패턴을 이용한 공유자원 관리

게임내에서 공유되는 자원을 관리할때 유용하게 이용할 수 있다. 예제로 만든 것에서 공유되는 자원은 목표 지점들과 마우스 클릭으로 떨어지는 자원들이다.

```C#
    public static GameEnvironment Singleton
    {
        get
        {
            // 현재 인스턴스가 존재하지 않는다면 하나를 새로 만든다. 앞으로 계속 이 객체가 쓰일 것이다.
            if(instance == null)
            {
                instance = new GameEnvironment();
                instance.WayPoints.AddRange(GameObject.FindGameObjectsWithTag("WayPoint"));
            }

            return instance;
        }
    }
```

싱글톤을 쓰는 것은 간단하다 이제 이 객체를 쓰고싶은데서 불러서 쓰면 된다.

```C#
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("WayPoint");
        agent = GetComponent<NavMeshAgent>();
        // 싱글톤을 가져와서 접근한다.
        agent.SetDestination(GameEnvironment.Singleton.GetRandomPoints().transform.position);
    }
    ...
```

![ezgif-3-19bf9b70457b](https://user-images.githubusercontent.com/39051679/124065836-80628800-da72-11eb-8080-343bafe3d7c5.gif)

공유자원이 생길때마다 가장 가까운 자원으로 이동한다. 
