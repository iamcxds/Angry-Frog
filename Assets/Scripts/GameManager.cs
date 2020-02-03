using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public void OnStart(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
