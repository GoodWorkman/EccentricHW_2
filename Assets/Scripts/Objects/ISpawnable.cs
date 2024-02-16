using UnityEngine;

public interface ISpawnable
{
    GameObject CreateObject(Vector3 position, Transform container);
}
