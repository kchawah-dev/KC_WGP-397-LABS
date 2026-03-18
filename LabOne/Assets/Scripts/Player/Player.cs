using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();

        // 🔹 Add test items
        Item attack = Resources.Load<Item>("Items/AttackUp");
        Item coin = Resources.Load<Item>("Items/Coin");

        if (attack != null) inventory.AddItem(attack);
        if (coin != null) inventory.AddItem(coin);

        Debug.Log("Test items added");
    }

    private void Update()
    {
        // 🔹 Press K to Save
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveSystem.SavePlayer(this);
            Debug.Log("Game Saved");
        }

        // 🔹 Press L to Load
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
            Debug.Log("Game Loaded");
        }
    }

    void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data == null) return;

        // Load position
        transform.position = new Vector3(
            data.position[0],
            data.position[1],
            data.position[2]
        );

        // Load inventory
        inventory.LoadItems(data.inventoryItems);

        // Debug inventory contents
        foreach (var item in inventory.items)
        {
            Debug.Log("Loaded item: " + item.itemName);
        }
    }
}