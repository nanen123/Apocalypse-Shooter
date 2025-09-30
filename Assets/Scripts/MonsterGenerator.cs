using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MonsterGenerator : MonoBehaviour
{
    [Header("소환 설정")]
    public GameObject enemyPrefab;
    public float spawnRadius = 35f;
    public float spawnInterval = 3f;

    private void Start()
    {
        if (enemyPrefab != null)
        {
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, NavMesh.AllAreas))
        {
            if (Vector3.Distance(transform.position, hit.position) <= 15f)
            {
                SpawnEnemy();
            }
            else
                Instantiate(enemyPrefab, hit.position, Quaternion.identity);
        }
    }
}