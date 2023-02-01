using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCamRaycast : MonoBehaviour
{
    [SerializeField] private Image _reticule;
    private bool _isAlreadyGrab;
    private IUsableObject _grabbedObject;
    private void Update()
    {
        UseTarget(FindUsableTarget());

    }

    private IUsableObject FindUsableTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.GetComponent<IUsableObject>() != null)
            {
                _reticule.color = Color.green;
                return hit.collider.GetComponent<IUsableObject>();
            }
            else
            {
                _reticule.color = Color.white;

            }
        }
        else
        {
            _reticule.color = Color.white;

        }
        return null;
    }

    private void UseTarget(IUsableObject usableObject)
    {
        if (Input.GetKeyDown(KeyCode.U) && usableObject != null)
        {
            usableObject.UseObject();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (usableObject != null && !_isAlreadyGrab)
            {
                _isAlreadyGrab = true;
                usableObject.Grab(transform);
                _grabbedObject = usableObject;
            }
        }
        if(Input.GetKeyUp(KeyCode.G)&& _grabbedObject != null && _isAlreadyGrab)
        {
            _isAlreadyGrab = false;
            _grabbedObject.Drop();
        }

    }
}