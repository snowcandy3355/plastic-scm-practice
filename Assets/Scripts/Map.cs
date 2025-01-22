using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPositon = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        newPositon.z = this.transform.position.z-moveSpeed;
        this.transform.position = newPositon;
        if (this.transform.position.z < -60)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -12);
        }
    }

    public float getSpeed()
    {
        return this.moveSpeed;
    }
}
