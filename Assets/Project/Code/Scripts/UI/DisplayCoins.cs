using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{

    public TextMeshProUGUI coinText;
    void Update()
    {
        coinText.text = GameGlobals.PlayerCoins.ToString();
    }
}
