using UnityEngine;
using System.Collections;

public class MapShifter : MonoBehaviour
{
    public float shiftInterval = 5f;
    public float shiftAmount = 1f;
    public float warningDuration = 0.3f;
    public float warningShakeAmount = 0.1f;

    private Transform mapRoot;

    void Start()
    {
        mapRoot = transform;
        StartCoroutine(ShiftLoop());
    }

    IEnumerator ShiftLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(shiftInterval - warningDuration);

            // Small bounce warning
            Vector3 originalPos = mapRoot.position;
            mapRoot.position += new Vector3(0, warningShakeAmount, 0);
            yield return new WaitForSeconds(warningDuration);
            mapRoot.position = originalPos;

            // Actual shift down
            mapRoot.position += new Vector3(0, -shiftAmount, 0);
        }
    }
}
