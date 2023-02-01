using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectPickable : MonoBehaviour,IUsableObject
{
    public void UseObject(){}

    public void Grab(Transform parent)
    {
        transform.SetParent(parent);
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
        if (GetComponent<Collider>() != null)
        {
            GetComponent<Collider>().enabled = false;
        }

    }

    public void Drop()
    {
        transform.SetParent(null);
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
        if (GetComponent<Collider>() != null)
        {
            GetComponent<Collider>().enabled = true;
        }

    }
}
