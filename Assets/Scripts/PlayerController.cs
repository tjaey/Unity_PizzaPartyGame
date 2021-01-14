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

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.IsGameOver()){
            MovePlayer();
        }
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
        
        if(!gameManager.IsGameOver()){
            DisplayTopping(other);
            
            gameManager.AddPizzaIngred(other);
            
            Destroy(other.gameObject);
        }

    }


    private void DisplayTopping(Collider other){
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


    public void ResetPizza(){
        for(int i = 0; i < pizzaToppings.Length; i++){
            pizzaToppings[i].SetActive(false);
        }
    }

}













