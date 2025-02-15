using System;
using UnityEngine;

public class RC_PlayerManager : MonoBehaviour
{
    public static RC_PlayerController Player;

    private Action OnPlayerSpawned;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _playerSpawn;

    private void Awake()
    {
        OnPlayerSpawned += SpawnPlayer;
    }

    private void Start()
    {
        OnPlayerSpawned?.Invoke();
    }
    
    /// <summary>
    /// Spawns in the _playerPrefab at _playerSpawn
    /// </summary>
    private void SpawnPlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerSpawn.position, _playerSpawn.rotation);
        player.name = "Player";
    }

    private void OnDestroy()
    {
        OnPlayerSpawned -= SpawnPlayer;
    }
}
