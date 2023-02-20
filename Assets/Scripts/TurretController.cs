using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Rigidbody turretRb;
    public GameObject bullet;
    public float turnSpeed = 80;
    public GameObject canon;
    // Start is called before the first frame update
    void Start()
    {
        turretRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet , canon.transform.position , transform.rotation);
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.back * horizontalInput * Time.deltaTime * turnSpeed);

    
    }
}
