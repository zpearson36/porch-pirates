using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float bulk = 0.0f;
    public float weight = 0.0f;
    public int loot = 0;
    public List<float[]> booty = new List<float[]>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulk = 0.0f;
        weight = 0.0f;
        loot = 0;
        booty.ForEach(i => bulk += i[0]);
        booty.ForEach(i => weight += i[1]);
        booty.ForEach(i => loot += (int) i[2]);
        float transX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float transY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //if(transX != 0) transY = 0.0f;
        //if(transY != 0) transX = 0.0f;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + transX, pos.y + transY, pos.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Package")
        {
            booty.Add(new float[] {col.gameObject.GetComponent<PackageScript>().bulk, col.gameObject.GetComponent<PackageScript>().weight, col.gameObject.GetComponent<PackageScript>().worth});
            Destroy(col.gameObject);
        }
    }
}
