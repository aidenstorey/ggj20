using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_timer : MonoBehaviour
{
    public static game_timer instance;

    public int timeRemaining = 20; //Seconds Overall
    public Text countdown; //UI Text Object

    void Start()
    {
        if (game_timer.instance != null)
        {
            Destroy(this);
            return;
        }

        game_timer.instance = this;

        Time.timeScale = 1; //Just making sure that the timeScale is right
        countdown.text = ("Time Left: " + timeRemaining);
    }

    void Update()
    {
        countdown.text = ("Time Left: " + timeRemaining); //Showing the Score on the Canvas
    }

    public void start_timer()
    {
        StartCoroutine("DropTime");
    }


    //Simple Coroutine
    IEnumerator DropTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;

            if (timeRemaining < 0)
            {
                SceneManager.LoadScene("end_scene");
            }
        }
    }
}
