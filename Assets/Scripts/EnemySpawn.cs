using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float timeToSpawn, spawnCountdown;

    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(SpawnEnemy());
        spawnCountdown -= Time.deltaTime;

        if(spawnCountdown <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            spawnCountdown = timeToSpawn;
        }
    }

    //IEnumerator SpawnEnemy()
    //{
    //    while (canSpawn == true) 
    //    {
            
    //        canSpawn = false;
    //        yield return new WaitForSeconds(3);
    //        canSpawn = true;
    //    }
        
    //}
}
