using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private InputAction fireAction;
    private bool attackTrigger;
    private bool beforeTrigger;

    public Transform cameraArm;
    public Transform firePos;
    public GunStats currentGun;

    public LineRenderer line;
    private Vector3 aimedVector;

    private void Awake()
    {
        fireAction = InputSystem.actions.FindAction("MouseClick");
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, firePos.position);
        line.SetPosition(1, cameraArm.position + cameraArm.forward * 100);

        if (fireAction.WasPressedThisFrame())
        {
            attackTrigger = true;
        }

        if (fireAction.WasReleasedThisFrame())
        {
            attackTrigger = false;
        }

        if (CheckTrigger(currentGun.type))
        {
            Fire();
        }

        beforeTrigger = attackTrigger;
    }

    private bool CheckTrigger(GunStats.GunType type)
    {
        if (type == GunStats.GunType.semiAuto) //�ܹ�
        {
            if (attackTrigger == true && beforeTrigger == false)
            {
                return true;
            }
            else return false;
        }
        else if (type == GunStats.GunType.fullAuto) //����
        {
            if (attackTrigger == true)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraArm.position, cameraArm.forward, out hit, 100f)) // ������ ����Ű�� ��ġ ����
        {
            aimedVector = hit.point;
        }
        else
        {
            aimedVector = cameraArm.position + cameraArm.forward * 100;
        }

        if (Physics.Raycast(firePos.position, (aimedVector - firePos.position).normalized, out hit, 100f)) // �ѱ� -> ������ ����Ű�� ��ġ�� �߻�
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();

            if(target != null)
            {
                target.OnDamage(currentGun.damage);
            }
        }
    }
}
