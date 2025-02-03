using System.Collections;

using Unity.Cinemachine;

using UnityEngine;

public class CameraZoom : MonoBehaviour
{
  public float DefaultZoom = 7f;
  public float ZoomedOutZoom = 15f;
  public float DefaultSpeedX = 20f;
  public float DefaultSpeedY = 14f;
  public float BuffedSpeedX = 50f;
  public float BuffedSpeedY = 40f;
  public CinemachineCamera Camera;
  public Player Player;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Check if the player collided with the camera zoom trigger
    if (collision.CompareTag("Player"))
    {
      Player.xSpeed = BuffedSpeedX;
      Player.ySpeed = BuffedSpeedY;
      StartCoroutine(SmoothZoom(ZoomedOutZoom, 1f));
    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    // Check if the player exited the camera zoom trigger
    if (collision.CompareTag("Player"))
    {
      // Zoom the camera in

      Player.xSpeed = DefaultSpeedX;
      Player.ySpeed = DefaultSpeedY;
      StartCoroutine(SmoothZoom(DefaultZoom, 1f));
    }
  }
  private IEnumerator SmoothZoom(float targetSize, float duration)
  {
    float initialSize = Camera.Lens.OrthographicSize;
    float elapsedTime = 0f;

    while (elapsedTime < duration)
    {
      // Calculate the current zoom level based on the elapsed time and duration
      float currentSize = Mathf.Lerp(initialSize, targetSize, elapsedTime / duration);

      // Set the camera's orthographic size to the current zoom level
      Camera.Lens.OrthographicSize = currentSize;

      // Increment the elapsed time
      elapsedTime += Time.deltaTime;

      // Wait for the next frame
      yield return null;
    }

    // Ensure that the final zoom level is set correctly
    Camera.Lens.OrthographicSize = targetSize;
  }
}
