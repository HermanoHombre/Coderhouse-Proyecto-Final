using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDA : MonoBehaviour
{
    int cantidad = 3;
    public GameObject objetoAInstanciar;
    public GameObject[] arrayObjetos;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            for(int i=6; i > arrayObjetos.Length; i--)
            {
                GameObject go = Instantiate(objetoAInstanciar, new Vector3(i*7,7,12), Quaternion.identity);
                arrayObjetos[1] = go;
            }
        }
    }
}
