using System;

using UnityEngine;

public class Player : MonoBehaviour
{
  Rigidbody2D _rigidbody;

  public float XSpeed;
  public float YSpeed;
  public float Friction;
  void Start()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }
  void Update()
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
      x = _rigidbody.linearVelocity.x*Friction*-1,
      y = _rigidbody.linearVelocity.y*Friction*-1,
    });
    _rigidbody.AddForce(new Vector2()
    {
      x = direction.x * XSpeed,
      y = direction.y * YSpeed,
    });

  }
}
