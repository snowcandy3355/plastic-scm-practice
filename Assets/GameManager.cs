using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MapPrefab;
    [SerializeField]
    private GameObject PlayerCarPrefab;
    [SerializeField]
    private GameObject EnemySpawn;
    [SerializeField]
    private GameObject GasSpawn;

    [SerializeField]
    private GameObject gameStartPannel;
    [SerializeField]
    private GameObject gameOverPannel;
    
    [SerializeField]
    private TMP_Text GasState;
    
    public GameObject[] data = new GameObject[4];

    public int Gas = 100;
    // Start is called before the first frame update
    void Awake()
    {
        gameStartPannel.gameObject.SetActive(true);
        gameOverPannel.gameObject.SetActive(false);
        GasState.gameObject.SetActive(false);
        Gas = 100;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GasState.text = "Gas : "+Gas.ToString();
        if (Gas <=0)
        {
            Gas = 0;
            GameOver();
        }
        else if (Gas > 100)
        {
            Gas = 100;
        }

    }

    public void OnclickButton()
    {
        Time.timeScale = 1;
        Gas = 100;
        gameStartPannel.gameObject.SetActive(false);
        gameOverPannel.gameObject.SetActive(false);
        GasState.gameObject.SetActive(true);
        data[0]= Instantiate(MapPrefab, MapPrefab.transform.position, Quaternion.identity);
        data[1]= Instantiate(PlayerCarPrefab, PlayerCarPrefab.transform.position, Quaternion.identity);
        data[1].GetComponent<Player>().gameManager = this;
        data[2]= Instantiate(EnemySpawn, EnemySpawn.transform.position, Quaternion.identity);
        data[3]= Instantiate(GasSpawn, GasSpawn.transform.position, Quaternion.identity);
        StartCoroutine(UseGas());
    }

    public void GameOver()
    {
        StopAllCoroutines();
        Debug.Log("Game Over");
        foreach (GameObject obj in data)
        {
            Destroy(obj);
            gameOverPannel.gameObject.SetActive(true);
        }

        GameObject[] trashEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var obj in trashEnemy)
        {
            Destroy(obj);
        }
        GameObject[] trashGas = GameObject.FindGameObjectsWithTag("Gas");
        foreach (var obj in trashGas)
        {
            Destroy(obj);
        }
        Time.timeScale = 0;

    }

    IEnumerator UseGas()
    {
        yield return new WaitForSeconds(1);
        Gas -= 10;
        StartCoroutine(UseGas()); 
    }
    public void GasUp()
    {
        Gas += 30;

    }

}
