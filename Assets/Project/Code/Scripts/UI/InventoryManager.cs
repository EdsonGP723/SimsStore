using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] slots;
    public GameObject invntoryItemPrefab;

    public void AddItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    public void SellItem(InventoryItem item)
    {
        GameGlobals.PlayerCoins += item.item.Price - 2;
        Destroy(item.gameObject);
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(invntoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
