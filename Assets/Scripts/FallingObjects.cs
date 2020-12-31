using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
  private float gravityModifier = 0.9f;

	private float lowerBound = -4;
    // Start is called before the first frame update
    void Start()
    {
       Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < lowerBound){
       	Destroy(gameObject);
       } 
    }
}
