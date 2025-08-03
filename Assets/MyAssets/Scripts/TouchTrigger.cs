using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTrigger : MonoBehaviour
{
    public string tag;
    public List<GameObject> objects = new List<GameObject>();
    int listIndex = 0;
    // Start is called before the first frame update
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tag)
        {
            Debug.Log("Entrou on trigger enter");
            InputEvents.TriggerLaneInput("D");
            ProcessInteraction();
        }
    }

    void ProcessInteraction()
    {
        if (listIndex < objects.Count)
        {
            if (listIndex > 0)
            {
                Destroy(objects[listIndex - 1].gameObject);
            }
            objects[listIndex].SetActive(true);
            listIndex++;
        }
        else
        {
            Debug.Log("Acabou a lista");
        }
    }
}
