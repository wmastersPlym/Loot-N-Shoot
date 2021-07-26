using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed;
    public float sprintSpeed;

    public float backAndSideSpeed;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zMove = Input.GetAxis("Vertical") * (SprintHeld() ? sprintSpeed : walkSpeed) * Time.deltaTime;




    }

    bool SprintHeld()
    {
        return (Input.GetKey(KeyCode.LeftShift)) ;
    }
}
