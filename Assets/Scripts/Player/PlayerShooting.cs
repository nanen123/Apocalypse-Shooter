using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private InputAction fireAction;
    private bool attackTrigger;
    private bool beforeTrigger;

    public Transform cameraArm;
    public Transform firePos;

    public LineRenderer line;
    private Vector3 aimedVector;

    private void Awake()
    {
        fireAction = InputSystem.actions.FindAction("MouseClick");
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, cameraArm.position);
        line.SetPosition(1, cameraArm.position + cameraArm.forward * 100);

        if (fireAction.WasPressedThisFrame())
        {
            attackTrigger = true;
            if (beforeTrigger == false)
            {
                Fire();
            }
        }

        if (fireAction.WasReleasedThisFrame())
        {
            attackTrigger = false;
        }
        beforeTrigger = attackTrigger;
    }

    private void Fire()
    {
        //Vector3 dir = transform.position + transform.forward * 100;
        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, dir);

        RaycastHit hit;
        if (Physics.Raycast(cameraArm.position, cameraArm.forward, out hit, 100f)) // 에임이 가리키는 위치 추출
        {
            Debug.Log("11");
            aimedVector = hit.point;
        }
        else
        {
            aimedVector = cameraArm.position + cameraArm.forward * 100;
        }

        if (Physics.Raycast(firePos.position, (aimedVector - firePos.position).normalized, out hit, 100f)) // 총구 -> 에임이 가리키는 위치로 발사
        {
            if (hit.transform.CompareTag("Wall"))
            {
                Debug.Log("hit wall");
            }
        }
    }
}
