using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRight : MonoBehaviour
{
    public GameObject laserPrefab;
    public float spawnInterval = 5f;
    public int maxLaserCount = 4; 
    private int laserCount = 0; 

    private void Start()
    {
        StartCoroutine(SpawnLaserRepeatedly());
    }

    private IEnumerator SpawnLaserRepeatedly()
    {
        while (laserCount < maxLaserCount)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (laserCount < maxLaserCount)
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity);
                laserCount++;
            }
        }
    }
}
