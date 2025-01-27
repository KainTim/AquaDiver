using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{

  public List<GameObject> inventory;
  private readonly Dictionary<GameObject, SpriteRenderer> _inventoryRenderers = new();
  private GameObject _selectedItem;
  public int gold;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

    inventory ??= new List<GameObject>();
    InputSystem.actions.FindAction("Hotbar 1").performed += Hotbar1;
    InputSystem.actions.FindAction("Hotbar 2").performed += Hotbar2;
    InputSystem.actions.FindAction("Hotbar 3").performed += Hotbar3;
    InputSystem.actions.FindAction("Hotbar 4").performed += Hotbar4;
    InputSystem.actions.FindAction("Hotbar 5").performed += Hotbar5;
    InputSystem.actions.FindAction("Hotbar 6").performed += Hotbar6;
    InputSystem.actions.FindAction("Hotbar 7").performed += Hotbar7;
    InputSystem.actions.FindAction("Hotbar 8").performed += Hotbar8;
    InputSystem.actions.FindAction("Hotbar 9").performed += Hotbar9;
    InputSystem.actions.FindAction("Hotbar 10").performed += Hotbar10;
  }

  private void Hotbar1(InputAction.CallbackContext context) => SelectItem(0);
  private void Hotbar2(InputAction.CallbackContext context) => SelectItem(1);
  private void Hotbar3(InputAction.CallbackContext context) => SelectItem(2);
  private void Hotbar4(InputAction.CallbackContext context) => SelectItem(3);
  private void Hotbar5(InputAction.CallbackContext context) => SelectItem(4);
  private void Hotbar6(InputAction.CallbackContext context) => SelectItem(5);
  private void Hotbar7(InputAction.CallbackContext context) => SelectItem(6);
  private void Hotbar8(InputAction.CallbackContext context) => SelectItem(7);
  private void Hotbar9(InputAction.CallbackContext context) => SelectItem(8);
  private void Hotbar10(InputAction.CallbackContext context) => SelectItem(9);


  private void SelectItem(int index)
  {
    if (index < 0) return;
    if (index >= inventory.Count)
    {
      _selectedItem = null;
      return;
    }
    _selectedItem = inventory[index];
  }

  // Update is called once per frame
  void Update()
  {
    foreach (var o in inventory)
    {
      o.transform.position = transform.position;
      if (_inventoryRenderers.ContainsKey(o))
      {
        if (o != _selectedItem)
        {
          _inventoryRenderers[o].enabled = false;
          continue;
        }
        _inventoryRenderers[o].enabled = true;
        continue;
      }
      {
        Debug.Log("Adding renderer");
        _inventoryRenderers.Add(o, o.GetComponent<SpriteRenderer>());
      }
    }
  }
}
