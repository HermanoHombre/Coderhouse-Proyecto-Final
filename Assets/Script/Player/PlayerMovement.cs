using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private bool isSprinting => canSprint && Input.GetKey(sprintKey);
    private bool canSprint = true;
    private KeyCode sprintKey = KeyCode.LeftShift;

    public Animator anim;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float gravity = -10f;
    public float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector2 movement;

    Vector3 velocity;
    Vector3 firstPos;
    bool isGrounded;

    public float sprintStamina = 10f;

    void Start()
    {
        anim = GetComponent<Animator>();
        firstPos = transform.position;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        /*if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (anim != null)
            {
                anim.SetBool("IsRunning",false);
            }
        }*/

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 inputPlayer = new Vector3(hor, 0, ver);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (inputPlayer == Vector3.zero)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        canSprint = StaminaBar.instance.thereIsStamina;

        controller.Move(move * (isSprinting ? runSpeed : walkSpeed) * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        /*if (transform.position.y < -3)
        {
            transform.position = new Vector3(0, 3, -3);
        }*/

        if (!isGrounded && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
              velocity.y = -velocity.y;
        }

        if (Input.GetKey(sprintKey))
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                StaminaBar.instance.UseStamina(Time.deltaTime * sprintStamina);
            }  
        }
        if(transform.position.y < -3)
        {
            Respawn();
        }
    }
    void Respawn()
    {
        transform.position = firstPos;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Portal")
        {
            ManagerJuego.NextScene();
            firstPos = transform.position;
        }
    }
}
