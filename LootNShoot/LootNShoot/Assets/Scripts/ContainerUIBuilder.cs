using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerUIBuilder : MonoBehaviour
{


    public GameObject ContainerUIContents;

    public GameObject ItemContainerPrefab;
    public GameObject ItemCardPrefab;

    public void buildUI(Container cont)
    {


        print("Build UI");
        cont.printContents();
        print("EndInv");
        for (int i = 0; i < cont.sizeX; i++)
        {
            for (int ii = 0; ii < cont.sizeY; ii++)
            {
                GameObject obj = Instantiate(ItemContainerPrefab, ContainerUIContents.transform);

                if(cont.items[i,ii] != null)
                {
                    GameObject itemObj = Instantiate(ItemCardPrefab, obj.transform);
                    itemObj.GetComponent<ItemCard>().CreateCard(cont.items[i, ii]);
                }
            }
        }
    }

    public void wipeUI()
    {
        foreach (Transform child in ContainerUIContents.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
