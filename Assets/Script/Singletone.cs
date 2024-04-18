using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{ //<T> 입력하면 Generic type으로 만든 게 됨.

    private static T instance; //Generic 인 경우, 클래스 이름을 안 적고 타입을 적어준다.

    public static T Instance
    {
        get
        {
            if (instance == null) //인스턴스가 null이라면,
            {
                instance = (T)FindAnyObjectByType(typeof(T)); //먼저 제네릭 타입의 타입을 찾아본다.

                if(instance == null) //그래도 없고, 여전히 null이라면
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T)); //GameObject를 새로 만들어준다.
                    instance = obj.GetComponent<T>();
                } //이러면 instance가 null인 경우는 생기지 않을 것.
            }
            return instance;
        }
    }

    private void Awake()
    {//해당 오브젝트가, 다른 오브젝트의 하위에 포함되어 있다면 제대로 동작하지 않는다.
        if (transform.parent != null && transform.root != null) //오브젝트의 부모 오브젝트가 있거나, 최상위에 무언가가 존재한다면
        {
            DontDestroyOnLoad(this.transform.root.gameObject); //그 최상위를 삭제하지 않음.
        }
        else //그렇지 않고 내가 최상위라면
        {
            DontDestroyOnLoad(this.gameObject); //이 오브젝트를 삭제하지 않음.
        }

    }



}
