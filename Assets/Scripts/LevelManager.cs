using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        Brick.breakableCount = 0;
        if(name.Equals("Level_01"))
        {
            Ball.noOfBalls = 3;
        }
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
