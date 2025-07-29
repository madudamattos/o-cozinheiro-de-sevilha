using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public delegate void MyEventDelegate();
    public static event MyEventDelegate OnMyEvent;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "trigger")
        {
            Debug.Log("Entrou on trigger enter");
            OnMyEvent?.Invoke();
        }
        
    }
}
