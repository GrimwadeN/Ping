using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField]
    private GameObject gameManager;
    [SerializeField]

    private GameObject ttTotem;

    private EncroachingDarkness eD;

	public void PlayGame()
    {
        gameManager.GetComponent<Manager>().menuState = false;
        gameManager.GetComponent<Manager>().playGame = true;
        ttTotem = gameManager.GetComponent<Manager>().totem;

        Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().transform.localScale = Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().startScale;

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitToMenu()
    {
        Camera.main.transform.parent = null;
        gameManager.GetComponent<Manager>().menuState = true;
        gameManager.GetComponent<Manager>().playGame = false;
        if(gameManager.GetComponent<Manager>().failedScreen.activeInHierarchy == true)
        {
            gameManager.GetComponent<Manager>().failedScreen.SetActive(false);
        }
        if(gameManager.GetComponent<Manager>().gameWinScreen.activeInHierarchy == true)
        {
            gameManager.GetComponent<Manager>().gameWinScreen.SetActive(false);
        }
    }

    public void ReplayGame()
    {

        Debug.Log("replay selected");
        // Reset Player
        gameManager.GetComponent<Manager>().ResetPlayer();
        // Reset Totem
        gameManager.GetComponent<Manager>().SpawnTotem();
        // Enable darkness
        Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().enabled = true;
        // TODO: is timebetweenenroach still a thing
        Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().timeBetweenEncroach = 2;
        Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().gameFinished = false;
        Camera.main.transform.GetChild(0).transform.localScale = Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().startScale;
        // Turn win screen off
        if (gameManager.GetComponent<Manager>().gameWinScreen.activeInHierarchy == true)
        {
            gameManager.GetComponent<Manager>().gameWinScreen.SetActive(false);
        }
        // Turn off fail screen
        if(gameManager.GetComponent<Manager>().failedScreen.activeInHierarchy == true)
        {
            gameManager.GetComponent<Manager>().failedScreen.SetActive(false);
        }

        for(int i = 0; i < gameManager.GetComponent<Manager>().pingIcons.Length; i++)
        {
            if(gameManager.GetComponent<Manager>().pingIcons[i].activeInHierarchy == false)
            {
                gameManager.GetComponent<Manager>().pingIcons[i].SetActive(true);
            }
        }
        
    }

   
}
