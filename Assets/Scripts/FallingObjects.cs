/*** 
  Script applied to each object that falls from top of screen
  - applies gravity to objects on creation
  - destroys object if it passes lower screen bound
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
  private float gravityModifier = 0.9f;
	private float lowerBound = -4; //threshold for destroying fallen objs

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
