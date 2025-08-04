using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBottom : MonoBehaviour
{
    public GameObject eggshell;
    public GameObject white;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "eggbreaker")
        {
            InputEvents.TriggerLaneInput("D");
            eggshell.GetComponent<MeshRenderer>().enabled = false; 
        }

        if (col.gameObject.tag == "egg")
        {
            InputEvents.TriggerLaneInput("D");
            white.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
