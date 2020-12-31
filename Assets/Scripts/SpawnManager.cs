using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] ingredPrefabs = new GameObject[5];
	private float startDelay = 2;
	private float repeatRate = 2;
	private float xBound = 10;
	private float yPos = 17;
	private float zPos = -2.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnIngred", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnIngred(){
    	int ingredNum = Random.Range(0, ingredPrefabs.Length);
    	GameObject ingred = ingredPrefabs[ingredNum];
    	float spawnPosX = Random.Range(-xBound, xBound);
    	Vector3 spawnPos = new Vector3(spawnPosX, yPos, zPos);
    	Instantiate(ingred, spawnPos, ingred.transform.rotation);
    }
}
