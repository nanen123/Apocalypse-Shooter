using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private InputAction mouseXMoveAction;
    [SerializeField] private InputAction mouseYMoveAction;
    [SerializeField] private Vector2 mouseAxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseXMoveAction = InputSystem.actions.FindAction("MouseXAxis");
        mouseYMoveAction = InputSystem.actions.FindAction("MouseYAxis");
    }

    // Update is called once per frame
    void Update()
    {
        mouseAxis = new Vector2(mouseXMoveAction.ReadValue<float>(), mouseYMoveAction.ReadValue<float>());
        Debug.Log(mouseAxis);
    }

}
