using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : MonoBehaviour
{
    int count = 0;
    bool flag = false;

    public List<GameObject> deactivateItems = new List<GameObject>();
    public List<GameObject> activateItems = new List<GameObject>();

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "white")
        {
            col.gameObject.SetActive(false);
            count++;
        }
    }

    void Update()
    {
        if (!flag && count == 4)
        {
            flag = true;
            StartCoroutine(ExecutarAcoesComDelay());
        }
    }

    IEnumerator ExecutarAcoesComDelay()
    {
        yield return new WaitForSeconds(1f); // espera 1 segundo

        for (int i = 0; i < deactivateItems.Count; i++)
        {
            deactivateItems[i].SetActive(false);
        }

        for (int i = 0; i < activateItems.Count; i++)
        {
            activateItems[i].SetActive(true);
        }
    }
}
