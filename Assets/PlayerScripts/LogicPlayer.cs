using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class LogicPlayer : MonoBehaviour
{
    public bool conArma;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;
    public Animator anim;
    public float x,y;

    public Rigidbody rb;
    public float jumpForce = 8f;
    public bool puedoSaltar;

    public bool attack;
    public bool avanzo;
    public float punchImpulse = 10f;
    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() 
    {
        if(!attack)
        {
            transform.Rotate(0,x*Time.deltaTime*rotationSpeed,0);
            transform.Translate(0,0,y*Time.deltaTime*movementSpeed);
        }

        if(avanzo)
        {
            rb.velocity = transform.forward*punchImpulse;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Return)&& puedoSaltar && !attack)
        {
            if(conArma)
            {
                anim.SetTrigger("golpeo2");
                attack = true;
            }
            else
            {
                anim.SetTrigger("golpeo");
                attack = true;
            }
        }

        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);

        if(puedoSaltar)
        {
            if(!attack)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                anim.SetBool("salte",true);
                rb.AddForce(new Vector3(0,jumpForce,0),ForceMode.Impulse);
                }
                
            }
            anim.SetBool("tocosuelo",true);
        }
        else
        {
            estoyCayendo();
        }
    }
    public void estoyCayendo()
    {
        anim.SetBool("tocosuelo",false);
        anim.SetBool("salte",false);
    }

    public void dejeDeGolpear()
    {
        attack = false;
    }

    public void avanzoSolo()
    {
        avanzo = true;
    }

    public void dejoDeAvanzar()
    {
        avanzo = false;
    }

}
