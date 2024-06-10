using UnityEngine;
using System.Reflection;

public class AnomalyGenerator : MonoBehaviour
{
    public MonoBehaviour[] roomScripts;
    public float anomalyInterval = 10f;

    void Start()
    {
        if (roomScripts.Length == 0)
        {
            Debug.LogWarning("No room scripts assigned to the Anomaly Generator.");
            return;
        }

        // Start generating anomalies every 10 seconds
        InvokeRepeating("GenerateAnomaly", 0f, anomalyInterval);
    }

    public void GenerateAnomaly()
    {
        int roomIndex = Random.Range(0, roomScripts.Length);
        MonoBehaviour selectedRoomScript = roomScripts[roomIndex];

        MethodInfo[] methods = selectedRoomScript.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        MethodInfo[] anomalyMethods = System.Array.FindAll(methods, m => m.Name.StartsWith("Anomaly"));

        if (anomalyMethods.Length == 0)
        {
            Debug.LogWarning($"No anomaly functions found in the script: {selectedRoomScript.GetType().Name}");
            return;
        }

        int anomalyIndex = Random.Range(0, anomalyMethods.Length);
        anomalyMethods[anomalyIndex].Invoke(selectedRoomScript, null);

        Debug.Log($"Anomaly generated in {selectedRoomScript.GetType().Name}: {anomalyMethods[anomalyIndex].Name}");
    }
}