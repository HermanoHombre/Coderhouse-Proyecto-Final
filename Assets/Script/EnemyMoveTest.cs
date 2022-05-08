using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTest : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 firstPos;
    public float speed = 8f;
    void Start()
    {
        firstPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfEnemyIsFalling();
        Detection();
    }
    void MeasureDistance()
    {
        float dist = Vector3.Distance(playerTransform.position, transform.position);
        Debug.Log("Distancia = " + dist);
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    void Respawn()
    {
        transform.position = firstPos;
    }

    void CheckIfEnemyIsFalling()
    {
        if (transform.position.y < -20)
        {
            Respawn();
        }
    }

    void Detection()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < 50)
        {
            speed = 22;
            MoveTowardsPlayer();
        }
    }
}
