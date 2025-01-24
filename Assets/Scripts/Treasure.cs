using System;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class Treasure : MonoBehaviour
{
  private SpriteRenderer _spriteRenderer;
  public Sprite openSprite;

  private void Start() => _spriteRenderer = GetComponent<SpriteRenderer>();

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      _spriteRenderer.sprite = openSprite;
    }
  }
}
