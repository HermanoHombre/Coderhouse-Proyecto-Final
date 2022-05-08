using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 5f;
    public float id = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(id == 1)
        {
            LookAt();
        }
        if(id == 2)
        {
            MoveTowardsPlayer();
            if(Vector3.Distance(playerTransform.position, transform.position) < 2)
            {
                Debug.Log("Llegamos");
                speed = 0;
            }
        }
    }

    void MeasureDistance()
    {
        float dist = Vector3.Distance(playerTransform.position, transform.position);
        Debug.Log("Distancia = " + dist);
    }

    void LookAt()
    {
        Quaternion rot = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot , speed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}
