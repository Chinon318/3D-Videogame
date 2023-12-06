using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModEnemy : MonoBehaviour
{
   public int hp;
    public int dañoArma;
    public int dañoPuño;
    public Animator anim;
    bool muerto;
    public float tiempoDestruir = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestruirObjeto()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "armaImpacto")
        {
            if(anim != null)
            {
                anim.Play("Enemigo");
            }
            hp -= dañoArma;
        }

        if(other.gameObject.tag == "golpeImpacto")
        {
            if(anim != null)
            {
                anim.Play("Enemigo");
            }
            hp -= dañoPuño;
        }
        if(hp <= 0)
        {
            anim.Play("Muerte");
            muerto = true;
        }
        if(muerto ==true)
        {
            Invoke("DestruirObjeto",tiempoDestruir);
        }
        
    }
}
