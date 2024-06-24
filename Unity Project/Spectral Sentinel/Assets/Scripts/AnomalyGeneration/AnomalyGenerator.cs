using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class AnomalyGenerator : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] roomScripts;
    [SerializeField] private float realWorldGameDuration = 6f * 60f;
    [SerializeField] private float inGameAnomalyInterval = 20f;
    [SerializeField] private Text alarmTime;
    [SerializeField] private Text computerTime;
    [SerializeField] private Text anomalyCounterText;
    [SerializeField] private GameOver gameOverScript;
    [SerializeField] private int maxAnomalies = 0;
    [SerializeField] private int anomalyCounter = 0;

    private float realWorldAnomalyInterval;
    private float gameStartTime;
    private bool isAnomalyGenerationStopped = false;

    void Start()
    {
        if (roomScripts.Length == 0)
        {
            Debug.LogWarning("No room scripts assigned to the Anomaly Generator.");
            return;
        }

        realWorldAnomalyInterval = (inGameAnomalyInterval / (6f * 60f)) * realWorldGameDuration;
        gameStartTime = Time.time;
        InvokeRepeating("GenerateAnomaly", realWorldAnomalyInterval, realWorldAnomalyInterval);
    }

    void Update()
    {
        float elapsedTime = Time.time - gameStartTime;
        float inGameElapsedTime = elapsedTime * (6f * 60f) / realWorldGameDuration;
        int hours = Mathf.FloorToInt((inGameElapsedTime % 3600f) / 60f);
        int minutes = Mathf.FloorToInt(inGameElapsedTime % 60f);
        alarmTime.text = $"{hours:D2}:00";
        computerTime.text = $"{hours:D2}:00";

        if (elapsedTime >= realWorldGameDuration)
        {
            CancelInvoke("GenerateAnomaly");
            Debug.Log("Game over");
        }

        if (anomalyCounter >= maxAnomalies)
        {
            gameOverScript.GameOverFunction();
            isAnomalyGenerationStopped = true;
        }
    }

    public void GenerateAnomaly()
    {
        if (isAnomalyGenerationStopped || anomalyCounter >= maxAnomalies)
            return;

        bool anomalyGenerated = false;

        while (!anomalyGenerated)
        {
            int roomIndex = Random.Range(0, roomScripts.Length);
            MonoBehaviour selectedRoomScript = roomScripts[roomIndex];

            MethodInfo[] methods = selectedRoomScript.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            MethodInfo[] anomalyMethods = System.Array.FindAll(methods, m => m.Name.StartsWith("Anomaly"));

            if (anomalyMethods.Length == 0)
            {
                Debug.LogWarning($"No anomaly functions found in the script: {selectedRoomScript.GetType().Name}");
                continue;
            }

            // Randomly select an anomaly method
            int anomalyIndex = Random.Range(0, anomalyMethods.Length);
            MethodInfo selectedAnomalyMethod = anomalyMethods[anomalyIndex];

            // Check if the selected anomaly method is not already active
            if (!(bool)selectedRoomScript.GetType().GetMethod("IsAnomalyActive").Invoke(selectedRoomScript, new object[] { selectedAnomalyMethod.Name }))
            {
                // Invoke the selected anomaly method
                selectedAnomalyMethod.Invoke(selectedRoomScript, null);
                anomalyCounter++;
                anomalyCounterText.text = "" + anomalyCounter;
                anomalyGenerated = true;
            }

            if (!anomalyGenerated)
            {
                Debug.LogWarning($"No available anomaly functions found in the script: {selectedRoomScript.GetType().Name}");
            }
        }

        if (!anomalyGenerated)
        {
            Debug.LogWarning("Unable to generate an anomaly after multiple attempts.");
        }
    }

    public void FixAnomaly(MonoBehaviour roomScript, string anomalyName)
    {
        roomScript.GetType().GetMethod("FixAnomaly").Invoke(roomScript, new object[] { anomalyName });
        DecrementAnomalyCounter();
    }

    public void DecrementAnomalyCounter()
    {
        anomalyCounter--;
        anomalyCounterText.text = "" + anomalyCounter;
    }
}