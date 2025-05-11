using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToAdd;

    public void PickUpItem(int id)
    {
        if (GameGlobals.PlayerCoins >= itemsToAdd[id].Price)
        {
            inventoryManager.AddItem(itemsToAdd[id]);
            GameGlobals.PlayerCoins -= itemsToAdd[id].Price;
            Debug.Log(GameGlobals.PlayerCoins);
        }
    }
}
