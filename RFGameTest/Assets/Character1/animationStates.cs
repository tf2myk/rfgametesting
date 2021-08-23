using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This shit is so bad 

public class animationStates : MonoBehaviour
{
    Animator animstates;
     CharacterController controller;

    float ButtonCoolerup = 0.5f ; // Half a second before reset
    int ButtonCountup = 0;

    float ButtonCoolerdown = 0.5f ; // Half a second before reset
    int ButtonCountdown = 0;

    float ButtonCoolerleft = 0.5f ; // Half a second before reset
    int ButtonCountleft = 0;

    float ButtonCoolerright = 0.5f ; // Half a second before reset
    int ButtonCountright = 0;

    bool movekey;

    bool canjump;




    void Start()
    {
        animstates = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "floor")
        {
            animstates.SetBool("isGrounded", true);
            canjump = true;
        }
        else
        {
            
        }
        
    }

    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && canjump)
        {
            animstates.SetBool("isGrounded", false);
            canjump = false;
            return;
                
	    }

        
        



        if(Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            movekey = true;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        
        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown("up"))
            {
                if ( ButtonCoolerup > 0 && ButtonCountup == 1/*Number of Taps you want Minus One*/)
                {
                    animstates.SetBool("isWalking", true);
                    animstates.SetBool("isRunning", true);
                    
                    
                }else
                {
                    animstates.SetBool("isWalking", true);
                    ButtonCoolerup = 0.5f; 
                    ButtonCountup += 1 ;
                }
            }
        }
        else if(!movekey)
        {
            animstates.SetBool("isWalking", false);
            animstates.SetBool("isRunning", false);
        }

        ///////////////////////////////////


        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown("down"))
            {
                if ( ButtonCoolerdown > 0 && ButtonCountdown == 1/*Number of Taps you want Minus One*/)
                {
                    animstates.SetBool("isWalking", true);
                    animstates.SetBool("isRunning", true);
                    
                    
                }else
                {
                    animstates.SetBool("isWalking", true);
                    ButtonCoolerdown = 0.5f; 
                    ButtonCountdown += 1 ;
                }
            }
        }
        else if(!movekey)
        {
            animstates.SetBool("isWalking", false);
            animstates.SetBool("isRunning", false);
        }


        //////////////////////////////////////////


        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown("left"))
            {
                if ( ButtonCoolerleft > 0 && ButtonCountleft == 1/*Number of Taps you want Minus One*/)
                {
                    animstates.SetBool("isWalking", true);
                    animstates.SetBool("isRunning", true);
                    
                    
                    
                }else
                {
                    animstates.SetBool("isWalking", true);
                    ButtonCoolerleft = 0.5f; 
                    ButtonCountleft += 1 ;
                }
            }
        }
        else if(!movekey)
        {
            animstates.SetBool("isWalking", false);
            animstates.SetBool("isRunning", false);
        }

        ////////////////////


        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown("right"))
            {
                if ( ButtonCoolerright > 0 && ButtonCountright == 1/*Number of Taps you want Minus One*/)
                {
                    animstates.SetBool("isWalking", true);
                    animstates.SetBool("isRunning", true);
                    
                    
                }else
                {
                    animstates.SetBool("isWalking", true);
                    ButtonCoolerright = 0.5f; 
                    ButtonCountright += 1 ;
                }
            }
        }
        else if(!movekey)
        {
            animstates.SetBool("isWalking", false);
            animstates.SetBool("isRunning", false);
        }

        


        if ( ButtonCoolerup > 0 || ButtonCoolerdown > 0 || ButtonCoolerleft > 0 || ButtonCoolerright > 0)
        {
            ButtonCoolerup -= 1 * Time.deltaTime ;
            ButtonCoolerdown -= 1 * Time.deltaTime ;
            ButtonCoolerleft -= 1 * Time.deltaTime ;
            ButtonCoolerright -= 1 * Time.deltaTime ;

            movekey = false;
        }
        else
        {
            ButtonCountup = 0 ;
            ButtonCountdown = 0 ;
            ButtonCountleft = 0 ;
            ButtonCountright = 0 ;

            movekey = false;
        }
 }














}

