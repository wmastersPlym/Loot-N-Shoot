using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCreator
{
    
    public static Item getItem(string id, int quantity)
    {
        
        if(id == "APPLE")
        {
            Consumable item = new Consumable();
            item.id = "APPLE";
            item.name = "Apple";
            item.desc = "A delicious looking Apple";
            item.quantity = quantity;
            item.stackable = true;
            item.maxStack = 64;
            item.HealthEffect = 5;
            item.HungerEffect = 15;
            item.HydrationEffect = 5;
            item.BleedEffect = 0;
            return item;
        }

        return null;
    }

}
