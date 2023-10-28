using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void Update() {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3 (4.733952f,-8.74f,0),2 * Time.deltaTime);
        Debug.Log("Gate Opened");
    }
}
