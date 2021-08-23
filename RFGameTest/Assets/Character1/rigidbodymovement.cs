using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodymovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    bool jump;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool canjump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "floor")
        {
            //Debug.Log("touching");
            canjump = true;
        }
        else
        {
            //Debug.Log("nottouching");
            canjump = false;
        }
        
    }

    




    void Update()
    {

        
        if (Input.GetKeyDown("space") && canjump)
        {
                canjump = false;
                //jump height
                m_Rigidbody.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
                

	    }
    }


    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

        if (m_Input.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(m_Input.x, m_Input.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }


        
    }

    


}
