using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMove : MonoBehaviour
{
    public float scrollSpeed;
    float targetOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(targetOffset, 0);
    }
}
