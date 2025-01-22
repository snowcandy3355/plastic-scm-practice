using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.5f;
    [SerializeField]
    private float groundMaxSize = 10f;
    [SerializeField]
    private float forwardMaxSize = 15f;

    private float objectSize;

    public GameManager gameManager;
    void Start()
    {
        objectSize = this.gameObject.transform.localScale.x;
    }

    
    void FixedUpdate()
    {
        /*if (this.gameObject.transform.position.x < -(5 - objectSize) ||
            this.gameObject.transform.position.x > (5 - objectSize))
        {
            this.gameObject.transform.position = this.gameObject.transform.position;
        }*/
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right*moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            this.transform.position -= Vector3.right*moveSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward*moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            this.transform.position -= Vector3.forward*moveSpeed;
        }
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width/2)
            {
                transform.position += Vector3.right * moveSpeed;
            }
            else if (Input.mousePosition.x < Screen.width/2)
            {
                transform.position += Vector3.left * moveSpeed;
            }
        }

        
        Vector3 newPosition = new Vector3(Mathf.Clamp(this.transform.position.x,-(groundMaxSize - objectSize/2),(groundMaxSize - objectSize/2)),
            this.transform.position.y,Mathf.Clamp(this.transform.position.z,-forwardMaxSize,forwardMaxSize));
        this.transform.position = newPosition;
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
        else if (collision.gameObject.CompareTag("Gas"))
        {
            gameManager.GasUp();
            Destroy(collision.gameObject);
        }
    }
}
