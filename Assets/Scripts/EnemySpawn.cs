using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyCarPrefab;
    private float enemyPosition;
    private float enemyMovSpeed;
    [SerializeField]
    private Vector3[] enemyScale = new Vector3[3];
    [SerializeField]
    private Material[] enemyColorMaterial = new Material[3];
    
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
            int randomSize = Random.Range(0, enemyScale.Length);
            int randomColor = Random.Range(0, enemyColorMaterial.Length);
            enemyPosition= Random.Range(-(10.0f-enemyScale[randomSize].y), (10.0f-enemyScale[randomSize].y));
            enemyMovSpeed= Random.Range(0.5f, 0.7f);
            GameObject EnemyCar= Instantiate(EnemyCarPrefab,new Vector3(enemyPosition,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            EnemyCar.transform.localScale= enemyScale[randomSize];
            EnemyCar.gameObject.GetComponent<MeshRenderer>().material = enemyColorMaterial[randomColor];

            EnemyCar.GetComponent<EnemyCar>().setMoveSpeed(enemyMovSpeed);

            currentTime = 0f;

        }
    }

    GameObject MakeEnemy()
    {
        return Instantiate(EnemyCarPrefab);
    }

    
}
