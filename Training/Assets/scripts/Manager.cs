using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public GameObject GameOverPanel;
    bool GameOver = false;
    int score = 0;
    int AIScore = 0;
    int PanelScore = 0;
    int AIPanelScore = 0;
    public Text Timer;
    public Text Score;
    public Text AIScoreText;
    public Text PanelScores;
    public Text AIPanelScores;
    public float InputTimer = 60f;
    public Text WinningCondition;
    List<Fruits> fruits = new List<Fruits>();

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      

        
    }

    // Update is called once per frame
    void Update()
    {
        InputTimer -= Time.deltaTime;
        Timer.text = InputTimer.ToString();

        if(InputTimer < 0)
        {
            
            GameOver = false;
            InputTimer = 0;
            Gameover();

            //if (score > AIScore)
            //{
            //    YouWinPanel.SetActive(true);
            //}
            //else if (AIScore > score)
            //{
            //    YouLosePanel.SetActive(true);
            //}
            //Debug.Log("GameOver");
        }

        WinningConditions();
        

    }
    public void Incrementscore(string entityName)
    {
       
        if (!GameOver)
        {
            if (entityName == "Player")
            {
                score++;
                PanelScore++;
                Score.text = score.ToString();
                PanelScores.text = PanelScore.ToString();
                //print(score);
            }
            else if (entityName == "AI")
            {
                AIScore++;
                AIPanelScore++;
                AIScoreText.text = AIScore.ToString();
                AIPanelScores.text = AIPanelScore.ToString();
            }
        }
       

    }
    public void Gameover()
    {
        Fruits_Spwaner.instance.StopSpawning();  // stop the fruist from spawining
        GameObject.Find("Player").GetComponent<Player_Controller>().PlayerMovement = false;// make the unable to move if the game is over
        GameObject.Find("AI").GetComponent<AI_Controller>().canMove = false; // stop AI from moving
        GameOverPanel.SetActive(true); 

        Debug.Log("GameOver");
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene"); // load the the game scene
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu"); // load the the menu scene
    }
    public void Beginthegame()
    {
        GameOver = false;
    }
    public void stopthegame()
    {
        GameOver = true;
    }
    public void WinningConditions()
    {
        if (score > AIScore)
        {
            // player win
            WinningCondition.text = "Team1_Win";
        }
        else if (AIScore > score)
        {
            // AI wins
            WinningCondition.text = "Team2_Win";
        }
    }
   
    public void AddFruitToList(Fruits fruit)
    {
        fruits.Add(fruit);
    }

    public void RemoveFruitFromList(Fruits fruit)
    {
        fruits.Remove(fruit);
    }

    public List<Fruits> GetFruitsList()
    {
        return fruits;
    }
}
