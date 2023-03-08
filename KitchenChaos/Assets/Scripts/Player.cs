using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 7f;
    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W))
        {
            //inputVector = new Vector2(0,1);
            inputVector.y = +1; //This approach allows diagonal movement
        }
        if (Input.GetKey(KeyCode.A))
        {
            //inputVector = new Vector2(-1, 0);
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //inputVector = new Vector2(0, -1);
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //inputVector = new Vector2(1, 0);
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;
        //transform.position += (Vector3)inputVector; //stupid typecasting cuz movement is along x and z but this approach does for x and y
        //Vector3 moveDir = (inputVector.x,0f,inputVector.y); //common beginner error
        //Vector3 moveDir = new Vector3(inputVector.x,0f, inputVector.y);
        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);

        transform.position += moveSpeed * Time.deltaTime * moveDir; //frame rate independent

        //transform.forward = moveDir; //player faces towards moveDirection, but no smooth transition
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * rotateSpeed);
        //isWalking = moveDir != Vector3.zero;
        if (moveDir == Vector3.zero)
        {
            isWalking = false;//no movement input, means no walking
        }
        else
        {
            isWalking = true;
        }
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}
