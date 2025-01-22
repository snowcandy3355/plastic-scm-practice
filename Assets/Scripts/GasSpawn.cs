using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject gasPrefab;
    [SerializeField]
    private float[] gasPosition= new float[3];

    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime+= Time.deltaTime;
        if (currentTime >= 1f)
        {
            GameObject gas= Instantiate(gasPrefab,new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            gas.transform.position = new Vector3(gasPosition[Random.Range(0,gasPosition.Length)], 0,transform.position.z);
            

            currentTime = 0f;

        }
        
    }
}
