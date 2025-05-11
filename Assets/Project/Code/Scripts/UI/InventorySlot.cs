using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public SlotType slotType;
    public enum SlotType
    {
        Hair,
        Outfit,
        Selling,
        Iventory
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentTransform = transform;

            switch (slotType)
            {
                case SlotType.Hair:
                    // Stuff
                    break;
                case SlotType.Outfit:
                    //Stuff
                    break;
                case SlotType.Selling:
                    InventoryManager inventoryManager = FindFirstObjectByType<InventoryManager>();
                    inventoryManager.SellItem(inventoryItem);
                    break;
            }
        }
    }

}
