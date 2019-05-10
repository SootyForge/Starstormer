using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 pos;

    private float inputV;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        pos = Vector3.zero;
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    void Update()
    {
        inputV = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Move(inputV);
    }

    public void Move(float inputV)
    {
        pos = new Vector3(0, inputV, 0);
        transform.position += pos;
    }
}
