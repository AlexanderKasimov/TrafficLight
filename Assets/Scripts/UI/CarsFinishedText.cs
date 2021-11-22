using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarsFinishedText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update

    private void Awake() {
        text = GetComponent<Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.carsFinished + "/" + GameManager.instance.carsFinishedToWin;
    }
}
