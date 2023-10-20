using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
        public float highlightDistance = 2f; // Adjust this distance as needed.
    public Material highlightMaterial; // Assign the highlight material in the Inspector.
    
    private Material originalMaterial;
    private Renderer spriteRenderer;
    private Transform player;

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
        originalMaterial = spriteRenderer.material;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Adjust the tag as needed.
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= highlightDistance)
        {
            spriteRenderer.material = highlightMaterial;
        }
        else
        {
            spriteRenderer.material = originalMaterial;
        }
    }
}
