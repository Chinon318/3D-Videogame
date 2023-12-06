using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEsferas : MonoBehaviour
{
    public NPCLogic logicaNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col) 
    {
        if(col.tag =="Player")
        {
            logicaNPC.numDeObjetivos--;
            logicaNPC.textoMision.text = "Obten las esferas rojas"+ "\n restantes: "+logicaNPC.numDeObjetivos;
            if(logicaNPC.numDeObjetivos <= 0)
            {
                logicaNPC.textoMision.text = "Felicidades Completaste la mísión";
                logicaNPC.botonDeMision.SetActive(true);
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
