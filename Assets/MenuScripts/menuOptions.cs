using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOptions : MonoBehaviour
{
    public void comenzarJuego(string Nombrenivel)
    {
        SceneManager.LoadScene(Nombrenivel);
        print("Comenzando..");
    }
    public void Salir()
    {
        Application.Quit();
        print("Salir");
    }
}
