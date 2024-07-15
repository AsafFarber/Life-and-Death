using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1f; // Speed of zooming
    public float minZoom = 2f; // Minimum orthographic size
    public float maxZoom = 10f; // Maximum orthographic size
    public void OnZoom(InputAction.CallbackContext context)
    {
        float scrollValue = context.ReadValue<Vector2>().y;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scrollValue * zoomSpeed, minZoom, maxZoom);
    }
    public void Quit(InputAction.CallbackContext context)
    {

        Application.Quit();
    }
}
