using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ping : MonoBehaviour {

    [HideInInspector]
    public int startPings = 3;
    public int pingsRemaining = 3;
    [SerializeField]
    private Text pingsDisplay;
    [SerializeField]
    private GameObject ringPrefab;
    private GameObject ring;
    private GameObject gameManager;
    private AudioSource pingSound;

    public float increaseDomeSize = 2;

    // Dome
    private GameObject bloomDome;

	// Use this for initialization
	void Start () {
        startPings = 3;
        pingsRemaining = startPings;
        bloomDome = Camera.main.transform.GetChild(0).gameObject;
        gameManager = GameObject.FindWithTag("GameController");
        pingSound = this.transform.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0) && pingsRemaining >= 1 )
        {
            Debug.Log(pingsRemaining);
            gameManager.GetComponent<Manager>().pingIcons[pingsRemaining - 1].SetActive(false);
            pingsRemaining -= 1;            
            SpawnRing();
            bloomDome.transform.localScale = Vector3.Lerp(bloomDome.transform.localScale, new Vector3(bloomDome.transform.localScale.x + increaseDomeSize, bloomDome.transform.localScale.y, bloomDome.transform.localScale.z + increaseDomeSize), 0.2f);
        }

     
	}

    void SpawnRing()
    {
        ring = (GameObject)Instantiate(ringPrefab, this.transform.position, Quaternion.identity) as GameObject;
        pingSound.Play();
    }

}
