using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicPlayer logicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) 
    {
        logicPlayer.puedoSaltar = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        logicPlayer.puedoSaltar = false;
    }
}
