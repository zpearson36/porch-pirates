using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorchScript : MonoBehaviour
{
    public GameObject package = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getPackage()
    {
        GameObject tmp = package;
        package = null;
        return tmp;
    }

    public void setPackage(GameObject pckg)
    {
        package = pckg;
        package.gameObject.transform.position = transform.position;
    }

    public bool hasPackage()
    {
        bool pckg = false;
        if(package is not null) pckg = true;
        return pckg;
    }
}
