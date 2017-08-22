using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

    float lastFall = 0;
    
    GestureListener gestureListener;

    // Use this for initialization
    void Start()
    {
        if (!isValidGridPos())
        {
            Debug.Log("Game Over");
            Destroy(gameObject);

            Timer.flag_tiempo = false;
            Application.LoadLevel("gameover");
        }

        // get the gestures listener
        gestureListener = Camera.main.GetComponent<GestureListener>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //Mover hacia la izquierda
        if (gestureListener.IsSwipeLeft())
        {
            //Modificar la posicion
            transform.position += new Vector3(-1, 0, 0);

            //Ver si es valido
            if (isValidGridPos())
                //Actualizar Grid
                updateGrid();
            else
                //Revertir
                transform.position += new Vector3(1, 0, 0);
        }

        //Mover hacia la derecha
        else if (gestureListener.IsSwipeRight())
        {
            //Modificar la posicion
            transform.position += new Vector3(1, 0, 0);

            //Ver si es valido
            if (isValidGridPos())
                //Actualizar Grid
                updateGrid();
            else
                //Revertir
                transform.position += new Vector3(-1, 0, 0);
        }

        //Rotar
        else if (gestureListener.IsSwipeUp())
        {
            //Modificar la posicion
            transform.Rotate(0, 0, -90);

            //Ver si es valido
            if (isValidGridPos())
                //Actualizar Grid
                updateGrid();
            else
                //Revertir
                transform.Rotate(0, 0, 90);
        }

        //Mover hacia abajo si se presiona la tecla o pasa un segundo
        else if (/*gestureListener.IsSwipeDown() && */Time.time - lastFall >= 1)
        {
            //Modificar la posicion
            transform.position += new Vector3(0, -1, 0);

            //Ver si es valido
            if (isValidGridPos())
                //Actualizar Grid
                updateGrid();
            else
            {
                //Revertir
                transform.position += new Vector3(0, 1, 0);

                //Borrar filas
                if(Grid.eliminarTodasFilas())
                    Puntaje.puntos++;

                //Generar pieza nueva
                FindObjectOfType<Spawner>().spawnNext();

                //Disable script
                enabled = false;
            }
            lastFall = Time.time;
        }

    }

    //Verfica la posicion de cada bloque hijo
    bool isValidGridPos()
    {
        foreach (Transform hijo in transform)
        {
            Vector2 v = Grid.redondear(hijo.position);

            //Esta fuera de la frontera
            if (!Grid.insideBorder(v))
                return false;

            //Si existe un bloque en el mismo sitio        
            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    //Actualizar posiciones de los bloques en el Grid
    void updateGrid()
    {
        //Eliminar posicion vieja de bloque hijo del Grid
        for (int y = 0; y < Grid.alto; y++)
            for (int x = 0; x < Grid.ancho; x++)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        //Agregar nueva posicion en el Grid
        foreach (Transform hijo in transform)
        {
            Vector2 v = Grid.redondear(hijo.position);
            Grid.grid[(int)v.x, (int)v.y] = hijo;
        }
    }
}
