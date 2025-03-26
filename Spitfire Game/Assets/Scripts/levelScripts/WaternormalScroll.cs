using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaternormalScroll : MonoBehaviour
{
    public float normalSpeedX = 0.1f;
    public float normalSpeedY = 0.1f;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * normalSpeedX;
        float offsetY = Time.time * normalSpeedY;
        rend.material.SetTextureOffset("_DetailNormalMap", new Vector2(offsetX, offsetY));

        foreach (var property in rend.material.GetTexturePropertyNames())
        {
            //Debug.Log(property);
        }
    }
}
