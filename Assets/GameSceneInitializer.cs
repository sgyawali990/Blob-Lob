using UnityEngine;

public class GameSceneInitializer : MonoBehaviour
{
    void Start()
    {
        CountdownUI countdown = FindFirstObjectByType<CountdownUI>();
    }
}
