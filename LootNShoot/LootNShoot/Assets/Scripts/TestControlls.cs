using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControlls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            print("Test set Inv");
            //GetComponent<Container>().SetSize(2, 2);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            print("Test print Inv");
            GetComponent<Container>().printContents();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {

            Item apple = ItemCreator.getItem("APPLE", 32);


            bool worked = GetComponent<Container>().AddItem(apple);
            print("Test AddTo Inv, Worked: " + worked.ToString());


        }
    }
}
