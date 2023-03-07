using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = 0;
    public Renderer BackgroundRenderer;

    // Update is called once per frame
    void Update()
    {
        BackgroundRenderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }
}
