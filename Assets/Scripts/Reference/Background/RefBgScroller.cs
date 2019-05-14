using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefBgScroller : MonoBehaviour
{
    public float moveSpeed = 1f;
    public bool isRepeating = true;
    public Transform layer;
    private float width = 16f;

    // Update is called once per frame
    void Update()
    {
        // Get position
        Vector3 pos = layer.position;
        
        // Move position
        pos += Vector3.left * moveSpeed * Time.deltaTime;
        // IF on leaving left side if screen
        if (pos.x < -width && isRepeating)
        {
            // Repeat = Move to opposite side of screen
            float offset = width * 2;
            Vector3 newPosition = new Vector3(offset, 0, 0);
            pos += newPosition;
        }

        layer.position = pos;
    }
}
