using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject tomato;
    [SerializeField] GameObject slicedTomato;

    public EventManager _eventManager;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "trigger")
        {
            Debug.Log("Entrou on trigger enter");
            InputEvents.TriggerLaneInput("D");
            ProcessInteraction();
        }
    }

    void ProcessInteraction()
    {
        Debug.Log("[EventManager]: Entrou");
        Debug.Log(count);
        if (count < 3)
        {
            count++;
            Debug.Log("[EventManager]: primeiro if");
        }
        else if (count == 3)
        {
            tomato.SetActive(false);
            slicedTomato.SetActive(true);
            count++;
            
        }
        else
        {
            FinishInteraction();
            Debug.Log("[EventManager]: Evento finalizado");
        }
    }
    
    void FinishInteraction()
    {
        Debug.Log("[TomatoTrigger]: Interaction finished!");
        EventManager.NotifyTriggerFinished();
    }

}
