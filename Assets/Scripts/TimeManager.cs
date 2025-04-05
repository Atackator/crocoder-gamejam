using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private TimeController[] timeControllers;

    void Update()
    {
        timeControllers = FindObjectsOfType<TimeController>();
        foreach (TimeController controller in timeControllers)
        {
            controller.TimeUpdate();
        }
    }
}
