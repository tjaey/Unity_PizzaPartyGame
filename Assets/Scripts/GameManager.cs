using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//ingredient enum
	const int CHEESE = 0;
	const int PEPP = 1;
	const int ONION = 2;
	const int ANCH = 3;
	const int MUSH = 4;

	public Image[] ingredImages = new Image[5];



	public TextMeshProUGUI recipeText;

	static int[] deluxeRecipe = {CHEESE, PEPP, ONION, ANCH, MUSH};

	int[] recipe = deluxeRecipe;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 ingredListPos = recipeText.transform.position;
        Vector3 transVector = new Vector3(0, -45, 0);
        for(int i = 0; i < recipe.Length; i++){
        	Image ingred = ingredImages[recipe[i]];
        	ingred.transform.Translate(transVector * i);
        	ingred.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
