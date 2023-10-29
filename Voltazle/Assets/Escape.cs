using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public SpriteRenderer sprite;

    private void Update() {
        sprite.color = Color.black;
        Debug.Log("Escape Opened");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
             SceneManager.LoadSceneAsync(0);
        }
    }
}
