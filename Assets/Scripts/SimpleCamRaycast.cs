using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCamRayscast : MonoBehaviour
{
    [SerializeField] private Image _reticule;

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

    }
}