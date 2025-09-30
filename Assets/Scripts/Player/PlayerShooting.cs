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
        if (type == GunStats.GunType.semiAuto) //단발
        {
            if (attackTrigger == true && beforeTrigger == false)
            {
                return true;
            }
            else return false;
        }
        else if (type == GunStats.GunType.fullAuto) //연발
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
        if (Physics.Raycast(cameraArm.position, cameraArm.forward, out hit, 100f)) // 에임이 가리키는 위치 추출
        {
            aimedVector = hit.point;
        }
        else
        {
            aimedVector = cameraArm.position + cameraArm.forward * 100;
        }

        if (Physics.Raycast(firePos.position, (aimedVector - firePos.position).normalized, out hit, 100f)) // 총구 -> 에임이 가리키는 위치로 발사
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();

            if(target != null)
            {
                target.OnDamage(currentGun.damage);
            }
        }
    }
}
