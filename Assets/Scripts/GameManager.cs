using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool gameOver;

	//ingredient enum
	const int CHEESE = 0;
	const int PEPP = 1;
	const int ONION = 2;
	const int ANCH = 3;
	const int MUSH = 4;

	public Image[] ingredImages = new Image[5];

	public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    private float seconds = 75;
    private int score = 0;

    private int numRecipes = 3;

	static int[] deluxeRecipe = {CHEESE, PEPP, ONION, ANCH, MUSH};
    static string[] deluxeString = {"Cheese", "Pepperoni", "Onion", "Anchovy", "Mushroom"};

    static int[] veggieRecipe = {CHEESE, ONION, MUSH};
    static string[] veggieString = {"Cheese", "Onion", "Mushroom"};

    static int[] peppMushRecipe = {CHEESE, PEPP, MUSH};
    static string[] peppMushString = {"Cheese", "Pepperoni", "Mushroom"};


	int[] recipe = veggieRecipe;
    string[] recipeString = veggieString;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        chooseRandomRecipe();
        displayRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            seconds -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(seconds);
            if(seconds <= 0){
                SetGameOver();
            }
        }
    }

    public bool addPizzaIngred(Collider other){
        for(int i = 0; i < recipe.Length; i++){
            if(other.CompareTag(recipeString[i])){
                Debug.Log("Pro cooking skills");
                return true;
            }
        }
        gameOver = true;
        Debug.Log("Game over");
        return false;
    }

    private void chooseRandomRecipe(){
        int x = Random.Range(0, numRecipes);
        switch(x){
            case 0:
                recipe = deluxeRecipe;
                recipeString = deluxeString;
                break;
            case 1: 
                recipe = veggieRecipe;
                recipeString = veggieString;
                break;
            case 2:
                recipe = peppMushRecipe;
                recipeString = peppMushString;
                break;
            default:
                recipe = deluxeRecipe;
                recipeString = deluxeString;
                Debug.Log("Hit default random recipe switch");
                break;
        }
    }

    private void displayRecipe(){
        Vector3 transVector = new Vector3(0, -45, 0);
        for(int i = 0; i < recipe.Length; i++){
            Image ingred = ingredImages[recipe[i]];
            ingred.transform.Translate(transVector * i);
            ingred.gameObject.SetActive(true);
        }
    }

    private void SetGameOver(){
        gameOver = true;
    }

    public bool isGameOver(){
        return gameOver;
    }

}
