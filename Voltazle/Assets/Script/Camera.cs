using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    public float followSpeed = 2f;
    public float yOffSet = 1f;
    public float fixedZPosition = -10f; // Add a new variable for the fixed Z position.
    public Transform target;
    Vector3 newPos;

    void Awake()
    {
        newPos = new Vector3(target.transform.position.x, target.transform.position.y + yOffSet, fixedZPosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(target.transform.position.x - transform.position.x) > 5 || Mathf.Abs(target.transform.position.y - transform.position.y) > 2.5f)
        {
            newPos = new Vector3(target.position.x, target.position.y + yOffSet, fixedZPosition);
        }

        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.fixedDeltaTime);
    }
}
