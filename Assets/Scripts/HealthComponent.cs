using System;
using UnityEngine;


public interface IDamagable
{
    public void OnDamage(float damage);
}


public class HealthComponent : MonoBehaviour, IDamagable
{
    public float hp;

    public event Action onDamageAction; // �ǰ� �̺�Ʈ
    public event Action onDeadAction; // ��� �̺�Ʈ

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
        //�ִϸ��̼�, ���� ���

        if (onDeadAction != null)
            onDeadAction.Invoke();
    }
}
