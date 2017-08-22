using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puntaje : MonoBehaviour {

    public GameObject Puntaje_L;

    Text tpuntos;
    public static int puntos;

	// Use this for initialization
	void Start () {

        tpuntos = Puntaje_L.GetComponent<Text>();
        puntos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        tpuntos.text = puntos.ToString();
    }
    
}
