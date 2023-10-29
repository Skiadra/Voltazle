using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public GameObject laserPrefab;
    public float spawnInterval = 5f;
    AudioManager audioManager;

    private IEnumerator SpawnLaserRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            audioManager.PlaySFX(audioManager.lasershoot);
        }
    }

    public void LaserOn(){
        StartCoroutine(SpawnLaserRepeatedly());
    }

    void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
