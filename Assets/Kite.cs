using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kite : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(this.transform.position, player.transform.position);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Ground") {
            GameObject.Find("GameOverPanel").GetComponent<Image>().enabled = true; 
            Debug.Log("Hävisit pelin :(");
            Time.timeScale = 0;
        }
    }
}
