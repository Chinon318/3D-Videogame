using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmas : MonoBehaviour
{
    public RecogerArmas recogerArmas;
    public int numArma;
    // Start is called before the first frame update
    void Start()
    {
        recogerArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<RecogerArmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            recogerArmas.ActivaArma(numArma);
            Destroy(gameObject);
        }   
    }
}
