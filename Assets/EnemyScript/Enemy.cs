using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Rutina del enemigo
    public int rutina;
    public float cronometro;
    public Animator anim;
    // El Quaternion lo usamos para rotar al enemigo
    public Quaternion angulo;
    public float grado;

    //Con esto haremos que nuestro enemigo detecte al jugador
    public GameObject target;
    //Para saber cuando nos esta atacando
    public bool atacando;
    void Start()
    {
        //Le estamos dando el componente de Animator a la variable anim
        anim = GetComponent<Animator>(); 
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position,target.transform.position)>5)
        {
            anim.SetBool("run",false);
             //lo que se hace es cuadrar el cronometro sumando 1 * time.deltatime
            cronometro +=1 * Time.deltaTime;

            //Si el cronometro es mayor o igual a 4 
            if (cronometro >=4)
            {
            // La rutina sacara un numero al azar un numero entre 0 y 1 
            rutina = Random.Range(0,2);

            //Aqui reiniciamos el cronometro
            cronometro = 0;
            }

            //Abrimos switch para la variable Rutina
            switch (rutina)
            {
                // En el caso 0 lo que queremos es que el enemigo se quede quieto
                case 0:
                    //Con esto podemos cancelar la animacion de walk
                    anim.SetBool("walk",false);
                    break;
                //En el caso 1 vamos a determinar la posicion en la que se va a desplazar
                case 1:
                    grado = Random.Range(0,360);
                    //Agulo tendra el valor de grado en el eje "Y"
                    angulo = Quaternion.Euler(0,grado,0);
                    //A la rutina se le sumara mas 1 para poder pasar al caso 2
                    rutina++;
                    break;
                case 2:
                    //La rotacion del enemigo sera igual al angulo establecido
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,angulo,0.5f);

                    //Aqui se movera hacia delante con una velocidad de 1
                    transform.Translate(Vector3.forward*1*Time.deltaTime);

                    //Activamos la animacion de caminar
                    anim.SetBool("walk",true);
                    break;
            
            }
        }
        else
        {
            if(Vector3.Distance(transform.position,target.transform.position) > 1 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,3);
                anim.SetBool("walk",false);

                anim.SetBool("run",true);
                transform.Translate(Vector3.forward*2*Time.deltaTime);

                anim.SetBool("attack",false);
            }
            else
            {
                anim.SetBool("walk",false);
                anim.SetBool("run",false);

                anim.SetBool("attack", true);
                atacando = true;
            }
            
        }
       
    }
    public void Final_ani()
    {
        anim.SetBool("attack",false);
        atacando = false;
    }
}
