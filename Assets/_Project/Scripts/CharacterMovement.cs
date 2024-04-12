using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    Vector2 movement;
    [Header("Character Movement Settings")]
    [SerializeField] float groudedOffset = 0.01f;
    //Flat
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float sprintSpeed = 3f;
    float trueSpeed;
    //Jump
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -9.8f;
    
    bool isGrounded;
    Vector3 velocity;


    [Header("Camera Settings")]
    [SerializeField] Transform camera;
    [SerializeField] float turnSmoothTime = .1f;
    float turnSmoothVelocity;


    [Header("Animations")]
    [SerializeField] Animator animations;
    bool sprinting;
    // Start is called before the first frame update
    void Start()
    {
        trueSpeed = walkSpeed;
        controller = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groudedOffset, 1);
        animations.SetBool("isGround", isGrounded);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
            
        }
        //Grounded Movement
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
            sprinting = false;
        }
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);

            if (sprinting == true)
            {
                animations.SetFloat("Speed", 2);
            }
            else
            {
                animations.SetFloat("Speed", 1);
            }
        }
        else
        {
            animations.SetFloat("Speed", 0);
        }
        
       



        //Jumping
      
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
            animations.SetTrigger("Jump");
                
        }
        
            velocity.y += gravity * Time.deltaTime;
       
       
        controller.Move(velocity * Time.deltaTime);

    }
}
