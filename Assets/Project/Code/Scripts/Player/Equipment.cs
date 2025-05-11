using UnityEngine;
using UnityEngine.U2D.Animation;

public class Equipment : MonoBehaviour
{
    public SpriteLibrary Hair;
    public SpriteLibrary Outfit;
    
    private SpriteRenderer hairRenderer;
    private SpriteRenderer outfitRenderer;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
        hairRenderer = Hair.GetComponent<SpriteRenderer>();
        outfitRenderer = Outfit.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Manejo del Hair
        if (inventoryManager.Hair != null)
        {
            Hair.spriteLibraryAsset = inventoryManager.Hair;
            hairRenderer.enabled = true;
        }
        else
        {
            Hair.spriteLibraryAsset = null;
            hairRenderer.enabled = false;
        }

        // Manejo del Outfit
        if (inventoryManager.Outfit != null)
        {
            Outfit.spriteLibraryAsset = inventoryManager.Outfit;
            outfitRenderer.enabled = true;
        }
        else
        {
            Outfit.spriteLibraryAsset = null;
            outfitRenderer.enabled = false;
        }
    }
}
