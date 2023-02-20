using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OutOfLimit();
        transform.Translate(Vector3.up * bulletSpeed);
    }

    void OutOfLimit()
    {
        if (transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }

}
