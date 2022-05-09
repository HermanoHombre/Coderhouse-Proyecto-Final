using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health = 10;
    void Start()
    {
        
    }

    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
    }


}
