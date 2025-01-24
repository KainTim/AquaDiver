using UnityEngine;
using UnityEngine.Tilemaps;

public class Hide : MonoBehaviour
{
  TilemapRenderer _tilemapRenderer;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
    {
    _tilemapRenderer = GetComponent<TilemapRenderer>();
    _tilemapRenderer.enabled = false;
  }

}
