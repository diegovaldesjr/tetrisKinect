using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    //El arreglo como tal
    public static int alto = 20;
    public static int ancho = 10;

    public static Transform[,] grid = new Transform[ancho, alto];
    //Es tipo Transform y no tipo GameObject para no escribir a cada rato something.transform.position
    //Puesto que cada GameObject tiene una transformacion


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Redondea coordenadas del vector
    public static Vector2 redondear(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    //Verifica que si una coordenada se encuentra dentro de los limites
    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
                (int)pos.x < ancho &&
                (int)pos.y >= 0);
    }

    public static void eliminarFila(int y)
    {
        for (int x = 0; x < ancho; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    //Diminuira una fila actual hacia abajo
    public static void disminuirFila(int y)
    {
        for (int x = 0; x < ancho; x++)
        {
            if (grid[x, y] != null)
            {
                //Mover una fila abajo
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                //Actualiza posicion del bloque
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    //Disminuira una fila las filas que esten arriba de la fila actual
    public static void disminuirFilasTodas(int y)
    {
        for (int i = y; i < alto; i++)
        {
            disminuirFila(i);
        }
    }

    //Verifica si una fila esta llena
    public static bool filaFull(int y)
    {
        for (int x = 0; x < ancho; x++)
            if (grid[x, y] == null)
                return false;

        return true;
    }

    //Elimina una fila si esta completa y disminuye las filas superiores
    public static bool eliminarTodasFilas()
    {
        bool e = false;
        for (int y = 0; y < alto; ++y)
        {
            if (filaFull(y))
            {
                eliminarFila(y);
                disminuirFilasTodas(y + 1);

                //Se disminuye y para asegurar que en el siguiente paso del bucle se esta en el indice correcto
                //Ya que se elimino una fila
                y--;
                e = true;
            }
        }
        return e;
    }
}