using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSingleton : MonoBehaviour
{
    private ManagerJuego _managerjuego;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TestearSingleton();
    }

    void TestearSingleton()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ManagerJuego.NextScene();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            ManagerJuego.Pausa();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            ManagerJuego.Despausar();
        }
    }
}
