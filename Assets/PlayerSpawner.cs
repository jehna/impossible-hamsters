using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnNewPlayer();
    }

    // Update is called once per frame
    void SpawnNewPlayer()
    {
        Transform newPlayer = Instantiate(playerPrefab);
        var playerCount = GameObject.FindObjectsOfType<Player>().Length;

        if (playerCount > 1) {  
            newPlayer.position += new Vector3(newPlayer.position.x + Random.Range(-10, 10), newPlayer.position.y + 35, 0);
        }

        newPlayer.GetComponentInChildren<Player>().gameObject.name += " " + FindObjectsOfType<Player>().Length; // For debugging purposes
        Color newPlayerColor = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1.0f, 1.0f);
        foreach (ChangeMyColorOnStartup colorChanger in newPlayer.GetComponentsInChildren<ChangeMyColorOnStartup>())
        {
            colorChanger.ChangeMyColorTo(newPlayerColor);
        }

        Invoke("SpawnNewPlayer", 14f);

    }
}
