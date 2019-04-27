using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJController : MonoBehaviour {
    public float speed=200, max=4;
    public Transform[] massCenters;
    public CenterMassController[] massCentersScript;
    [HideInInspector]
    public Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = max;
	}
	
	void FixedUpdate () {
        rb.maxAngularVelocity = max;
        Move();

	}

    void Move()
    {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        int turn;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            turn = 10;
            rb.centerOfMass = massCenters[3].localPosition;
            if (massCentersScript[1].isActive)
            {
                rb.mass = 1;
                rb.angularVelocity = Vector3.zero;
            }
            massCentersScript[0].isActive = true;

            massCentersScript[1].isActive = false;
            massCentersScript[2].isActive = false;
            massCentersScript[3].isActive = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                turn = -10;
                rb.centerOfMass = massCenters[2].localPosition;
                if (massCentersScript[0].isActive)
                {
                    rb.mass = 1;
                    rb.angularVelocity = Vector3.zero;
                }

                massCentersScript[1].isActive = true;

                massCentersScript[0].isActive = false;
                massCentersScript[2].isActive = false;
                massCentersScript[3].isActive = false;
            }
            else
                turn = 0;
            
        }
        rb.AddTorque(transform.right * (speed*100) * turn, ForceMode.Impulse);
    }
}
