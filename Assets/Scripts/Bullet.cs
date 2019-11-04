using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    Vector3 prevPos;
    GameObject playerPos;
    Vector3 dir;
    void Awake()
    {
        // timeout after 5 seconds 
        Destroy(this.gameObject, 5f);
        prevPos = transform.position;
        playerPos = GameObject.Find("Player");
        //dir = playerPos.transform.forward;
        dir = playerPos.transform.right;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prevPos = transform.position;
        // time.deltaTime is so that frame rate does not affect movement
        transform.Translate(dir * (speed * Time.deltaTime));
        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPos,(transform.position - prevPos).normalized),(transform.position - prevPos).magnitude);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.name.Equals("Enemy"))
            {
                hits[i].collider.gameObject.GetComponent<Enemy>().health--;
            }
            Destroy(this.gameObject);
        }

    }
}
