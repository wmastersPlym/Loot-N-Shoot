using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public Camera cam;

    public float reachDistance;

    public Image Indicator;
    public Text IndicatorText;

    public Container inv;

    public InventoryUI InvUI;

    private void Start()
    {
        Indicator.enabled = false;

        // Load inv


        // Initialise inv UI
        if (InvUI != null)
        {
            InvUI.InitInv(inv);
        }
        InvUI.setVisable(false);
    }

    private void Update()
    {

        // handles close range Interactions with pickupable items
        Interactions();

        // Opens and closes the players inv
        InventoryControlls();
    }

    private void InventoryControlls()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // Updates UI
            InvUI.UpdateInv(inv);

            // Show inv
            InvUI.setVisable(true);

            // Unlocks mouse
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            // Hide inv
            InvUI.setVisable(false);

            // Locks mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    private void Interactions()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (hit.transform.gameObject.tag == "Item")
            {
                Indicator.enabled = true;

                Item item = hit.transform.GetComponent<ItemPickup>().item;

                IndicatorText.text = item.name + ": " + item.quantity;
                //GameObject ob = hit.transform.gameObject;
                //
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("Pickup item");
                    inv.AddItem(item);
                    hit.transform.gameObject.GetComponent<ItemPickup>().PickedUp();
                }

            }
            else
            {
                Indicator.enabled = false;
                IndicatorText.text = "";
            }
        }
        else
        {
            Indicator.enabled = false;
            IndicatorText.text = "";
        }
    }
}
