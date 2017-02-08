using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncroachingDarkness : MonoBehaviour {

    [SerializeField]
    private GameObject failedScreen;

    private float encroachSpeed = 0.3f;   
    private float encroachAmount = 0.5f; 
    private float timer;
    public float timeBetweenEncroach = 2;
    [HideInInspector]
    public bool gameFinished = false;

    [HideInInspector]
    public Vector3 startScale;

    private GameObject player;
    

	// Use this for initialization
	void Start () {
        startScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if(gameFinished == false)
        {
            timer += Time.deltaTime;
        }
        
        if(timer >= timeBetweenEncroach && this.transform.localScale.x > 0.4f)
        {
            var lS = this.transform.localScale;
            this.transform.localScale = Vector3.Lerp(lS, new Vector3(lS.x - encroachAmount, lS.y, lS.z - encroachAmount), encroachSpeed);
            timer = 0;
        }

        if(this.transform.localScale.x <= 0.4f)
        {
            gameFinished = true;
            failedScreen.SetActive(true);
        }
	}

    
}
