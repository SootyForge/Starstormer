using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;

    private float inputV;
    private Rigidbody2D playerRigi;
    private Vector2 pos;
    

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        playerRigi = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    void Update()
    {
        inputV = Input.GetAxis("Vertical") * moveSpeed;
        Move(inputV);
    }

    public void Move(float inputV)
    {
        Vector2 pos = new Vector2(0, inputV);
        playerRigi.velocity = pos;
    }
}
