using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    public SpriteRenderer sprite;
    void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Laser"){
            StartCoroutine(FlashDamage());
            transform.position = respawnPoint;
        }
        else if(other.tag == "Checkpoint"){
            respawnPoint = transform.position;
        }
    }

    public IEnumerator FlashDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
