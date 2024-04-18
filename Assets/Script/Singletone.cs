using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{ //<T> �Է��ϸ� Generic type���� ���� �� ��.

    private static T instance; //Generic �� ���, Ŭ���� �̸��� �� ���� Ÿ���� �����ش�.

    public static T Instance
    {
        get
        {
            if (instance == null) //�ν��Ͻ��� null�̶��,
            {
                instance = (T)FindAnyObjectByType(typeof(T)); //���� ���׸� Ÿ���� Ÿ���� ã�ƺ���.

                if(instance == null) //�׷��� ����, ������ null�̶��
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T)); //GameObject�� ���� ������ش�.
                    instance = obj.GetComponent<T>();
                } //�̷��� instance�� null�� ���� ������ ���� ��.
            }
            return instance;
        }
    }

    private void Awake()
    {//�ش� ������Ʈ��, �ٸ� ������Ʈ�� ������ ���ԵǾ� �ִٸ� ����� �������� �ʴ´�.
        if (transform.parent != null && transform.root != null) //������Ʈ�� �θ� ������Ʈ�� �ְų�, �ֻ����� ���𰡰� �����Ѵٸ�
        {
            DontDestroyOnLoad(this.transform.root.gameObject); //�� �ֻ����� �������� ����.
        }
        else //�׷��� �ʰ� ���� �ֻ������
        {
            DontDestroyOnLoad(this.gameObject); //�� ������Ʈ�� �������� ����.
        }

    }



}
