using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SlotType slotType;
    public enum SlotType
    {
        Hair,
        Outfit,
        Selling,
        Iventory
    }

    private InventoryManager inventoryManager;
    private InventoryItem currentItem;

    private void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            currentItem = GetComponentInChildren<InventoryItem>();
            HandleUnequip();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Requerido por la interfaz
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentItem != null && currentItem.transform.parent != transform)
        {
            HandleUnequip();
            currentItem = null;
        }
    }

    private void HandleUnequip()
    {
        switch (slotType)
        {
            case SlotType.Hair:
                inventoryManager.UnequipHair();
                break;
            case SlotType.Outfit:
                inventoryManager.UnequipOutfit();
                break;
        }
    }

    public void OnItemRemoved()
    {
        HandleUnequip();
        currentItem = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            
            if (currentItem != null)
            {
                OnItemRemoved();
            }
            
            inventoryItem.parentTransform = transform;
            currentItem = inventoryItem;

            switch (slotType)
            {
                case SlotType.Hair:
                    inventoryManager.EquipHair(inventoryItem);
                    break;
                case SlotType.Outfit:
                    inventoryManager.EquipOutfit(inventoryItem);
                    break;
                case SlotType.Selling:
                    inventoryManager.SellItem(inventoryItem);
                    break;
            }
        }
    }
}
