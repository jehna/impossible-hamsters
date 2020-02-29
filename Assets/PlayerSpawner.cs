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
        Instantiate(playerPrefab);
        Invoke("SpawnNewPlayer", Random.Range(5.0f, 20.0f));
    }
}
