using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Range(0f, 10f)] public float gameSpeed = 1f;

    public long numPlayers = 2;
    public GameObject playerObject;
    public Transform spawn;
    public float spawnRadius = 10f;

    void Awake() {
        Time.timeScale = gameSpeed;
        Instantiate(playerObject, spawn);
    }
	
	// Update is called once per frame
	void Update() {}
}
