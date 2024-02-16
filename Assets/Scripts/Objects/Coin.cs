using System;
using UnityEngine;

public class Coin : MonoBehaviour, ISpawnable
{
    [SerializeField] private AudioSource _audioSource;
    

    private bool _isActive = true;

    public Action<Coin> OnCoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive) return;

        _isActive = false;
        
        if (other.attachedRigidbody.GetComponent<PlayerMover>()) 
           // if (other.gameObject.GetComponent<PlayerMover>()) //вот так не нужен коллайдер на игроке
        {
            OnCoinCollected?.Invoke(this);
            
            _audioSource.Play();
            
            Destroy(gameObject, _audioSource.clip.length);
        }
    }

    public GameObject CreateObject(Vector3 position, Transform container)
    {
        Coin coin = Instantiate(this, position, Quaternion.identity, container);

        return coin.gameObject;
    }
}
