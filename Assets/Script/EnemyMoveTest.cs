using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTest : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 firstPos;
    public float speed = 8f;
    public float detectionRange = 30;
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

    void LookAt()
    {
        Quaternion rot = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot , speed * Time.deltaTime);
    }

    void Detection()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) < detectionRange)
        {
            speed = 16;
            detectionRange = 60;
            MoveTowardsPlayer();
            LookAt();
        }
    }
}
