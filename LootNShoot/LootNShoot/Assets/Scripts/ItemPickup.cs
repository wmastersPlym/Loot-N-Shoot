using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public string id;

    public GameObject Model;

    public Item item;

    private void Awake()
    {
        item = ItemCreator.getItem(id, 1);
    }

    private void Start()
    {
        this.item = ItemCreator.getItem(id, 1);

        print(item.name);
    }

    public void PickedUp()
    {
        Destroy(this.gameObject);
    }


}
