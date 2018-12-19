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
    private bool _doubleJump;
    //private MoveState _moveState = MoveState.Idle;
    //private DirectionState _directionState = DirectionState.Right;
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
        //_directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _animatorController.SetBool("isGround", _isGrounded);
            _isGrounded = true;
            _doubleJump = DoubleJump;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _animatorController.SetBool("isGround", _isGrounded);
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        _animatorController.SetFloat("HorizontalSpeed", _rigidbody.velocity.x < 0 ? -_rigidbody.velocity.x : _rigidbody.velocity.x);
        _animatorController.SetFloat("VerticalSpeed", _rigidbody.velocity.y);
        _animatorController.SetBool("isGround", _isGrounded);
        if (!_isGrounded)
        {
            if (_jumpTime >= 0)
            {
                _jumpTime -= Time.deltaTime;
            }


        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        
    }
        



    public void MoveRight()
    {
        
        if (_isGrounded)
        {
            if(_transform.localScale.x == -1)
            {
                _transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            _rigidbody.velocity = new Vector2(WalkSpeed, 0); 
        }
        else
        {
            _rigidbody.velocity = new Vector2(WalkSpeed, _rigidbody.velocity.y);
        }
    }

    public void MoveLeft()
    {
        if (_isGrounded)
        {
            if (_transform.localScale.x == 1)
            {
                _transform.localScale = new Vector3(- transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            _rigidbody.velocity = new Vector2(-WalkSpeed,0);

        }
        else
        {
            _rigidbody.velocity =  new Vector2(-WalkSpeed, _rigidbody.velocity.y);
        }
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            Debug.Log("Jump");
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2( 0 , JumpForce), ForceMode2D.Impulse);
            Debug.Log(_rigidbody.velocity.y);
            _isGrounded = false;
            _jumpTime = _jampCooldown;
        }
        else if (DoubleJump && _jumpTime <= 0)
        {
            if (_doubleJump)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                _doubleJump = !_doubleJump;
            }
        }
    }



    


}

