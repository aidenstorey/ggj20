using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_timer : MonoBehaviour
{
    public int timeRemaining = 20; //Seconds Overall
    public Text countdown; //UI Text Object
    void Start()
    {
        StartCoroutine("DropTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        countdown.text = ("Time Left: " + timeRemaining); //Showing the Score on the Canvas
    }
    ////Simple Coroutine
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
