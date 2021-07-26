using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject InvContents;

    
    public void setVisable(bool visable)
    {
        this.gameObject.SetActive(visable);
    }

    public void InitInv(Container cont)
    {
        GetComponent<ContainerUIBuilder>().buildUI(cont);
    }

    public void UpdateInv(Container cont)
    {
        GetComponent<ContainerUIBuilder>().wipeUI();
        GetComponent<ContainerUIBuilder>().buildUI(cont);
    }
}
