using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRotation : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();
    public List<GameObject> connections = new List<GameObject>();
    SpriteRenderer sprite;
    public bool on = false;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if (gameObject.name == "Start Point")
            on = true;
    }

    void Update()
    {

        if (points.Count == 0) return;

        foreach (GameObject item in connections)
        {
            if (gameObject.transform.parent.GetComponent<PuzzleHead>().connected.Contains(item))
            {
                return;
            }
        }
    }

    void OnMouseDown()
    {
        if (!gameObject.CompareTag("Unmoveable"))
        { transform.Rotate(new Vector3(0, 0, -90)); }
    }

    public bool checkConnection()
    {
        if (connections.Count == 0) return false;
        foreach (GameObject item in connections)
        {
            if (item.name.Contains("Start Point"))
            {
                return true;
            }
        }
        return false;
    }
}
