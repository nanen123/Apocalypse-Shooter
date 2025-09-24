using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    private Vector2 mouseDelta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mouseDelta);
    }

    public void OnMove(InputValue value)
    {
        mouseDelta = value.Get<Vector2>();
    }
}
