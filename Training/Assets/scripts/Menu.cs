using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int CountDownTimer;
    public Text CountDownDisplay;

    // Start is called before the first frame update
    void Start()
    {
        CountDownDisplay.gameObject.SetActive(true); // disable the text display
        StartCoroutine(CountDownStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    public void Exit()
    {
        Application.Quit(); // quit the game
    }

    // CountDown
    IEnumerator CountDownStart()
    {
        Manager.instance.stopthegame();  // Start the game
        while (CountDownTimer > 0)
        {
            CountDownDisplay.text = CountDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            CountDownTimer--;  // 3 , 2 , 1 , GO!

        }
        CountDownDisplay.text = "GO!";  // after the countdown ends, display GO!

        Manager.instance.Beginthegame();  // Start the game
        yield return new WaitForSeconds(1f);// wait for the 1 sec
        CountDownDisplay.gameObject.SetActive(false); // disable the text display
    }
    
}
