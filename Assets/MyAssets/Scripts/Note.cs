using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));


        if (t > 1f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnX, Vector3.up * SongManager.Instance.noteDespawnX, t);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void disableNoteRenderer()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Func called");
    }
}
