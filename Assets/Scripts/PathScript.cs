using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public bool pause = false;
    public GameObject obj = null;
    public GameObject[] path = {};
    public int pathPos = 0;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followPath();
    }

    void followPath()
    {
        if(obj != null)
        {
             if(!pause)
             {
                 Vector2 dir = (-obj.transform.position + path[pathPos].transform.position).normalized;
                 obj.transform.position += (Vector3) dir * speed * Time.deltaTime;

                 if(   obj.transform.position.x > path[pathPos].transform.position.x - 1
                    && obj.transform.position.x < path[pathPos].transform.position.x + 1
                    && obj.transform.position.y > path[pathPos].transform.position.y - 1
                    && obj.transform.position.y < path[pathPos].transform.position.y + 1
                    ) pathPos++;
                 if(pathPos >= path.Length) pathPos = 0;
             }
        }
    }
}
