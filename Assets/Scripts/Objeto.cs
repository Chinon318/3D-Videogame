using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    //Detecta el metodo con el cual se va a destruir el objeto
    public bool destruir;

    //Cuando detecta que estra dentro del area del collider se destruya 
    public bool destruirAutomatico;

    //Referencia del codigo de personaje donde se estara modificando los valores
    public LogicPlayer logicPlayer;

    //Lo mismo que arriba se le modificaran los valores, en este caso le estamos modificando el valor de vida.
    public BarraVida barraVida;

    //Creamos una variable que dependiendo el valor que tenga, tendra un efecto
    public int tipo;

    void Start()
    {
        //va a buscar el objeto que tenga la etiqueta de "Player" y le sacara el componente del codigo
        //Que se necesitara.
        logicPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicPlayer>();
    }

    void Update()
    {
        
    }


    public void Efecto()
    {
        switch(tipo)
        {
            //Lo que hara este efecto es que hara mas grande al personaje, le modificara la escala del personaje
            case 1:
                logicPlayer.gameObject.transform.localScale = new Vector3(3,3,3);
                break;
            //Se modifica la velocidad de movimiento del personaje 
            case 2:
                logicPlayer.movementSpeed += 5;
                break;
            //Aumenta la vida maxima del personaje
            case 3:
                barraVida.vidMax += 100;
                break;
            default:
                Debug.Log("Sin efecto");
                break;

        }
    }
}
