using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Pocion" && hitInfo.collider.gameObject.GetComponent<Objeto>().destruir == true)
                {
                    Debug.Log(hitInfo.collider.gameObject.tag);
                    hitInfo.collider.gameObject.GetComponent<Objeto>().Efecto();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }
}
