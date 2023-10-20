using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class Lift : MonoBehaviour
{
    
    private BoxCollider2D collide;
    [SerializeField] private LayerMask player;
    
    void Start()
    {
        collide = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move.isUpLift && IsOnLift()){
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3 (34.02f,8f,0),2 * Time.deltaTime);
            move.inControl = false;
            move.gameObject.transform.parent = transform;
            Debug.Log("NAIIIIIIIIIIK");
        }
        
    }
    private bool IsOnLift()
    {
        return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size-new Vector3(0.1f,0.1f,0), 0f, Vector2.up, 0.1f, player);
    }
}
