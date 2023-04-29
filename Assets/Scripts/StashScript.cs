using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StashScript : MonoBehaviour
{
    public float maxBulk = 550.0f;
    public float maxWeight = 375.0f;
    public float bulk = 0.0f;
    public float weight = 0.0f;
    public int price = 0;
    public List<float[]> stash = new List<float[]>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulk = 0.0f;
        weight = 0.0f;
        price = 0;
        stash.ForEach(i => bulk += i[0]);
        stash.ForEach(i => weight += i[1]);
        stash.ForEach(i => price += (int) i[2]);
    }

    public bool deposit(float[] loot)
    {
        bool added = false;
        if(bulk + loot[0] <= maxBulk && weight + loot[1] <= maxWeight)
        {
            stash.Add(loot);
            added = true;
        }

        return added;
    }
}
