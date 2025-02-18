using System;
using Unity.VisualScripting;
using UnityEngine;

namespace RC_Player
{
    public class RC_PlayerManager : MonoBehaviour
    {
        public static RC_PlayerController Player;

        public static Action OnPlayerSpawned;

        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerSpawn;

        private void Start()
        {
            SpawnPlayer();
        }

        /// <summary>
        /// Spawns in the _playerPrefab at _playerSpawn
        /// </summary>
        private void SpawnPlayer()
        {
            GameObject player = Instantiate(_playerPrefab, _playerSpawn.position, _playerSpawn.rotation);
            player.name = "Player";
            SetupPlayer(player);
            OnPlayerSpawned?.Invoke();
        }

        private void SetupPlayer(GameObject player)
        {
            if (Player == null)
            {
                Player = player.GetComponent<RC_PlayerController>();
            }
            else
            {
                Destroy(player);
            }
        }

        private void OnDestroy()
        {
            OnPlayerSpawned -= SpawnPlayer;
        }
    }
}
