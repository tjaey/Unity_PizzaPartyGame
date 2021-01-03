using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float maxX = 7; //threshold for sides of playable area
    private string[] recipe = {"Cheese", "Pepperoni", "Mushroom"};
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer(){
        
        float posX = transform.position.x;

        //move player left, if in bounds
        if(Input.GetKey(KeyCode.LeftArrow) && posX > -maxX){
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        //move player right, if in bounds
        if(Input.GetKey(KeyCode.RightArrow) && posX < maxX){
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

    private void OnTriggerEnter(Collider other){
        bool correctIngred = false;
        for(int i = 0; i < recipe.Length; i++){
            if(other.CompareTag(recipe[i])){
                correctIngred = true;
            }
        }
        if(!correctIngred){
            gameOver = true;
            Debug.Log("Game over");
        }
        else{
            Debug.Log("Pro Cooking Skills");
        }
        Destroy(other.gameObject);
    }
}
