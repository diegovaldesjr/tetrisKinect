using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    float crono;
    Text text;
    public GameObject obj;
    public static bool flag_tiempo;


	// Use this for initialization
	void Start () {
        crono = 0;
        flag_tiempo = true;
        text = obj.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (flag_tiempo)
        {
            crono += Time.deltaTime;
            text.text = crono.ToString("f0");
        }
        
	}
}
