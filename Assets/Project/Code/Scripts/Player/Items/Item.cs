using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public int Price;
    public Sprite Icon;
    public SpriteLibraryAsset Library;
    public bool Owned;

}
