using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public List<GameObject> trigger_list = new List<GameObject>();
    private int listIndex = 0;
    public static event Action TriggerFinished;

    private void OnEnable()
    {
        TriggerFinished += NextEvent;
    }

    private void OnDisable()
    {
        TriggerFinished -= NextEvent;
    }

    // passa para o próximo evento
    public void NextEvent()
    {
        if (listIndex < trigger_list.Count - 1)
        {
            trigger_list[listIndex].SetActive(false);
            trigger_list[++listIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Fim da lista de eventos.");
        }
    }
    
    public static void NotifyTriggerFinished()
    {
        TriggerFinished?.Invoke();
    }
}
