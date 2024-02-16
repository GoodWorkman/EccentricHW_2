using System;
using UnityEngine;

public class AlternativeCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRate = 10f;

    private void LateUpdate()
    {
        transform.position =
            Vector3.Lerp(transform.position, _target.transform.position, _lerpRate * Time.fixedDeltaTime);

        transform.rotation =
            Quaternion.Lerp(transform.rotation, _target.transform.rotation, _lerpRate * Time.fixedDeltaTime);
    }
}