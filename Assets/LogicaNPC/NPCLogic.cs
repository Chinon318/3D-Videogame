using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCLogic : MonoBehaviour
{
    public GameObject simboloMision;
    public LogicPlayer player;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeMision;
    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text ="Obten las esferas rojas"+ "\n Restantes: "+ numDeObjetivos;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicPlayer>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)&& aceptarMision == false && player.puedoSaltar == true )
        {
            Vector3 posicionJugador = new Vector3(transform.position.x,player.gameObject.transform.position.y,transform.position.z);
            player.gameObject.transform.LookAt(posicionJugador);

            player.anim.SetFloat("VelX",0);
            player.anim.SetFloat("VelY",0);
            player.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
            
            
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            jugadorCerca = true;
            if(aceptarMision == false)
            {
                panelNPC.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player")
        {
            jugadorCerca = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }
    public void No()
    {
        player.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }

    public void Si()
    {
        player.enabled = true;
        aceptarMision = true;
        for(int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}
