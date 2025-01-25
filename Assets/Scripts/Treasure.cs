using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class Treasure : MonoBehaviour
{
  public int goldAmount;
  private void OnTriggerEnter2D(Collider2D collider2d)
  {
    Debug.Log("Player entered treasure");
    if (!collider2d.CompareTag("Player")) return;
    var player = collider2d.GetComponent<Player>();
    player.inventory.Add(gameObject);
    player.gold += goldAmount;
    DisableCollision();
  }

  private void DisableCollision() => GetComponent<Collider2D>().enabled = false;
}
