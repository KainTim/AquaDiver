using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float lifetime = 3f;
  public int damage = 1;

  private void Start()
  {
    Destroy(gameObject, lifetime); // Destroy bullet after X seconds
  }

  public void Fire(Vector3 direction, float speed)
  {
    GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
  }
}
