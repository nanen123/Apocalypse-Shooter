using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthComponent playerhealth;
    void Awake()
    {
        playerhealth = GetComponent<HealthComponent>();
        playerhealth.onDamageAction += DamageDebug;
    }

    private void DamageDebug()
    {
        Debug.Log("Damage Dealt");
    }

}
