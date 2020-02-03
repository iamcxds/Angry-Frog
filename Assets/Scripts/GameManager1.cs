using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour {
    public GameObject frog,endMenu,pauseMenu,boy,car;
    int count;
    int highestcount;
    public static Vector3 jiang ;
    bool isEnd ;
    bool isPause ;
    float timer;
    int Second;

    // Use this for initialization
    void Start () {
        count = frog.GetComponent<FrogController>().lifetime;
        isEnd = false;
        isPause = false;
        timer=0;
        Second = 0;
        TimePass += new action(Pass1s);
        TimePass += new action(InsBoy);
        TimePass += new action(InsCar);
        Time.timeScale = 1;
        
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            On1sPassed();
            timer--;
        }

        
        count = frog.GetComponent<FrogController>().lifetime;
        jiang = frog.transform.position;
        endMenu.SetActive(isEnd);
        pauseMenu.SetActive(isPause);
        if (count > highestcount)
        {
            highestcount = count;
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&(!isEnd))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (count < 0)
        {
            End();
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void End()
    {
        Time.timeScale = 0;
        isEnd = true;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        isPause = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        isPause = false ;
    }
    public delegate void action();
    public event action TimePass;
    public void On1sPassed()
    {
        if (TimePass != null )
      {
        TimePass();
       }
    }
    void Pass1s()
    {
        Second++;
    }
    
    void InsEnemy(int n,GameObject gou)
    {
        if (Second %n==0)
        {
            Vector2 r = Random.insideUnitCircle;
            Vector3 g = Vector3.Normalize(new Vector3(r.x, 0, r.y));
            Instantiate(gou, new Vector3(jiang.x, 0, jiang.z) + g, Quaternion.Euler(new Vector3(0,Random.value*360,0)));
        }
    }
    void InsBoy()
    {
        InsEnemy(5, boy);
    }
    void InsCar()
    {
        InsEnemy(10, car);
    }

}
