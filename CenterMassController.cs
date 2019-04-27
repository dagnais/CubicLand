using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMassController : MonoBehaviour {
    public bool isActive, isGround, isMassCenter;
    public int id;
    PJController _pjController;

	void Start () {
        _pjController = transform.parent.GetComponent<PJController>();
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            _pjController.rb.velocity = Vector3.zero;
            _pjController.rb.angularVelocity = Vector3.zero;
            _pjController.rb.mass = 10;

            for (int i = 0; i < _pjController.massCentersScript.Length; i++)
            {
                
                if (_pjController.massCentersScript[i].isMassCenter)
                    _pjController.massCentersScript[i].isGround = true;
                else
                {
                    if (_pjController.massCentersScript[i].isActive)
                        _pjController.massCentersScript[i].isGround = true;
                    else
                        _pjController.massCentersScript[i].isGround = false;
                }
                
            }

        }
    }
}
