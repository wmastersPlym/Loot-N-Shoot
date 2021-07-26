using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class xy
{
    public int x;
    public int y;

    
    public xy(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Container : MonoBehaviour
{

    public int sizeX = 6;
    public int sizeY = 4;

    public Item[,] items;

    private void Awake()
    {
        SetSize(sizeX, sizeY);
    }



    public void SetSize(int x, int y)
    {
        items = new Item[x, y];
    }

    public bool AddItem(Item item)
    {
        // Check if stackable
        if(item.stackable)
        {
            // check if already in Container
            List<xy> positions = GetPosOfItem(item);
            if(positions.Count > 0)
            {
                for(int i=0; i < positions.Count; i++) // Goes through each stack of item
                {
                    if(items[positions[i].x, positions[i].y].quantity < item.maxStack) // Checks if stack isnt full
                    {
                        items[positions[i].x, positions[i].y].quantity += item.quantity;
                        // Checks for overflow
                        if(items[positions[i].x, positions[i].y].quantity > item.maxStack)
                        {
                            Item overflow = item;
                            overflow.quantity = items[positions[i].x, positions[i].y].quantity - item.maxStack;
                            items[positions[i].x, positions[i].y].quantity -= overflow.quantity;
                            AddItem(overflow);
                        }
                        return true;
                    }
                }
            }
        }

        // Check if space free
        xy freePos = GetPosOfNextFreeSpace();
        if(freePos.x != -1)
        {
            // Add to new space
            items[freePos.x, freePos.y] = item;
            return true;
        }






        return false;
    }


    public void printContents()
    {
        for(int i=0; i < items.GetLength(0); i++)
        {
            for (int ii=0; ii < items.GetLength(1); ii++)
            {
                if(items[i, ii] != null)
                {
                    print("ID: " + items[i, ii].id + ", Name: " + items[i, ii].name + ", Quantity: " + items[i, ii].quantity.ToString());
                } else
                {
                    print("Empty");
                }
                
            }
        }
    }




    private List<xy> GetPosOfItem(Item item)
    {
        List<xy> positions = new List<xy>();
        for (int i = 0; i < items.GetLength(0); i++)
        {
            for (int ii = 0; ii < items.GetLength(1); ii++)
            {
                if (items[i, ii] != null && items[i, ii].id.Equals(item.id))
                {
                   positions.Add(new xy(i, ii));
                }

            }
        }

        return positions;
    }
    private xy GetPosOfItem(Item item, int x, int y)
    {
        bool skip = true;
        for (int i = x; i < items.GetLength(0); i++)
        {
            for (int ii = y; ii < items.GetLength(1); ii++)
            {
                if(skip)
                {
                    skip = false;
                    
                } else if (items[i, ii] != null && items[i, ii].id.Equals(item.id))
                {
                    return new xy(i, ii);
                }

            }
        }
        return new xy(-1, -1);
    }
    private xy GetPosOfNextFreeSpace()
    {
        for (int i = 0; i < items.GetLength(0); i++)
        {
            for (int ii = 0; ii < items.GetLength(1); ii++)
            {
                if (items[i, ii] == null)
                {
                    return new xy(i, ii);
                }

            }
        }
        return new xy(-1, -1);
    }
}
