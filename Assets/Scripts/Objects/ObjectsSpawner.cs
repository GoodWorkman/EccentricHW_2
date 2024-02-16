using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Bomb _bombPrefab;

    [SerializeField] private Transform _coinContainer;
    [SerializeField] private Transform _bombContainer;

    [SerializeField] private int _coinCount = 25;
    [SerializeField] private int _bombCount = 10;
    [SerializeField] private float _checkRadious = 1.5f;

    [SerializeField] private Transform _spawnZone;

    private float _diagonalCorner = 0.5f;
    private float yCheckOffcet = 1.6f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_spawnZone.position, _spawnZone.localScale);
    }

    private void Awake()
    {
        ActivateSpawn(_coinPrefab, _coinCount, _coinContainer);
        ActivateSpawn(_bombPrefab, _bombCount, _bombContainer);
    }

    private void ActivateSpawn(ISpawnable prefab, int count, Transform container)
    {
        for (int i = 0; i < count; i++)
        {
            TrySpawnObjects(prefab, container);
        }
    }

    private void TrySpawnObjects(ISpawnable prefab, Transform container)
    {
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 position = GeneratePosition();

            Vector3 checkOffcetPosition = new Vector3(position.x, position.y + yCheckOffcet, position.z); 
            //поскольку зона спавна в глобальных коорд, если смещение по У не сделать, то в радиус проверки детектится пол, и if (lenght==0) - false.
            //спавнится будет все равно по глобальной У 
           
            Collider[] colliders = Physics.OverlapSphere(checkOffcetPosition, _checkRadious);

            if (colliders.Length == 0)
            {
                prefab.CreateObject(position, container);
                
                break;
            }
        }
    }
    
    private Vector3 GeneratePosition()
    {
        float coordX = Random.Range(-_diagonalCorner, _diagonalCorner);
        float coordY = 0f;
        float coordZ = Random.Range(-_diagonalCorner, _diagonalCorner);

        Vector3 worldPosition = _spawnZone.TransformPoint(coordX, coordY, coordZ);

        worldPosition.y = 0f;

        return worldPosition;
    }
}
