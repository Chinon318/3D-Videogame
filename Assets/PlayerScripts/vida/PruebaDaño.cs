using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDaño : MonoBehaviour
{
    public BarraVida barraVida;
    public BarraVida barravidaNPC;
    public float daño = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            barraVida.vidActual -=daño;
            barravidaNPC.vidActual -= daño;
        }
    }
}
