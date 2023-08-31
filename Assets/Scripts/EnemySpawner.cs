using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Slime;

    [SerializeField]
    private float timeSpawn = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(timeSpawn, Slime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float time, GameObject enemy)
    {
        yield return new WaitForSeconds(time);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(10,14), Random.Range(-7,-5),0),Quaternion.identity);
        StartCoroutine(spawnEnemy(time, enemy));
    }
}
