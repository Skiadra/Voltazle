using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRotation : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();
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
        if (!gameObject.name.Contains("Start Point"))
            on = false;
        foreach (GameObject item in points)
        {
            if (item.GetComponent<ConnectPoint>().isOn)
            {
                on = true; break;
            }
        }

        if (points.Count == 0) on = true;

        if (on)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            sprite.color = new Color(.5f, .5f, .5f, 1);
        }
    }

    void OnMouseDown()
    {
        if (!gameObject.CompareTag("Unmoveable"))
            transform.Rotate(new Vector3(0, 0, -90));
    }

}
