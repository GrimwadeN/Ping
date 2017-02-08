using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLocation : MonoBehaviour {

    
    private GameObject gameManager;
    [SerializeField]
    private GameObject player;
    private float timer;
    [HideInInspector]
    public bool complete = false;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (complete == true)
        {
            timer += Time.deltaTime;
        }
       

        if(timer >= 1.5f)
        {
            if (player != null)
            {
                player.GetComponent<Movement>().enabled = false;
                complete = false;
                timer = 0;
            }         
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.GetChild(0).transform.GetComponent<EncroachingDarkness>().enabled = false;
            complete = true;
            //Game complete
            gameManager.GetComponent<Manager>().gameWinScreen.SetActive(true);
            
        
        }
    }    
}
