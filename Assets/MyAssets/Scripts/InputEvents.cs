using System;

public static class InputEvents 
{
    public static event Action<string> OnLaneInput;

    public static void TriggerLaneInput(string laneID)
    {
        OnLaneInput?.Invoke(laneID);
    }
}
