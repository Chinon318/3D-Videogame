using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicObjective : MonoBehaviour
{
    public int numObjetivo;
    public TextMeshProUGUI textoMision;
    public GameObject boton;
    void Start()
    {
        numObjetivo = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Obten las esferas rojas"+"\n restantes: "+numObjetivo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col) 
    {
        if(col.gameObject.tag =="objetivo")
        {
           Destroy(col.transform.parent.gameObject);
           numObjetivo--;
           textoMision.text = "Obten las esferas rojas"+"\n restantes: "+numObjetivo;
           if(numObjetivo <= 0)
           {
                textoMision.text = "Felicidades Completaste la mision";
                boton.SetActive(true);
           }
        }
    }
}
