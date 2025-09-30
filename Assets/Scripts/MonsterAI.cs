using UnityEngine;
using UnityEngine.AI; // NavMeshAgent 사용을 위해 필수

public class MonsterAI : MonoBehaviour
{
    public Transform target;

    [SerializeField] private HealthComponent health;
    [SerializeField] private NavMeshAgent agent;

    [Header("공격 설정")]
    public float attackRange = 2.0f;
    public float attackCooldown = 1.5f;
    public float damage = 10f;

    private float nextAttackTime = 0f;

    void Awake()
    {
        health = GetComponent<HealthComponent>();
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
        health.onDeadAction += Die;
    }

    void Update()
    {
        if (target == null || agent == null || !agent.enabled) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            agent.isStopped = true;
            Attack();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
    }

    private void Attack()
    {
        Vector3 lookDirection = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

        if (Time.time >= nextAttackTime)
        {
            DealDamage();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void DealDamage()
    {
        IDamagable damagable = target.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.OnDamage(damage);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}