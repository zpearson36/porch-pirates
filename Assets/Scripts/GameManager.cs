using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pckgPrefab;
    public float timeToSpawn = 0.0f;
    public float spawnTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        timeToSpawn += Time.deltaTime;
        if(timeToSpawn > spawnTime)
        {
           GameObject[] porchArray = GameObject.FindGameObjectsWithTag("Porch");
           spawnPackage(porchArray[Random.Range(0, porchArray.Length)]);
           timeToSpawn = 0.0f;
        }
    }

    void spawnPackage(GameObject porch)
    {
       GameObject pckg = Instantiate(pckgPrefab, new Vector3(0,0,0), Quaternion.identity);
       porch.GetComponent<PorchScript>().setPackage(pckg);
    }
}
