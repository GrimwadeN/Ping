using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    // Game States
    public enum GAMESTATE
    {
        MENU,
        PLAYGAME,
        PAUSE,
        TUTORIAL
    }

    // Gamestate Stuff
    [Header("Gameplay")]
    [HideInInspector]
    public GAMESTATE gameState;
    [SerializeField]
    private GameObject gameStateObject;
    [SerializeField]
    private GameObject menuStateObject;
    public bool playGame = false;
    public bool menuState = false;


    // Player Stuff
    [Header("Player")]
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;
    private Movement playerMove;


    // Totem Stuff
    [Header("Totemz")]
    public GameObject[] totems;
    private int totemNumber;
    [SerializeField]
    private GameObject targetTotem;
    public GameObject totem;
    private Vector3 lastPosition = Vector3.zero;
    private Vector3 target;


    // UI
    [Header("UI")]
    public GameObject gameWinScreen;
    public GameObject failedScreen;
    public GameObject[] pingIcons;


    // Use this for initialization
    void Start () {
        gameState = GAMESTATE.MENU;
        menuStateObject.SetActive(true);
        gameStateObject.SetActive(false);

        
	}
	
	// Update is called once per frame
	void Update () {

        if(player != null && playerMove != null)
        {
            playerMove = player.GetComponent<Movement>();
        }

        switch (gameState)
        {
            case GAMESTATE.MENU:
                UpdateMenu();
                break;

            case GAMESTATE.PAUSE:
                UpdatePause();
                break;

            case GAMESTATE.PLAYGAME:
                UpdatePlayGame();
                break;

            case GAMESTATE.TUTORIAL:
                UpdateTutorial();
                break;
        }
	}
    // Update the Menu State
    void UpdateMenu()
    {
        // Set the menu stuff to be active and the game play stuff to be inactive
        menuStateObject.SetActive(true);
        gameStateObject.SetActive(false);

        if(playGame == true)
        {
            SpawnPlayer();
            // Spawn the end goal
            SpawnTotem();
            // Active all ping icons
            for(int i = 0; i < pingIcons.Length; i++)
            {
                if(pingIcons[i].activeInHierarchy == false)
                {
                    pingIcons[i].SetActive(true);
                }  
            }

            // Reset remaining pings
            player.GetComponent<Ping>().pingsRemaining = player.GetComponent<Ping>().startPings;
            // Set Game State Object to be active
            gameStateObject.SetActive(true);
            menuStateObject.SetActive(false);
            // Set Camera as child of parent
            Camera.main.transform.SetParent(player.transform);
            gameState = GAMESTATE.PLAYGAME;
        }
    }
    // Update the Pause State
    void UpdatePause()
    {
        // Disable player movement
        playerMove.enabled = false;
    }
    // Update the Game State
    void UpdatePlayGame()
    {        
        if(menuState == true)
        {
            // Remove Player
            Destroy(player);
            // Destroy Totem
            Destroy(totem);
            // Swap active objects
            gameStateObject.SetActive(false);
            menuStateObject.SetActive(true);
            // Swap Gamestate
            gameState = GAMESTATE.MENU;
        }

    }
    // Update the Tutorial State
    void UpdateTutorial()
    {
        // Disable player movement
        playerMove.enabled = false;
    }


    public void SpawnTotem()
    {
        if(totem != null)
        {
            Destroy(totem);
        }

        // Select totem spawnpoint
        totemNumber = Random.Range(1, 4);
        target = player.transform.position - totems[totemNumber - 1].transform.position;

        if (totems[totemNumber - 1].transform.position == lastPosition)
        {
            while (totems[totemNumber - 1].transform.position == lastPosition)
            {
                // Select totem spawnpoint
                totemNumber = Random.Range(1, 4);
            }

            // Target direction for totem
            target = player.transform.position - totems[totemNumber - 1].transform.position;
        }

        lastPosition = target;
         // Spawn the totem
        totem = Instantiate(targetTotem, totems[totemNumber -1].transform.position, Quaternion.LookRotation(target));
    }

    public void SpawnPlayer()
    {       
        if(player != null)
        {
            Camera.main.transform.parent = null;
            Destroy(player);
        }

        if(player == null)
        {
            player = (GameObject)Instantiate(playerPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity);
            player.transform.SetParent(gameStateObject.transform);

            // Reset remaining pings
            player.GetComponent<Ping>().pingsRemaining = player.GetComponent<Ping>().startPings;

            // Set Camera position
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 6.7f, player.transform.position.z - 4.8f);
            Camera.main.transform.rotation = Quaternion.Euler(40, 0, 0);
        }
        
    }

    public void ResetPlayer()
    {
        Camera.main.transform.parent = null;
        Destroy(player);
        player = (GameObject)Instantiate(playerPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity);
        player.transform.SetParent(gameStateObject.transform);


        // Reset remaining pings
        player.GetComponent<Ping>().pingsRemaining = player.GetComponent<Ping>().startPings;
   

        // Set Camera position
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 6.7f, player.transform.position.z - 4.8f);
        Camera.main.transform.rotation = Quaternion.Euler(40, 0, 0);
        Camera.main.transform.SetParent(player.transform);
    }

}
