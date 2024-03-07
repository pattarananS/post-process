using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // --- global variable ---
    [SerializeField] float speed = 6f; //for adjusting speed
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Transform cam;
    [SerializeField] AudioSource tankEngine;
    [SerializeField] float currentPitch = 0f;
    [SerializeField] float maxPitch = 1.5f;

    private float turnSmoothVelocity;
    private CharacterController controller; // for import character controller

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }//end of start()

    // Update is called once per frame
    void Update()
    {
        //get WASD from input manager
        float horizontal = Input.GetAxisRaw("Horizontal1");
        float vertical = Input.GetAxisRaw("Vertical1");

        //build vector 3 to define character's direction and covert it to vector1 with .normalized
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //move object
        if(direction.magnitude >= 0.1f)
        {
            //engine rising
            if(currentPitch < maxPitch)
            {
                
                currentPitch += 0.1f;
                tankEngine.pitch = currentPitch;
            }

            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //caculate camera's direction
            

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smoothes player turn

            this.transform.rotation = Quaternion.Euler(0f , angle , 0f); //turns player

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime); //move player
        } 
        else
        {
            if (currentPitch > 0.5)
            {
                    currentPitch -= 0.1f;
                    tankEngine.pitch = currentPitch;
            } 
        }//end of if

    }//end of update()
}//end of class{}
