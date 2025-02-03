using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 20f;
  public float lifetime = 3f;

  private void Start()
  {
    Destroy(gameObject, lifetime); // Destroy bullet after X seconds
  }

  public void Fire(Vector3 direction)
  {
    GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
  }
}
