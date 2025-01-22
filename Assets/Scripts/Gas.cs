using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.z < -20)
        {
            Destroy(this.gameObject);
        }   
        this.transform.position -= this.transform.forward * moveSpeed;
        
    }
}
