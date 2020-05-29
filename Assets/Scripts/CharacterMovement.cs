using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Definition of Components
    private Rigidbody2D _body;
    private Animator _animator;
    private Transform _transform;
    
    //Movement-Related Private Variables
    private float _horizontal;
    private float _vertical;
    
    //Movement-Related Public Variables
    public float runSpeed = 10.0f;
    public float moveLimiter = 0.7f;
    
    //Mouse-World-Related Private Variables
    private Vector3 _mousePos;
    private Vector3 _relativePos;

    void Start()
    {
        //Component Assignment
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {    
        //Getting Arrow Input Keys
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        
        //Mouse Position in World Units & Relative Position to player
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _relativePos = _mousePos - transform.position;

    }

    private void FixedUpdate()
    {
        if (_horizontal != 0 && _vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at moveLimiter% speed
            _horizontal *= moveLimiter;
            _vertical *= moveLimiter;
        }     
        Vector2 position = _body.position;
        position.x = position.x + 3.0f * _horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * _vertical * Time.deltaTime;

        _body.MovePosition(position);
    }
    
}
