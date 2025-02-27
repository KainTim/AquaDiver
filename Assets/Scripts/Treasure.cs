using System;

using UnityEngine;
using UnityEngine.InputSystem;

public class Treasure : MonoBehaviour
{
  public int goldAmount;
  private void OnTriggerEnter2D(Collider2D collider2d)
  {
    if (!collider2d.CompareTag("Player")) return;
    var player = collider2d.GetComponent<Inventory>();
    player.inventory.Add(gameObject);
    player.gold += goldAmount;
    DisableCollision();
  }

  private void DisableCollision() => GetComponent<Collider2D>().enabled = false;
}
