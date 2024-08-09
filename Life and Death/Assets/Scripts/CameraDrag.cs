using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] private Camera MainCam;
    private Vector3 _origin;
    private Vector3 _difference;
    private bool _isDragging;
    private void Awake()
    {
        MainCam = Camera.main;
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition;
        _isDragging = ctx.started || ctx.performed;
    }

    private void LateUpdate()
    {
        if (!_isDragging) return;

        _difference = GetMousePosition - MainCam.transform.position;
        MainCam.transform.position = _origin - _difference;
    }

    private Vector3 GetMousePosition => MainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}