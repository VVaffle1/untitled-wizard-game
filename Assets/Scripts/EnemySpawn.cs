using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float timeToSpawn, spawnCountdown;
    public int SpawnPerWave = 1;
    int CurrentWave = 0;

    [SerializeField] int IncreaseEnemiesPerWave = 1;

    void Start()
    {
        spawnCountdown = timeToSpawn / 2;
    }

    void Update()
    {
        spawnCountdown -= Time.deltaTime;

        if(spawnCountdown <= 0 && FindAnyObjectByType<TimerScript>().timerCountdown > 0)
        {
            for(int i = 0; i < SpawnPerWave; i++)
            {
                int randomChild = Random.Range(0, transform.childCount);
                Transform FoundChild = transform.GetChild(randomChild);

                Instantiate(Enemy, GetRandomPoint(FoundChild), Quaternion.identity);
            }
            spawnCountdown = timeToSpawn;

            CurrentWave += 1;
            if (CurrentWave % 3 == 0)
            {
                SpawnPerWave += IncreaseEnemiesPerWave;
            }
        }
    }

    Vector3 GetRandomPoint(Transform FromTransform)
    {
        float Xp = FromTransform.localScale.x;
        float Yp = FromTransform.localScale.y;
        Xp = Random.Range(-Xp / 2, Xp / 2);
        Yp = Random.Range(-Yp / 2, Yp / 2);
        return new Vector3(FromTransform.position.x + Xp, FromTransform.position.y + Yp, 0);
    }
}
