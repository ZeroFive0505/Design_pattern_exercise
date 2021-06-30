# Prototype 패턴

Prototype 패턴은 Flyweight 패턴과 많이 유사하다. 원본이되는 물체를 만들고 나서 그 값을 계속해서 복사해서 다시 쓰는 것을 Prototype 패턴이라 한다.

![ezgif-3-659cfaa07bba](https://user-images.githubusercontent.com/39051679/123902771-63fa1900-d9a8-11eb-82de-34e3ab11ee86.gif)

간단하게 마우스를 클릭할때 마다 구를 생성한다.
구를 생성하는 코드가 중요한데 다음과 같다.

```C#
    // 하나의 유일한 구.
    static GameObject sphere;

    public static GameObject GenerateSphere(Vector3 pos)
    {
        // 만약 구가 아직 생성되지 않았다면 새로 만든다.
        if(sphere == null)
        {
            CreateSphere(Vector3.zero);
            sphere.SetActive(false);
        }

        // 아래의 코드는 이미 만들어진 구로부터 데이터를 가져오는 과정.
        GameObject sphereClone = new GameObject();
        sphereClone.AddComponent<MeshFilter>();
        sphereClone.AddComponent<MeshRenderer>();
        sphereClone.GetComponent<MeshFilter>().sharedMesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        MeshRenderer renderer = sphereClone.GetComponent<MeshRenderer>();
        renderer.sharedMaterial = sphere.GetComponent<MeshRenderer>().sharedMaterial;
        sphereClone.AddComponent<Rigidbody>();
        sphereClone.AddComponent<SphereCollider>();
        sphereClone.name = "Sphere(Clone)";
        sphereClone.SetActive(true);
        sphereClone.transform.position = pos;
        sphereClone.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)));
        return sphereClone;
    }
```

![bandicam 2021-06-30 13-11-25-492](https://user-images.githubusercontent.com/39051679/123902933-b3404980-d9a8-11eb-9565-74f67134e104.jpg)
![bandicam 2021-06-30 13-11-28-341](https://user-images.githubusercontent.com/39051679/123902937-b4717680-d9a8-11eb-98cd-f230f8dbe2b0.jpg)

결과는 다음과같이 비록 위치나 이런 정보는 달라도 마테리얼과 메쉬의 정보는 동일하다.


![ezgif-3-935fe82eb0ed](https://user-images.githubusercontent.com/39051679/123903044-e551ab80-d9a8-11eb-9d7b-a2676bff31cc.gif)

마지막으로 유니티의 에디터를 커스텀해서 간단하게 구를 소환, 저장할 수 있게 만든다. 이 또한 처음에 구가 없을시에는 원본이 되는 구를 생성하고 계속 그것을 복제한다.

![bandicam 2021-06-30 13-30-59-351](https://user-images.githubusercontent.com/39051679/123903108-07e3c480-d9a9-11eb-8615-65df7d920cfd.jpg)

다음과 같이 구의 정보가 저장되었다.



