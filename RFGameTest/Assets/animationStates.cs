using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStates : MonoBehaviour
{
    Animator animstates;
    public CharacterController controller;

    float ButtonCooler = 0.5f ; // Half a second before reset
    int ButtonCount = 0;


    void Start()
    {
        animstates = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        
        if (direction.magnitude >= 0.1f)
        {
            if (Input.anyKeyDown)
            {
                if ( ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
                {
                    animstates.SetBool("isWalking", true);
                    animstates.SetBool("isRunning", true);
                    
                    
                }else
                {
                    animstates.SetBool("isWalking", true);
                    ButtonCooler = 0.5f; 
                    ButtonCount += 1 ;
                }
            }
        }
        else if(direction.magnitude < 0.1f)
        {
            animstates.SetBool("isWalking", false);
            animstates.SetBool("isRunning", false);
        }


        if ( ButtonCooler > 0 )
        {
            ButtonCooler -= 1 * Time.deltaTime ;
        }
        else
        {
            ButtonCount = 0 ;
        }
 }














}

