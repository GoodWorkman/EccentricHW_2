using System.Collections;
using UnityEngine;

public class MeshMover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private float _moveStep = 0.2f;
    [SerializeField] private float _moveDistance = 1f;
    [SerializeField] private Transform _meshModel;

    private Vector3 _startPosition;
    private bool _ismovingUp = true;
    

    private void Start()
    {
        StartCoroutine(MoveAndRotate());

        _startPosition = _meshModel.localPosition;
    }

    private IEnumerator MoveAndRotate()
    {
        while (gameObject.activeInHierarchy)
        {
            _meshModel.transform.Rotate(Vector3.up * (_rotationSpeed * Time.deltaTime));

            Vector3 targetPosition = _ismovingUp ? _startPosition + Vector3.up * _moveDistance : _startPosition;

            _meshModel.localPosition =
                Vector3.MoveTowards(_meshModel.localPosition, targetPosition, _moveStep * Time.deltaTime);

            if (Vector3.Distance(_meshModel.localPosition, targetPosition) < 0.05f) _ismovingUp = !_ismovingUp;

            yield return null;
        }
    }
}
