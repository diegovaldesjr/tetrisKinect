using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ready : MonoBehaviour {

    Text text;
    public GameObject obj;
    float crono;

    // Use this for initialization
    void Start()
    {
        crono = 10.0f;
        text = obj.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        crono -= Time.deltaTime;
        if (crono <= 0)
            Application.LoadLevel("tetrisk");
        else if (crono == 5)
            text.text = "Listo!";
    }
}
