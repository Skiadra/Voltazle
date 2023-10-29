using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public GameObject laserPrefab;
    public float spawnInterval = 5f;

    private IEnumerator SpawnLaserRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }

    public void LaserOn(){
        StartCoroutine(SpawnLaserRepeatedly());
    }
}
