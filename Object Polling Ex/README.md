# Object Pooling 패턴
## Object Pooling 패턴을 활용한 메모리 관리
스페이스 인베디어 등 고전 게임에서 메모리 관리를 위해 많이 쓰인 패턴이다. 오브젝트 풀링이란 말 그대로 Pool이라는 공간을 만들어 앞으로 쓰게 될 적, 미사일 등 이런 객체들을 저장해놓고 허용량을 넘지 않게 조절한다.

가장 중요한 Pool의 코드는 다음과 같다.
```C#
...
private void Start()
    {
        pooledItems = new List<GameObject>();

        foreach(PoolItem item in items)
        {
            for(int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    public GameObject Get(string tag)
    {
        for(int i = 0; i < pooledItems.Count; i++)
        {
            if(!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }

        foreach(PoolItem item in items)
        {
            if(item.prefab.tag == tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
                return obj;
            }
        }

        return null;
    }
    ....
```

먼저 Start에서 처음 정해진 양 만큼의 아이템을 만든다. 그리고 바로 비활성화 상태로 만들어 pooledItem에 넣어 놓는다. 그 다음은 Get 메소드에서 Pool에서 가져오고 싶은 아이템의 태그를 전달하면 
그 태그의 아이템이 현재 비활성화 Pool에 있으면 반환 없다면 혹시 이 아이템이 확장가능한지의 여부를 확인하고 만약 가능하다면 새롭게 하나 더 만들어서 Pool에 넣는다. 만약 확장이 불가능하다면
null을 반환한다.


다음은 이 Pool을 이용해서 공을 소환하는 코드이다.

```C#
void SpawnBall()
    {
        GameObject item = Pool.singleton.Get("Ball");
        if (item != null)
        {
            item.transform.position = transform.position;
            Vector3 randOffset = new Vector3(Random.Range(-transform.localScale.x, transform.localScale.x), 0,
                Random.Range(-transform.localScale.z, transform.localScale.z));
            item.transform.position += randOffset;
            item.SetActive(true);
        }
    }
```

간단하게 Pool에서 아이템을 가져오고 null이 아니라면 초기값을 초기화하고 활성화를 시킨다.

![bandicam 2021-07-07 16-37-14-306](https://user-images.githubusercontent.com/39051679/124718970-9de79400-df41-11eb-8342-1be56c71bd06.jpg)


위와같이 Pool을 설정할 수 있다. 현재의 설정으로는 초기 Pool에 들어갈 아이템의 양은 10개이며 만약 부족하다면 확장이 가능하게 했다. 먼저 확장이 불가능할 경우를 예로 봐보자.


![ezgif-7-9bd95c0ca804](https://user-images.githubusercontent.com/39051679/124719339-fdde3a80-df41-11eb-8199-909847436216.gif)

시연 영상과 같이 10개의 구가 최대로 소환이 되며 더이상 늘지 않는다.

![bandicam 2021-07-07 16-39-18-953](https://user-images.githubusercontent.com/39051679/124719425-151d2800-df42-11eb-93c2-e8be34428fa0.jpg)

풀링된 아이템의 갯수도 10개로 고정되어 있다.

이번에는 확장이 가능했을때이다.

![ezgif-7-9cd082841664](https://user-images.githubusercontent.com/39051679/124719851-8a88f880-df42-11eb-80a8-02447315eb4b.gif)


확장이 가능해지면서 무수히 많은 공이 소환이 되는 것을 볼 수 있다.

![ezgif-7-ce6ceb0497af](https://user-images.githubusercontent.com/39051679/124720049-b3a98900-df42-11eb-8a45-75c85f2a890d.gif)


또한 실시간으로 확장되는 Pool의 사이즈를 볼 수도 있었다.
