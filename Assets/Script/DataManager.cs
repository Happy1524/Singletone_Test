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
    private static DataManager instance = null; // 싱글톤 선언 관례이다.
    //static = 프로그램이 시작되자마자 해당 변수를 메모리에 계속 들고 있게 한다. 게임 내내.
    //public = 어떤 스크립트에서든 자유롭게 참조할 수 있다. private는 접근 안 됨.
    private SceneName nextScene;
    public SceneName NextScene
    { 
        get { return nextScene; }
    }

    public static DataManager Instance // 대문자.
    {
        get
        {
            if(null==instance) //instance가 null이라면, Instance에 null을 반환하고
            {
                return null;
            }
            else
            {
                return instance; //null이 아니라면, instance에 반환해서 저장한다.
            }
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            //이 스크립트가 컴포넌트로 존재하는 오브젝트는 장면이 전환되어도 파괴되지 않는다.
        }
        else //이미 인스턴스가 존재하는 경우
        {
            Destroy(this.gameObject); //이 싱글톤 패턴이 하나만 존재하도록 나머지를 삭제한다.
        }
    }

    public void Save()
    {
        Debug.Log("저장 완료");
    }

    public void AsyncLoadNextScene(SceneName scene)
    {
        nextScene = scene;
        Time.timeScale = 1f;
        SceneManager.LoadScene("TestScene");
    }

}
