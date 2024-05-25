using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;
    private bool _canMove;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _canMove = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (!_canMove) return;

        float moveX = Input.GetAxis("Horizontal") * _moveSpeed * Time.fixedDeltaTime;
        float moveY = Input.GetAxis("Vertical") * _moveSpeed * Time.fixedDeltaTime;
        _rigidbody.velocity = new Vector2(moveX, moveY);
    }

    public void EnableMove() => _canMove = true;
    public void DisableMove() => _canMove = false;
}
