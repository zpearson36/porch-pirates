using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float transX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float transY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        if(transX != 0) transY = 0.0f;
        if(transY != 0) transX = 0.0f;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + transX, pos.y + transY, pos.z);
    }
}
