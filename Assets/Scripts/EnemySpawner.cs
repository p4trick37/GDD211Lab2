using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    
    [Header("Delay")]
    [SerializeField] private float spawnDelay;
    [Header("Spawn Location")]
    [SerializeField] private int minRadius;
    [SerializeField] private int maxRadius;
    [SerializeField] private float radiusSpacing;
    [SerializeField] private int angleSpacing;


    private float timer;


    private void Start()
    {
        timer = spawnDelay;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Instantiate(enemyPrefab, EnemySpawnLocation(), Quaternion.identity);
            timer = spawnDelay;
        }
    }

    private Vector3 EnemySpawnLocation()
    {
        float radius = Random.Range(minRadius, maxRadius) * radiusSpacing;
        int angleDeg = 90 - ((int)Random.Range((int)-90/angleSpacing, (int)91/angleSpacing) * angleSpacing);
        Debug.Log(angleDeg);
        float angleRad = angleDeg * Mathf.Deg2Rad;
        float positionX = radius * Mathf.Cos(angleRad);
        float positionZ = radius * Mathf.Sin(angleRad);

        return new Vector3(positionX, 0.6f,positionZ);

    }

}
