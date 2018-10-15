using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    [Header("Speeds")]
    public float WalkSpeed = 3;
    public float JumpForce = 10;

    [Header("Jump")]
    public bool DoubleJump;

    private bool _isGrounded;
    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private float _walkTime = 0, _walkCooldown = 0.1f;
    private float _jumpTime = 0, _jampCooldown = 0.1f;


    public void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }



    public void MoveRight()
    {
        if (_isGrounded)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Left)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Right;
            }
            _walkTime = _walkCooldown;
            _animatorController.Play("Walk");
        }
    }

    public void MoveLeft()
    {
        if (_isGrounded)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Right)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Left;
            }
            _walkTime = _walkCooldown;
            _animatorController.Play("Walk");
        }
    }

    public void Jump()
    {
        Debug.Log(_jumpTime);
        Debug.Log(_jumpTime <= 0);
        if (_isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, JumpForce), ForceMode2D.Impulse);
            _moveState = MoveState.Jump;
            _animatorController.Play("Jump");
            _jumpTime = _jampCooldown;
        }
        else if (DoubleJump && _jumpTime <= 0)
        {
            if (_moveState != MoveState.DoubleJump)
            {
                if(_rigidbody.velocity.y < 0)
                {
                    _rigidbody.AddForce(new Vector2(0, -_rigidbody.velocity.y));
                }
                _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, JumpForce), ForceMode2D.Impulse);
                _moveState = MoveState.DoubleJump;
                _animatorController.Play("Jump");
            }
        }
    }

    private void Idle()
    {
        _moveState = MoveState.Idle;
        _animatorController.Play("Idle");
    }


    private void FixedUpdate()
    {

        if (!_isGrounded)
        {
            _jumpTime -= Time.deltaTime;
            if (_rigidbody.velocity == Vector2.zero)
            {
                _isGrounded = true;
                Idle();
            }
        }
        else if (_moveState == MoveState.Walk)
        {

            _rigidbody.velocity = _directionState == DirectionState.Right ? new Vector2(WalkSpeed, _rigidbody.velocity.y)
                                                                           : new Vector2( - WalkSpeed, _rigidbody.velocity.y);
            
            _walkTime -= Time.deltaTime;
            if (_walkTime <= 0)
            {
                _rigidbody.velocity = Vector2.zero;
                Idle();
            }

        }
    }

    enum DirectionState
    {
        Right,
        Left
    }

    

    enum MoveState
    {
        Idle,
        Walk,
        Jump,
        DoubleJump
    }
}

