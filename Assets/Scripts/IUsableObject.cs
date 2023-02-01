using UnityEngine;

public interface IUsableObject 
{
    public void UseObject(){}
    
    public void Grab(Transform parent){}

    public void Drop(){}
}