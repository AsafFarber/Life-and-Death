using UnityEngine;
using UnityEngine.Events;

public class AnyKeyEvent : MonoBehaviour
{
    public UnityEvent onAnyKeyDown;

    void OnGUI()
    {
        if (Event.current.isKey)
        {
            onAnyKeyDown.Invoke();
        }
    }
}
