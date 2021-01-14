using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private bool gameOver;
    private PlayerController player;

	//ingredient enum
	const int CHEESE = 0;
	const int PEPP = 1;
	const int ONION = 2;
	const int ANCH = 3;
	const int MUSH = 4;

	public Image[] ingredImages = new Image[5];

	public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recipeText;
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
    List<string> currPizzaNeeds = new List<string>(); 

    public Vector3 recipeAnchor;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver = false;
        recipeAnchor = ingredImages[0].GetComponent<RectTransform>().position;
        ChooseRandomRecipe();
        DisplayRecipe();
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

    public bool AddPizzaIngred(Collider other){
        for(int i = 0; i < recipe.Length; i++){
            if(other.CompareTag(recipeString[i])){
                CorrectTopping(recipeString[i]);
                return true;
            }
        }
        WrongTopping();
        return false;
    }

    private void ChooseRandomRecipe(){
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
        currPizzaNeeds.Clear();
        currPizzaNeeds.AddRange(recipeString);
    }

    private void DisplayRecipe(){
        ClearRecipe();
        Vector3 posVector = new Vector3(0, -45, 0);
        for(int i = 0; i < recipe.Length; i++){
            Image ingred = ingredImages[recipe[i]];
            ingred.transform.position = recipeAnchor;
            ingred.transform.Translate(posVector * i);
            ingred.gameObject.SetActive(true);
        }
    }

    private void ClearRecipe(){
        for(int i = 0; i < ingredImages.Length; i++){
            ingredImages[i].gameObject.SetActive(false);
        }
    }


    private void IncreaseScore(){
        score++;
        scoreText.text = "Score: " + score;
    }

    private void CorrectTopping(string topping){
        //pizza topping turn green in recipe list UI
        currPizzaNeeds.Remove(topping);
        Debug.Log("Pro cooking skills");
        if(currPizzaNeeds.Count < 1){
            IncreaseScore();
            player.ResetPizza();
            ChooseRandomRecipe();
            DisplayRecipe();
            Debug.Log("Pizza Done");
        }
    }

    private void WrongTopping(){
        //pizza topping turn red in recipe list UI
        player.ResetPizza();
        ChooseRandomRecipe();
        DisplayRecipe();
        Debug.Log("Wrong Topping");
    }

    private void SetGameOver(){
        gameOver = true;
    }

    public bool IsGameOver(){
        return gameOver;
    }

}
