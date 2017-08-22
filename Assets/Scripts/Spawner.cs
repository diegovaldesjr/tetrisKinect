using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] piezas;

    // Use this for initialization
    void Start()
    {
        spawnNext();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnNext()
    {
        //Random
        int i = Random.Range(0, piezas.Length);

        //Crea pieza en la posicion actual
        Instantiate(piezas[i], transform.position, Quaternion.identity);

        //transform.position es la posicion del Spawner
    }
}
