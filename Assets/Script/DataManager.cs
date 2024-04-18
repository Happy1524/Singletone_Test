using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    SampleScene,
    TestScene,
}


public class DataManager : MonoBehaviour
{
    private static DataManager instance = null; // �̱��� ���� �����̴�.
    //static = ���α׷��� ���۵��ڸ��� �ش� ������ �޸𸮿� ��� ��� �ְ� �Ѵ�. ���� ����.
    //public = � ��ũ��Ʈ������ �����Ӱ� ������ �� �ִ�. private�� ���� �� ��.
    private SceneName nextScene;
    public SceneName NextScene
    { 
        get { return nextScene; }
    }

    public static DataManager Instance // �빮��.
    {
        get
        {
            if(null==instance) //instance�� null�̶��, Instance�� null�� ��ȯ�ϰ�
            {
                return null;
            }
            else
            {
                return instance; //null�� �ƴ϶��, instance�� ��ȯ�ؼ� �����Ѵ�.
            }
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //�� ��ũ��Ʈ�� ������Ʈ�� �����ϴ� ������Ʈ�� ����� ��ȯ�Ǿ �ı����� �ʴ´�.
        }
        else //�̹� �ν��Ͻ��� �����ϴ� ���
        {
            Destroy(this.gameObject); //�� �̱��� ������ �ϳ��� �����ϵ��� �������� �����Ѵ�.
        }
    }

    public void Save()
    {
        Debug.Log("���� �Ϸ�");
    }

    public void AsyncLoadNextScene(SceneName scene)
    {
        nextScene = scene;
        Time.timeScale = 1f;
        SceneManager.LoadScene("TestScene");
    }

}
