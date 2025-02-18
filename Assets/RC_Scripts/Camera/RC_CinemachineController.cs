using Unity.Cinemachine;
using RC_Player;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    private CinemachineCamera _camera;
    
    private void Awake()
    {
        RC_PlayerManager.OnPlayerSpawned += SetupCamera;
    }

    /// <summary>
    /// Sets up cinemachine player camera.
    /// </summary>
    private void SetupCamera()
    {
        _camera = GetComponent<CinemachineCamera>();
        _camera.Follow = RC_PlayerManager.Player.transform;
    }
}
