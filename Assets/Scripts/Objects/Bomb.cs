using System;
using UnityEngine;

public class Bomb : MonoBehaviour, ISpawnable
{
   [SerializeField] private AudioSource _audioSource;

   private bool _isActive = true;

   public Action<Bomb> OnBombDestroyed;

   private void OnTriggerEnter(Collider other)
   {
      if(!_isActive) return;

      _isActive = false;

      bool rb = other.attachedRigidbody;
      
      Debug.Log("rb found: " + rb);

      if (other.attachedRigidbody.GetComponent<PlayerMover>()) // если нет коллайдера на игроке - то здесь нулреф, рб-кинематик
      {
         OnBombDestroyed?.Invoke(this);
         
         _audioSource.Play();
         
         Destroy(gameObject, _audioSource.clip.length);
      }
   }

   public GameObject CreateObject(Vector3 position, Transform container)
   {
      Bomb bomb = Instantiate(this, position, Quaternion.identity, container);

      return bomb.gameObject;
   }
}
