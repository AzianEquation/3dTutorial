using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
