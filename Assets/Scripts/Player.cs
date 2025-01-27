using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  private Rigidbody2D _rigidbody;
  public float xSpeed;
  public float ySpeed;
  public float friction;

  private void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {

    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");

    Vector2 direction = new Vector2(x, y).normalized;

    Move(direction);
  }

  private void Move(Vector2 direction)
  {
    _rigidbody.AddForce(new Vector2()
    {
      x = _rigidbody.linearVelocity.x*friction*-1,
      y = _rigidbody.linearVelocity.y*friction*-1,
    });
    _rigidbody.AddForce(new Vector2()
    {
      x = direction.x * xSpeed,
      y = direction.y * ySpeed,
    });

  }
}
