using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyBoardMovement : MonoBehaviour
{
    private Rigidbody rgbd;
    public float speed;
    // Use this for initialization
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rgbd.AddForce(movement * speed);
    }
}
