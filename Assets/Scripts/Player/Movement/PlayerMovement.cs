using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    float _gravity = -9.81f;
    float gravityMultiplier = 3f;
    float _velocity;

    public static bool isMoving;

    Animator animator;
    Movements movements;
    Vector3 input;
    CharacterController characterController;
    private void Awake()
    {
        movements = new Movements();
        animator = GetComponent<Animator>();    
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        movements.Enable();
        movements.Land.Move.performed += ctx => InputPerformed(ctx);
        movements.Land.Move.canceled += ctx => InputCanceled(ctx);
    }

    private void OnDisable()
    {
        movements.Disable();
        movements.Land.Move.performed -= ctx => InputPerformed(ctx);
        movements.Land.Move.canceled -= ctx => InputCanceled(ctx);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyVelocity();
        ApplyRotation();
        ApplyMovement();
    }

    void ApplyVelocity()
    {
        if (characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        input.y = _velocity;
    }

    void ApplyMovement()
    {
        characterController.Move(input * moveSpeed * Time.deltaTime);
    }

    void ApplyRotation()
    {
        Vector3 direction = input;
        direction.y = 0.0f;
        if (direction != Vector3.zero)
        {
            //transform.forward = input;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void InputPerformed(InputAction.CallbackContext ctx)
    {
        input = new Vector3(ctx.ReadValue<Vector2>().x,0,ctx.ReadValue<Vector2>().y);
        animator.Play("Running");
        isMoving = true;
    }

    void InputCanceled(InputAction.CallbackContext ctx)
    {
        input = new Vector3(ctx.ReadValue<Vector2>().x,0,ctx.ReadValue<Vector2>().y);
        animator.Play("Idle");
        isMoving = false;
    }
}
