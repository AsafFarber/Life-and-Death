using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    [SerializeField] private float zoomSpeed = 1f; // Speed of zooming
    [SerializeField] private float minZoom = 2f; // Minimum orthographic size
    [SerializeField] private float maxZoom = 10f; // Maximum orthographic size
    public void SetZoom(float level)
    {
        Debug.Log(level);
        if(level == 1)
        {
            foreach (Camera cam in cameras)
                cam.orthographicSize = 4;
        }
        if (level == 2)
        {
            foreach (Camera cam in cameras)
                cam.orthographicSize = 6;
        }
    }
    public void OnZoom(InputAction.CallbackContext context)
    {
        float scrollValue = context.ReadValue<Vector2>().y;
        foreach(Camera cam in cameras)
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - scrollValue * zoomSpeed, minZoom, maxZoom);
    }
    public void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
