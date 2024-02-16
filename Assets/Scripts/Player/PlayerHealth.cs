using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private ObjectsChecker objectsChecker;
   public Action OnPlayerDie;
   public Action <int> OnLifesChanged;

   private int _lifes = 5;

   public int Lifes => _lifes;

   private void Start()
   {
      objectsChecker.OnBombDestroyed += ReduseLife;
   }

   private void ReduseLife()
   {
      _lifes--;
      
      OnLifesChanged?.Invoke(_lifes);

      if (_lifes <= 0)
      {
         Die();
      }
   }

   private void Die()
   {
      OnPlayerDie?.Invoke();
      
      gameObject.SetActive(false);
   }

   private void OnDestroy()
   {
      objectsChecker.OnBombDestroyed -= ReduseLife;
   }
}
