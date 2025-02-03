using UnityEngine;

public class Weapon : MonoBehaviour
{

  public GameObject bulletPrefab;
  public Transform firePoint;
  public Camera mainCamera;

  public float bulletSpeed = 20f;

  public void Fire()
  {
    // Get mouse position in world coordinates
    Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    mouseWorldPos.z = 0; // Ensure it's in 2D space

    // Calculate direction from firePoint to mouse position
    Vector2 direction = (mouseWorldPos - firePoint.position).normalized;

    // Instantiate bullet and fire it
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    bullet.GetComponent<Bullet>().Fire(direction, bulletSpeed);
  }
}
