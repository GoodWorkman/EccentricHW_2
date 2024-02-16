using UnityEngine;

public class SoundActivator : MonoBehaviour
{
    [SerializeField] private ObjectsChecker objectsChecker;
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;

    private void Start()
    {
        objectsChecker.OnAllCoinCollected += PlayWinSound;
        _playerHealth.OnPlayerDie += PlayLoseSound;
    }

    private void PlayWinSound()
    {
        _winSound.Play();
    }

    private void PlayLoseSound()
    {
        _loseSound.Play();
    }

    private void OnDestroy()
    {
        objectsChecker.OnAllCoinCollected -= PlayWinSound;
        _playerHealth.OnPlayerDie -= PlayLoseSound;
    }
}
