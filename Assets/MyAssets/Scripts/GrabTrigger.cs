using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrigger : MonoBehaviour
{
    public void InputNote()
    {
        InputEvents.TriggerLaneInput("D");
    }
 
}
