using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
   
    [SerializeField] private float _returnSpeed = 0.7f;
    [SerializeField] private float _height = 9f;
    [SerializeField] private float _rearDistance = 6f;

    private void Start()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + _height,
            _target.transform.position.z - _rearDistance);

        transform.rotation = Quaternion.LookRotation(_target.transform.position - transform.position);
    }

    private void LateUpdate()
    {
        Vector3 currentVector = new Vector3(_target.transform.position.x, _target.transform.position.y + _height,
            _target.transform.position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position, currentVector, _returnSpeed * Time.fixedDeltaTime);
    }

    
}