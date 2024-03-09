using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneBound : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -_bounds.x + 0.5f;
        maxX = _bounds.x - 0.6f;

        minY = -_bounds.y + 0.5f;
        maxY = _bounds.y - 0.6f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temp = this.transform.position;
        if(temp.x < minX)
             temp.x = minX;
        else if(temp.x > maxX)
             temp.x = maxX;

        if( temp.y < minY)
             temp.y = minY;
        else if(temp.y > maxY)
             temp.y = maxY;

        this.transform.position = temp;
    }
}
