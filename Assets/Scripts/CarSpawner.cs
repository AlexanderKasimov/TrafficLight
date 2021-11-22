using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private Color32 color;

    public Car carPrefab;
    [SerializeField]
    private float timeBetweenCarSpawns = 3f;

    private bool isColorActive = false;

    private bool isFirstSpawn = true;

    // Start is called before the first frame update
    void Start()
    {        
        if (carPrefab)
        {
            GameManager.instance.OnTrafficLightChanged += OnTrafficLightChanged;
            InvokeRepeating("SpawnCar", 0f, timeBetweenCarSpawns);
        }

    }

    public void SpawnCar()
    {
        if (isFirstSpawn || isColorActive)
        {
            Car car = Instantiate(carPrefab, transform.position, transform.rotation);
            if (car)
            {
                car.Init(transform.right, color);
            }
            isFirstSpawn = false;
        }
    
    }

    private void OnTrafficLightChanged(Color32 color)
    {
        CheckIfColorActive(color);
    }

    private void CheckIfColorActive(Color32 color)
    {
        isColorActive = this.color.r == color.r && this.color.g == color.g && this.color.b == color.b;

    }


}
