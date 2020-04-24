using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultLocation : MonoBehaviour
{
    public InputField locationSearchBox;
    public Slider zoom;
    // Start is called before the first frame update
    void Start()
    {
        locationSearchBox.text = "299 Doon Valley Drive";
        zoom.value = 16;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
