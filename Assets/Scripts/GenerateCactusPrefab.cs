using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCactusPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    private float cactusSpawnTime = 2;
    public float minCactiTime = 1;
    public float maxCactiTime = 1;
    private float timer = 0;
    public GameObject cactusSmallOne; 
    public GameObject cactusBigOne;
    public GameObject coffee;
    public Sprite[] Sprite_Pic;
    private int rand;

    void Start()
    {
        rand = Random.Range(0, 10);
        cactusSmallOne.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
        GameObject newCactus = Instantiate(cactusSmallOne);
        Destroy(newCactus, 6);   
    }

    void Update()
    {
        if(timer > cactusSpawnTime){
            int type = Random.Range(1, 4);
            int coffeeRand = Random.Range(1, 4);
            if (coffeeRand == 1)
            {
                GameObject newCoffee = Instantiate(coffee, new Vector3(Random.Range(10, 25), Random.Range(0, 3), 0), Quaternion.identity);
                Destroy(newCoffee, 6);
            }

            if (type == 1){
                rand = Random.Range(0, 10);
                cactusSmallOne.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
                GameObject newCactus = Instantiate(cactusSmallOne);
                
                Destroy(newCactus, 6);
                
            }

            else if(type == 2) {
                type = Random.Range(1, 3);
                if(type == 1){
                    rand = Random.Range(0, 10);
                    cactusBigOne.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
                    GameObject newCactus = Instantiate(cactusBigOne);
                    Destroy(newCactus, 6);
                }
            }
            timer = 0;
            cactusSpawnTime = Random.Range(minCactiTime, maxCactiTime);
        }
        timer += Time.deltaTime;
    }
}
