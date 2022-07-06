using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits_Spwaner : MonoBehaviour
{

    public GameObject[] Fruits;
    [SerializeField] float MaxPos;
    [SerializeField] float spawnInterval;
   
    public static Fruits_Spwaner instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {

       


    }
    void SpawnFruits()
    {
        
        int RandomSpawn = Random.Range(0, Fruits.Length);   // 4 fruits spawn
        int RandomSpawn2 = Random.Range(0, Fruits.Length);
        float RandomX = Random.Range(1, MaxPos);  // maxand min positon from where the fruits must be generated 
        float RandomX2 = Random.Range(-MaxPos, -1);
        Vector3 RandomPos = new Vector3(RandomX, transform.position.y, transform.position.z); // new postion to spawn the candies
        GameObject temp = Instantiate(Fruits[RandomSpawn], RandomPos, transform.rotation);  // generate the new fruits every time // spawn new fruit on right side of screen
        Manager.instance.AddFruitToList(temp.GetComponent<Fruits>());
        RandomPos = new Vector3(RandomX2, transform.position.y, transform.position.z);
        temp = Instantiate(Fruits[RandomSpawn2], RandomPos, transform.rotation); // spawn second fruit on left side of screen
        Manager.instance.AddFruitToList(temp.GetComponent<Fruits>());
    }

    IEnumerator SpawningFruits()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnFruits();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void StartSpawning()
    {
        StartCoroutine("SpawningFruits");
    }
    public void StopSpawning()
    {
        StopCoroutine("SpawningFruits");
    }
}
