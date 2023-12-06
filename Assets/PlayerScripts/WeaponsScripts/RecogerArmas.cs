using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerArmas : MonoBehaviour
{
    public BoxCollider[] armasBoxCol;
    public BoxCollider puñoBoxCol;
    public LogicPlayer logicPlayer;
    public GameObject[] armas;
    // Start is called before the first frame update
    void Start()
    {
        DesactivarColliderArmas();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            DesactivarArmas();
        }
        if(Input.GetKey(KeyCode.T))
        {
            ActivaArma(0);
        }
    }
    public void ActivaArma(int numero)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true);

        logicPlayer.conArma =true;
    }

    public void DesactivarArmas()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        logicPlayer.conArma = false;
    }
    
    public void ActivarColliderArmas()
    {
        for (int i = 0; i < armasBoxCol.Length; i++)
        {
            if(logicPlayer.conArma)
            {
                if(armasBoxCol[i] != null)
                {
                    armasBoxCol[i].enabled = true;
                }
            }
            else
            {
                puñoBoxCol.enabled = true;
            }
        }
    }

    public void DesactivarColliderArmas()
    {
        for (int i = 0; i < armasBoxCol.Length; i++)
        {
            if (armasBoxCol[i] != null)
            {
                armasBoxCol[i].enabled = false;
            }
        }
        puñoBoxCol.enabled = false;
    }
    
}
