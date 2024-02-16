using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsChecker : MonoBehaviour
{
    public Action OnBombDestroyed;
    public Action OnAllCoinCollected;
    public Action<int> OnCoinsCountChanged;

    private readonly List<Coin> _coins = new();
    private readonly List<Bomb> _bombs = new();

    private int _coinsCount;

    public int CoinsCount => _coinsCount;

    private void Start()
    {
        _coins.AddRange(FindObjectsOfType<Coin>());
        _bombs.AddRange(FindObjectsOfType<Bomb>());

        foreach (Coin coin in _coins)
        {
            coin.OnCoinCollected += CollectCoin;
        }

        foreach (Bomb bomb in _bombs)
        {
            bomb.OnBombDestroyed += CollectBomb;
        }
        
        _coinsCount = _coins.Count;
    }

    private void CollectCoin(Coin coin)
    {
        coin.OnCoinCollected -= CollectCoin;

        _coins.Remove(coin);
        
        OnCoinsCountChanged?.Invoke(_coins.Count);

        if (_coins.Count == 0)
        {
            OnAllCoinCollected?.Invoke();
        }
    }

    private void CollectBomb(Bomb bomb)
    {
        bomb.OnBombDestroyed -= CollectBomb;
        
        OnBombDestroyed?.Invoke();
    }
}
