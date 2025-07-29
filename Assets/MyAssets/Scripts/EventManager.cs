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
        Debug.Log("Event subscribed");
    }

    void OnDisable()
    {
        // Cancela a inscrição para evitar erros
        TriggerObject.OnMyEvent -= MyMethod;
        Debug.Log("Event unsubscribed");
    }

    void MyMethod()
    {
        Debug.Log("Called method");
        Debug.Log(count);
        if (count < 3)
        {
            count++;
            Debug.Log("primeiro if");
        }
        else if (count == 3)
        {
            tomato.SetActive(false);
            slicedTomato.SetActive(true);
            count++;
        }
        else
        {
            Debug.Log("Evento finalizado");
        }
    }
}
