using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private float moveSpeed = 0.5f;

    private Map map;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map").GetComponent<Map>();
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

    public void setMoveSpeed(float moveSpeed)
    {
        //moveSpeed = moveSpeed+ map.getSpeed();
        this.moveSpeed = moveSpeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"));
        {
            Destroy(collision.gameObject);
        }
    }
}
