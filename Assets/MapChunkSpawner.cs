using UnityEngine;

public class MapChunkSpawner : MonoBehaviour
{
    public GameObject[] platformChunks;
    public Transform mapRoot;
    public float chunkHeight = 5.5f;
    public float spawnInterval = 7f;

    private float nextSpawnTime = 0f;

    void Start()
    {
        if (platformChunks.Length > 0 && mapRoot != null)
        {
            nextSpawnTime = Time.time + spawnInterval;
        }
        else
        {
            Debug.LogWarning("MapChunkSpawner: Missing platform chunks or map root!");
        }
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            ShiftMapDown();
            SpawnChunk();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnChunk()
    {
        // Always spawn at the top of mapRoot
        Vector3 topPosition = GetTopOfMap();
        GameObject chunk = Instantiate(platformChunks[0], topPosition, Quaternion.identity);
        chunk.transform.SetParent(mapRoot);
    }

    void ShiftMapDown()
    {
        mapRoot.position += Vector3.down * chunkHeight;
    }

    Vector3 GetTopOfMap()
    {
        float highestY = float.MinValue;

        foreach (Transform child in mapRoot)
        {
            if (child.position.y > highestY)
            {
                highestY = child.position.y;
            }
        }

        return new Vector3(mapRoot.position.x, highestY + chunkHeight, 0f);
    }
}