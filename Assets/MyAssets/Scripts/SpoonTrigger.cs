using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonTrigger : MonoBehaviour
{
    public GameObject salt;
    public string tag1 = "spoon";
    public string tag2 = "sack";
    public List<GameObject> objects = new List<GameObject>();
    int listIndex = 0;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tag1)
        {
            InputEvents.TriggerLaneInput("D");
            DeactivateSalt();
            Debug.Log("Entou " + tag1);
            ProcessInteraction();
        }
        else if (col.gameObject.tag == tag2)
        {
            InputEvents.TriggerLaneInput("D");
            ActivateSalt();
            Debug.Log("Entou + "  + tag2);
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

            DeactivateSalt();
        }
        else
        {
            Debug.Log("Acabou a lista");
        }

    }

    public void ActivateSalt()
    {
        salt.GetComponent<MeshRenderer>().enabled = true;
    }

    public void DeactivateSalt()
    {
        salt.GetComponent<MeshRenderer>().enabled = false;
    }

}
