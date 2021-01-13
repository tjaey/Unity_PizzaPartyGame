using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private float moveSpeed = 10.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float maxX = 5; //threshold for sides of playable area
    private string[] recipe = {"Cheese", "Pepperoni", "Mushroom"};
    [SerializeField] GameObject[] pizzaToppings = new GameObject[5];
    //public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        
        displayTopping(other);
        
        gameManager.addPizzaIngred(other);
        
        Destroy(other.gameObject);

    }


    private void displayTopping(Collider other){
        switch(other.tag){

            case "Anchovy" :
                pizzaToppings[0].SetActive(true);
                break;

            case "Cheese" :
                pizzaToppings[1].SetActive(true);
                break;

            case "Mushroom" :
                pizzaToppings[2].SetActive(true);
                break;

            case "Onion" :
                pizzaToppings[3].SetActive(true);
                break;

            case "Pepperoni" :
                pizzaToppings[4].SetActive(true);
                break;

            default :
                Debug.Log("Unkown pizza topping gameObject");
                break;
        }
    }

    /*private bool isCorrectIngred(Collider other){
        for(int i = 0; i < recipe.Length; i++){
            if(other.CompareTag(recipe[i])){
                return true;
            }
        }
        return false;
    }*/

}













