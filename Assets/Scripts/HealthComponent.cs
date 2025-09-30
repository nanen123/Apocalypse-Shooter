using System;
using UnityEngine;


public interface IDamagable
{
    public void OnDamage(float damage);
}


public class HealthComponent : MonoBehaviour, IDamagable
{
    public float hp;

    public event Action onDamageAction; // 피격 이벤트
    public event Action onDeadAction; // 사망 이벤트

    public void OnDamage(float damage)
    {
        if (onDamageAction != null)
            onDamageAction.Invoke();
        DamageTake(damage);
    }

    private void DamageTake(float damage)
    {
        if (damage >= hp)
        {
            OnDeath();
        }
        else
        {
            hp -= damage;
        }
    }

    private void OnDeath()
    {
        //애니메이션, 사운드 등등

        if (onDeadAction != null)
            onDeadAction.Invoke();
    }
}
