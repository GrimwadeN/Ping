using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPulse : MonoBehaviour {

    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if(timer > 1)
        {
            Destroy(this.gameObject);
        }
	}
}
