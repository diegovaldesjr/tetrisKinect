using UnityEngine;
using System.Collections;

public class LevelLauncherGesture : MonoBehaviour {

    GestureListener gestureListener;

    // Use this for initialization
    void Start () {
        // get the gestures listener
        gestureListener = Camera.main.GetComponent<GestureListener>();
    }

    // Update is called once per frame
    void Update()
    {

		if (gestureListener.IsSwipeLeft())
        {
            Application.LoadLevel("instrucciones");
        }        
        else if (gestureListener.IsSwipeRight())
        {
            Application.Quit();
        }

    }
}
