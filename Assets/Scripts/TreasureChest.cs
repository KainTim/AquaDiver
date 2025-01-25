using System;

using JetBrains.Annotations;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TreasureChest : MonoBehaviour
{
  private SpriteRenderer _spriteRenderer;
  public Sprite openSprite;
  [CanBeNull] public GameObject treasure;

  private void Start()
  {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    if (treasure != null) treasure.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D player)
  {
    if (!player.CompareTag("Player")) return;
    _spriteRenderer.sprite = openSprite;
    if (treasure != null) treasure.SetActive(true);
    DisableCollision();
  }

  private void DisableCollision() => GetComponent<Collider2D>().enabled = false;
}
