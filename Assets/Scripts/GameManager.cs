using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event TrafficLightChangedDelegate OnTrafficLightChanged;

    public delegate void TrafficLightChangedDelegate(Color32 color);

    private TrafficLightButton activeTrafficLightButton;

    public int carsFinishedToWin = 4;

    public int carsFinished = 0;

    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;

    private bool isLevelEnded = false;
    [SerializeField]
    private List<string> levels;

    [SerializeField]
    private int curLevelIndex = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public void TrafficLightChanged(TrafficLightButton trafficLightButton)
    {
        if (activeTrafficLightButton)
        {
            if (trafficLightButton != activeTrafficLightButton)
            {
                activeTrafficLightButton.ToggleLight(false);
                trafficLightButton.ToggleLight(true);
                activeTrafficLightButton = trafficLightButton;
                OnTrafficLightChanged?.Invoke(trafficLightButton.color);
            }
        }
        else
        {
            trafficLightButton.ToggleLight(true);
            activeTrafficLightButton = trafficLightButton;
            OnTrafficLightChanged?.Invoke(trafficLightButton.color);
        }
    }

    public Color32 GetActiveColor()
    {
        return activeTrafficLightButton?.color ?? Color.black;
    }

    public void Lose()
    {
        if (!isLevelEnded)
        {
            isLevelEnded = true;
            TogglePause(true);
            loseScreen.SetActive(true);
            Debug.Log("Lost");
        }

    }

    public void CarFinished()
    {
        carsFinished++;
        if (CheckIfWon())
        {
            Win();
        }
    }

    private bool CheckIfWon()
    {
        return carsFinished >= carsFinishedToWin;
    }

    private void Win()
    {
        if (!isLevelEnded)
        {
            isLevelEnded = true;
            TogglePause(true);
            winScreen.SetActive(true);
            Debug.Log("Win");
        }
    }

    public void TogglePause(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
    }

    public string GetNextSceneName()
    {
        curLevelIndex++;
        curLevelIndex = curLevelIndex % levels.Count;
        return levels[curLevelIndex];
    }
}
