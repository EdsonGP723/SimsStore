using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public Image image;

    [HideInInspector] public Transform parentTransform;
    private InventorySlot originalSlot;

    void Start()
    {
        InitialiseItem(item);
        originalSlot = GetComponentInParent<InventorySlot>();
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.Icon;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentTransform = transform.parent;
        originalSlot = GetComponentInParent<InventorySlot>();
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentTransform);

        InventorySlot newSlot = GetComponentInParent<InventorySlot>();
        if (newSlot != originalSlot && originalSlot != null)
        {
            originalSlot.OnItemRemoved();
        }
    }
}
