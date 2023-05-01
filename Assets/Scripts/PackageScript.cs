using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageScript : MonoBehaviour
{
    public float bulk;
    public float weight;
    public int worth;
    // Start is called before the first frame update
    void Start()
    {
        bulk = Random.Range(.1f, 5f);
        weight = Random.Range(.5f, 20);
        worth = Random.Range(5, 200);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("AAARRRGHH");
        }
    }
}
