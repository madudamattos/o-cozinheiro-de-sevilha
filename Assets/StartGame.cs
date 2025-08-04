using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject particle;
    public GameObject menu;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject knife;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "trigger")
        {
            menu.SetActive(false);
            particle.SetActive(true);
            Invoke(nameof(ActivateScene), 0.2f);
        }
    }

    public void ActivateScene()
    {
        knife.SetActive(false);
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
    }
}
