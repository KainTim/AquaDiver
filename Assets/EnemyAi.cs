using UnityEngine;

public class EnemyAi : MonoBehaviour
{
  public float detectionRadius = 5f; // Radius to detect the player
  public float speed = 2f; // Movement speed

  private Transform player; // Reference to the player

  private void Start()
  {
    // Find the player by tag
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  private void Update()
  {
    if (player == null) return;

    // Calculate distance between enemy and player
    float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    // If the player is within detection radius, move toward them
    if (distanceToPlayer <= detectionRadius)
    {
      MoveTowardPlayer();
    }
  }

  private void MoveTowardPlayer()
  {
    // Calculate direction toward the player
    Vector2 direction = (player.position - transform.position).normalized;

    // Move the enemy toward the player
    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("Collision detected");
    // Check if the enemy collided with a bullet
    if (collision.CompareTag("Bullet"))
    {
      Debug.Log("Bullet hit enemy");
      Destroy(gameObject); // Destroy the enemy
      Destroy(collision.gameObject); // Destroy the bullet
    }
  }

  private void OnDrawGizmosSelected()
  {
    // Draw the detection radius in the editor for visualization
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, detectionRadius);
  }
}
