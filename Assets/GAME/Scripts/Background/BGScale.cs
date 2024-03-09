using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(worldWidth, worldHeight, 0);
    }

    
}
