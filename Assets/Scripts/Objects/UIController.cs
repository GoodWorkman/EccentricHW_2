using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ObjectsChecker objectsChecker;
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _lifesText;

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    private void Start()
    {
        objectsChecker.OnCoinsCountChanged += ChangeCoinsText;
        objectsChecker.OnAllCoinCollected += Win;

        _playerHealth.OnLifesChanged += ChangeLifesText;
        _playerHealth.OnPlayerDie += Lose;
        
        ChangeLifesText(_playerHealth.Lifes);
        ChangeCoinsText(objectsChecker.CoinsCount);
    }

    private void ChangeLifesText(int lifes)
    {
        _lifesText.text = "Lifes: " + lifes;
    }

    private void ChangeCoinsText(int remainingCoins)
    {
        _coinsText.text = " Coins left: " + remainingCoins;
    }

    private void Win()
    {
        Time.timeScale = 0;
        
        _winScreen.SetActive(true);
    }

    private void Lose()
    {
        Time.timeScale = 0;
        
        _loseScreen.SetActive(true);
    }

    private void OnDestroy()
    {
        objectsChecker.OnCoinsCountChanged -= ChangeLifesText;
        objectsChecker.OnAllCoinCollected -= Win;

        _playerHealth.OnLifesChanged -= ChangeLifesText;
        _playerHealth.OnPlayerDie -= Lose;
    }
}
