/***
    Script manages the spawning of the falling objects
    - at start of game, begins coroutine which spawns a
        random ingredient from the list above the top border of the screen.
        at a random interval 
    - objects spawn at random interval between minRate and maxRate
    - objects spawn at random point between -maxX and maxX
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] GameObject[] ingredPrefabs = new GameObject[5];
	private float maxX = 6.5f;
	private float yPos = 12;
	private float zPos = -2.5f;
    private float minRate = 1f;
    private float maxRate = 2.5f;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpawnIngred());
    }

    IEnumerator SpawnIngred(){
        while(!gameManager.IsGameOver()){
           float spawnRate = Random.Range(minRate, maxRate);
    	   yield return new WaitForSeconds(spawnRate);

           int ingredNum = Random.Range(0, ingredPrefabs.Length);
    	   GameObject ingred = ingredPrefabs[ingredNum];
    	   float spawnPosX = Random.Range(-maxX, maxX);
    	   Vector3 spawnPos = new Vector3(spawnPosX, yPos, zPos);
    	   Instantiate(ingred, spawnPos, ingred.transform.rotation);
        }
    }
}
