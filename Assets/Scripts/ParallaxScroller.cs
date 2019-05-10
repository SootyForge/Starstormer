using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    public bool isRepeating = true;
    public float[] scrollSpeed;
    public Transform[] layer;
    public List<Vector2> parallaxPos = new List<Vector2>();
    private float width = 18f;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        for (int i = 0; i < layer.Length; i++)
        {
            parallaxPos.Add(layer[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScrollParallax();
    }

    void ScrollParallax()
    {
        for (int i = 0; i < layer.Length; i++)
        {
            // Get layer's position.
            parallaxPos[i] = layer[i].position;

            // Move that position.
            parallaxPos[i] += Vector2.left * scrollSpeed[i] * Time.deltaTime;

            // If the layer scrolls beyond the screen width / aspect ratio.
            if (parallaxPos[i].x < -width && isRepeating)
            {
                // Move the background layer back to the other side of the screen.
                Vector2 newParallaxPos = new Vector2(width, 0);
                parallaxPos[i] += newParallaxPos;
            }
            // Set the layer's position to the parallax position.
            layer[i].position = parallaxPos[i];
        }
    }
}
