using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneChange : MonoBehaviour
{

    public void LoadTestScene()
    {
        DataManager.Instance.AsyncLoadNextScene(SceneName.TestScene);
    }

}
