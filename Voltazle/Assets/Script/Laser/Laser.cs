using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float teleportDistance = 10f; 
    public Vector2 initialPosition; 

    private bool movingForward = true; 

    private void Start()
    {
        initialPosition = new Vector2 (28.627f,-31.197f);
    }

    private void Update()
    {
        if (movingForward)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
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
