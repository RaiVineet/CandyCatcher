using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public bool PlayerMovement = true;   // checking whtether the player is moving OR not 
    [SerializeField] float speed;
    [SerializeField] float MaxPos = -1f ; // maiximum position our player can move ( x-axis)
    [SerializeField] float MinPos = -11.3f; // minimum position our player can move ( x-axis)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement)  // true
        {
            Move();   // move the player
        }
        
    }
    // responsible for the player movemnt
    private void Move()
    {
        float InputX = Input.GetAxis("Horizontal");//  x axis movement
                             // (1,0,0)       x-axis   speed       time
        transform.position += Vector3.right * InputX * speed * Time.deltaTime;
        // check wether the player in the gameview boundary
        float XPos = Mathf.Clamp(transform.position.x, MinPos, MaxPos);  // player postion ,  minimum position , maximum position 
        transform.position = new Vector3(XPos, transform.position.y, transform.position.z); // assigning new postion value to the player 
    } 

    public float GetSpeed()
    {
        return speed;
    }

    public float GetMaxPos()
    {
        
        return MaxPos;
    }
}
