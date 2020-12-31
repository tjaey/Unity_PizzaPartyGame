using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float minX = -15;
    private float maxX = 15;
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
        if(Input.GetKey(KeyCode.LeftArrow) && posX > minX){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //move player right, if in bounds
        if(Input.GetKey(KeyCode.RightArrow) && posX < maxX){
            transform.Translate(Vector3.right * Time.deltaTime * speed);
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
