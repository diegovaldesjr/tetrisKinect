using UnityEngine;
using System.Collections;

public class LevelLauncher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	 
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.T))
        {
            Application.LoadLevel("instrucciones");
        }
        else if (Input.GetKey(KeyCode.M))
        {
            Application.LoadLevel("main");
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
