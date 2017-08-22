using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gameover : MonoBehaviour {

    float crono;

    // Use this for initialization
    void Start () {
        crono = 7.0f;
    }
	
	// Update is called once per frame
	void Update () {
        crono -= Time.deltaTime;
        if(crono <= 0)
            Application.LoadLevel("main");

    }
    
}
