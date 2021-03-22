using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    [SerializeField] public float MoveTime;
    [SerializeField] public AnimationCurve Jump;
    [SerializeField] public AnimationCurve ForwardGraph;
    [SerializeField] public float Multiplyer;
    private List<int> _directionX = new List<int>();
    private List<int> _directionZ = new List<int>();
    private PlayerMoveInput _PlayerMovementInput;
    private PlayerInput input;
    private Rigidbody rb;
    public bool _isMoving = false;
    private float _time;
    private bool _movingForward;
    private bool _movingRight;
    private bool _movingLeft;
    private float _directionFacing;
    private float _timerotatingR;
    private float _timerotatingL;

    private void Awake()
    {
        _PlayerMovementInput = new PlayerMoveInput();
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        _PlayerMovementInput.Enable();
    }
     
    private void OnDisable()
    {
        _PlayerMovementInput.Disable();
    }
    private void OnMoveForward()
    {
        Debug.Log("Im Running");
        if (!_isMoving)
        {
            //transform.Translate(1,0,0);
            _time = 0;
            _movingForward = true;
        }
    }
    private void OnTurnLeft()
    {
        if (!_isMoving)
        {
            _timerotatingL = 0;
            _movingRight = true;
            if (_directionFacing != 3f)
            {
                _directionFacing += 1;
            }
            else
            {
                _directionFacing = 0;
            }
        }
    }
    private void OnTurnRight()
    {
        if (!_isMoving)
        {
            _timerotatingR = 0;
            _movingLeft = true;
            if (_directionFacing != 0f)
            {
                _directionFacing -= 1;
            }
            else
            {
                _directionFacing = 3;
            }
        }
    }
    private void Update()
    {
        _time += Time.deltaTime;
        _timerotatingR += Time.deltaTime;
        _timerotatingL += Time.deltaTime;
        _isMoving = _time < MoveTime || _timerotatingR < MoveTime || _timerotatingL < MoveTime;
        rb.useGravity = !_isMoving;
        Debug.Log(_directionFacing);
        if (!_isMoving) //reset movement
        {
            _movingForward = false;
            _movingRight = false;
            _movingLeft = false;
            rb.velocity.Set(0, 0, 0);
            var position = transform.position;
            position = new UnityEngine.Vector3(Mathf.Round(position.x), position.y, Mathf.Round(position.z));
            
            transform.position = position;
        }
    }

    private void FixedUpdate()
    {
        if (_movingForward)
        {
            float _jumpPower = Jump.Evaluate(_time) / 2f;
            transform.Translate(0,_jumpPower,0);
            float _directionMultiplyerX = Mathf.Sin(_directionFacing*0.5f*Mathf.PI+0.5f*Mathf.PI);
            float _directionMultiplyerY = Mathf.Sin(_directionFacing*0.5f*Mathf.PI);
            float _walkPowerX = ForwardGraph.Evaluate(_time) * Multiplyer * _directionMultiplyerX;
            float _walkPowerZ = ForwardGraph.Evaluate(_time) * Multiplyer * _directionMultiplyerY;
            rb.AddForce(_walkPowerX, 0, _walkPowerZ);
        }

        if (_movingRight)
        {
            float _JumpPowerRotate = Jump.Evaluate(_timerotatingR) / 2f;
            transform.Translate(0, _JumpPowerRotate, 0);
        }
    }
}
