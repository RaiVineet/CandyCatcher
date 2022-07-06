using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour
{
    public bool canMove = true;
    float speed = 15f;
    [SerializeField] private int team; // 1 for player + ai, 2 for ai + ai
    [SerializeField] private bool screenSide; // false for right, true for left
    float minPos = 1f;
    float maxPos = 11.3f;

    // Start is called before the first frame update
    void Start()
    {
        if (screenSide)
        {
            minPos = -11.3f;
            maxPos = -1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float fruitXPos = 0f; // = GameObject.FindGameObjectWithTag("Candy").transform.position.x;

            // Find the closest fruit to the AI and for for that
            float minDistToFruit = 9999f;
            List<Fruits> fruitsSpawned = Manager.instance.GetFruitsList();
            foreach (Fruits fruit in fruitsSpawned)
            {
                if (fruit.transform.position.x < maxPos && fruit.transform.position.x > minPos)
                {
                    float temp = Vector3.Distance(this.transform.position, fruit.transform.position);
                    if (temp < minDistToFruit)
                    {
                        minDistToFruit = temp;
                        fruitXPos = fruit.transform.position.x;
                    }
                }
            }

            float randomNumber = Random.Range(0, 100f);

            if (randomNumber > 65.0f) // AI detects the fruit roughly 65% of the time so it isn't too smart
            {
                if (transform.position.x >= fruitXPos) // if AI is to right of where fruit will fall
                {
                    transform.position += Vector3.left * 1.0f * speed * Time.deltaTime;
                    float XPos = Mathf.Clamp(transform.position.x, minPos, maxPos);  // player postion ,  minimum position , maximum position 
                    transform.position = new Vector3(XPos, transform.position.y, transform.position.z); // assigning new postion value to the player

                }
                else if (transform.position.x <= fruitXPos) // if AI is to left of where fruit will fall
                {
                    transform.position += Vector3.right * 1.0f * speed * Time.deltaTime;
                    float XPos = Mathf.Clamp(transform.position.x, minPos, maxPos);  // player postion ,  minimum position , maximum position 
                    transform.position = new Vector3(XPos, transform.position.y, transform.position.z); // assigning new postion value to the player

                }
                else if (transform.position.x == fruitXPos) // if AI is under the fruit
                {
                    // do nothing, AI is under fruit
                }
            }
            else
            {
                float randXPos = Random.Range(1.0f, 11.3f);
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

    public int GetTeam()
    {
        return team;
    }
}
