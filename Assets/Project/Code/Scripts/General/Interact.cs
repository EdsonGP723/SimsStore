using UnityEngine;
public class Interact : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject SecondaryUI;
    public GameObject Panel;
    public Animator anim;
    private bool activated = false;
    private bool playerInRange = false;

    private void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is in range to interact with the object.");
            playerInRange = true;
            anim.SetBool("canUse", true);

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            anim.SetBool("canUse", false);

        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            activated = !activated;
            InventoryUI.SetActive(activated);
            SecondaryUI.SetActive(activated);
            Panel.SetActive(activated);
        }
    }
}
