using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject tomato;
    [SerializeField] GameObject slicedTomato;

    void OnEnable()
    {
        // Inscreve o método ao evento
        TriggerObject.OnMyEvent += MyMethod;
        Debug.Log("[EventManager]: Event subscribed");
    }

    void OnDisable()
    {
        // Cancela a inscrição para evitar erros
        TriggerObject.OnMyEvent -= MyMethod;
        Debug.Log("[EventManager]: MyMethod unsubscribed to TriggerObj");
    }

    void MyMethod()
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
            Debug.Log("[EventManager]: Evento finalizado");
        }
    }
}
