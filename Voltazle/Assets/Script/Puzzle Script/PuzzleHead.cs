using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleHead : MonoBehaviour
{
    public List<GameObject> connected = new List<GameObject>();
    public List<GameObject> connectedStart = new List<GameObject>();
    float time = 0;


    void Start()
    {
        connectedStart.AddRange(connected);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
        time += Time.deltaTime;
        if (time > .1)
        {
            connected.Clear();
            connected.AddRange(connectedStart);
            time = 0;
        }
        ConnectionUpdate();
        foreach (Transform child in transform)
        {
            if (!child.name.Contains("Start Point"))
                child.GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, 1);
        }
        foreach (var item in connected)
        {
            item.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    public void ConnectionUpdate()
    {
        List<GameObject> temp = new List<GameObject>();
        bool end = false;
        foreach (GameObject item in connected)
        {
            if (item.name.Contains("End")) end = true;
            temp.AddRange(item.GetComponent<PuzzleRotation>().connections.Except(connected));
        }
        connected.AddRange(temp);
        if (end)
            Destroy(gameObject);
    }



}
