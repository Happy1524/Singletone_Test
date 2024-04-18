using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singletone<GameManager> //Generic 으로 만들면 이것으로 싱글톤이 됨.
{


    public void Game()
    {
        Debug.Log("게임 매니저가 싱글톤이 되었다.");
    }
}
