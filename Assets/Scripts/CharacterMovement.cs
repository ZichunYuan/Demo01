using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;

    private DudeInput input; 

    private float velocity;
    private float horizontal;
    private float acceleration;
    private float speed;

    private Vector2 movement;

    void Awake()
    {
        input = new DudeInput();
        input.Dude.Enable();
        //Handle Movement Animation
        input.Dude.Movement.performed += HandleRunMovement;
        input.Dude.Movement.canceled += HandleStopMovement;
        
        
        //Hanlde Dying and Reviving Animation
        //input.Dude.Die.performed += context =>
        //{
        //    animator.SetBool("Dying", true);
        //};
        //input.Dude.Die.canceled += context =>
        //{
        //    animator.SetBool("Dying", false);
        //};

        //Handle Waving Animation
        //input.Dude.Wave.performed += context =>
        //{
        //    animator.SetBool("Waving", true);
        //};
        //input.Dude.Wave.canceled += context =>
        //{
        //    animator.SetBool("Waving", false);
        //};
         
        //Handle Jumping Animation
        //input.Dude.Jump.performed += context =>
        //{
        //    animator.SetBool("Jumping", true);
        //};
        //input.Dude.Jump.canceled += context =>
        //{
        //    animator.SetBool("Jumping", false);
        //};
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        velocity = 0;
        horizontal = 0;
        acceleration = 1f;
        speed = 3f;
    }

    private void HandleRunMovement(InputAction.CallbackContext context)
    {
        velocity += acceleration;
        if (context.ReadValue<Vector2>().x > 0) horizontal = 1; //Right is pressed
        if (context.ReadValue<Vector2>().x < 0) horizontal = -1; //Left is pressed
    }
    private void HandleStopMovement(InputAction.CallbackContext obj)
    {
        velocity = 0;
       // horizontal = 0;
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(movement.x,0,movement.y);
        //Align the player to Camera's view.
        Quaternion cameraRotation = Quaternion.LookRotation(this.transform.forward,Vector3.up);
        moveDirection = cameraRotation*moveDirection;

        //Handle Moving Downstairs
        if (controller.isGrounded == false) moveDirection += Physics.gravity;
        controller.Move(moveDirection * Time.deltaTime * speed);
    }

    private void HandleRotation()
    {
        Vector3 newPosition = new Vector3(movement.x, 0, movement.y);
        Vector3 rotateDegree = transform.position + newPosition;
        transform.LookAt(rotateDegree);

        //transform.LookAt();
    }

    // Update is called once per frame
    void Update()
    {
        movement = input.Dude.Movement.ReadValue<Vector2>();
        HandleMovement();
        HandleRotation();
        animator.SetFloat("Moving", movement.magnitude);
    }
}
