using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightButton : MonoBehaviour
{

    public Color32 color;

    [SerializeField]
    private GameObject overlay;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClicked()
    {        
        GameManager.instance.TrafficLightChanged(this); 
    }

    public void ToggleLight(bool isActive)
    {
        overlay.SetActive(!isActive);
    }
}
