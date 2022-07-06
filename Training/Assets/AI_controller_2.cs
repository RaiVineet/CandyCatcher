using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_controller_2 : MonoBehaviour
{
    public bool canMove = true;
    float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float fruitXPos = GameObject.FindGameObjectWithTag("Candy").transform.position.x;

            float randomNumber = Random.Range(0, 100f);

            if (randomNumber > 35.0f) // AI detects the fruit roughly 65% of the time so it isn't too smart
            {
                if (transform.position.x >= fruitXPos) // if AI is to right of where fruit will fall
                {
                    transform.position += Vector3.left * 1.0f * speed * Time.deltaTime;
                    float XPos = Mathf.Clamp(transform.position.x, -11.3f , -1f);  // player postion ,  minimum position , maximum position 
                    transform.position = new Vector3(XPos, transform.position.y, transform.position.z); // assigning new postion value to the player

                }
                else if (transform.position.x <= fruitXPos) // if AI is to left of where fruit will fall
                {
                    transform.position += Vector3.right * 1.0f * speed * Time.deltaTime;
                    float XPos = Mathf.Clamp(transform.position.x, -11.3f, - 1f);  // player postion ,  minimum position , maximum position 
                    transform.position = new Vector3(XPos, transform.position.y, transform.position.z); // assigning new postion value to the player

                }
                else if (transform.position.x == fruitXPos) // if AI is under the fruit
                {
                    // do nothing, AI is under fruit
                }
            }
            else
            {
                float randXPos = Random.Range(-11.3f , -1f);
                if (randXPos > transform.position.x)
                {
                    transform.position += Vector3.right * 1.0f * speed * Time.deltaTime;
                }
                else if (randXPos < transform.position.x)
                {
                    transform.position += Vector3.left * 1.0f * speed * Time.deltaTime;
                } // else do nothing
            }
        }
    }
}
