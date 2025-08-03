using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBottom : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tag1)
        {
            InputEvents.TriggerLaneInput("D");
            DeactivateSalt();
            Debug.Log("Entou " + tag1);
            ProcessInteraction();
        }
    }
}
