using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruits : MonoBehaviour
{
    int score;
    private Text Score ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {

            //increment the score
            Manager.instance.Incrementscore("Player");
            Destroy(gameObject);
            Debug.Log("fruits destroyed");
            Manager.instance.RemoveFruitFromList(this);
        }
        else if (collider.gameObject.tag == "AI")
        {
            if (collider.gameObject.GetComponent<AI_Controller>().GetTeam() == 1)
            {
                Manager.instance.Incrementscore("Player");
            }
            else if (collider.gameObject.GetComponent<AI_Controller>().GetTeam() == 2)
            {
                Manager.instance.Incrementscore("AI");
            }
            Destroy(gameObject);
            Debug.Log("fruit eaten by AI");
            Manager.instance.RemoveFruitFromList(this);
        }
        

        // if the fruist fall down than destroy the fruits 
        else if(collider.gameObject.tag == "Boundary")
        {
            // Descrease the life ( if the game have)
            Destroy(gameObject);
            Manager.instance.RemoveFruitFromList(this);
        }
    }
}
