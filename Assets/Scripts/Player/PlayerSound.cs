using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
   private AudioSource _audioSource;
   private PlayerMover _playerMover;

   private float _minPitch = 0.7f;
   private float _maxPitch = 1.3f;
   private float _stepInterval = 0.4f;
   private float _stepTimer;

   private void OnValidate()
   {
      _audioSource ??= GetComponent<AudioSource>();
   }

   private void Start()
   {
      _playerMover = GetComponentInParent<PlayerMover>();
      
   }

   private void Update()
   {
      if (_playerMover.IsMoving && Time.time >= _stepTimer)
      {
         PlayStepsSound();

         _stepTimer = Time.time + _stepInterval;
      }
   }

   private void PlayStepsSound()
   {
      if (_playerMover.IsGrounded)
      {
         _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
         
         _audioSource.Play();
      }
   }
}
