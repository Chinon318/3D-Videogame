using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraVida : MonoBehaviour
{
    public int vidMax;
    public float vidActual;
    public Image barraVida;

    public Animator animator;

    public float dañoArma;

    public bool Muerte;

    public float cargarEscena = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        vidActual = vidMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        if(vidActual <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("PrincipalJuego");
        }
        
    }

    public void RevisarVida()
    {
        barraVida.fillAmount = vidActual/vidMax;
    }

    private void OnTriggerEnter(Collider coll) 
    {
        if(coll.CompareTag("armaEnemigo"))
        {
            print("Daño");
            animator.Play("Golpe");
            vidActual -= dañoArma;
        }
    }


}
