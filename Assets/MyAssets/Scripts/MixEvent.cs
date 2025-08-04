using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixEvent : MonoBehaviour
{
    int count = 0;
    int index = 0;

    public List<GameObject> deactivateItems = new List<GameObject>();
    public List<GameObject> activateItems = new List<GameObject>();

    public GameObject top; 
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "mix")
        {
            Debug.Log("Entrou on trigger enter");
            InputEvents.TriggerLaneInput("D");
            ProcessInteraction();
        }
    }

    void ProcessInteraction()
    {
        if (count < 11)
        {
            count++;
            if (index < deactivateItems.Count)
            {
                deactivateItems[index].SetActive(false);
                index++;
            }
        }
        else if (count == 11)
        {
            // instancia a massa 
            top.SetActive(false);
            for (int i = 0; i < activateItems.Count; i++)
            {
                activateItems[i].SetActive(true);
            }
        }
    }
}
