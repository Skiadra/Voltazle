using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLeft : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float teleportDistance = 10f; 
    public Vector2 initialPosition; 

    private bool movingForward = true; 

    private void Start()
    {
        initialPosition = new Vector2 (92.8141f,-38f);
    }

    private void Update()
    {
        if (movingForward)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (Vector2.Distance(initialPosition, (Vector2)transform.position) >= teleportDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") || other.CompareTag("Box")){
            Destroy(gameObject);
        }
    }
}
