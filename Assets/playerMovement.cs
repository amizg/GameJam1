using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get directional input
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.fixedDeltaTime;

    }

    private void FixedUpdate()
    {
        //Move Player
        controller.Move(horizontalMove, false, false);

    }

}