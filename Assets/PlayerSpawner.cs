using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewPlayer();
    }

    // Update is called once per frame
    void SpawnNewPlayer()
    {
        Transform newPlayer = Instantiate(playerPrefab);
        Color newPlayerColor = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1.0f, 1.0f);
        foreach (ChangeMyColorOnStartup colorChanger in newPlayer.GetComponentsInChildren<ChangeMyColorOnStartup>())
        {
            colorChanger.ChangeMyColorTo(newPlayerColor);
        }

        Invoke("SpawnNewPlayer", 16f);

    }
}
