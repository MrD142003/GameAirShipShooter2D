using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float _scrollSpeed;
    private Material _mat;
    private Vector2 _offSet = Vector2.zero;

    private void Awake()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        _offSet = _mat.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        _offSet.y += _scrollSpeed * Time.deltaTime;
        _mat.SetTextureOffset("_MainTex", _offSet);
    }
}
