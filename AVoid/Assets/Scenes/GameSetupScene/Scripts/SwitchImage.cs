using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticClasses;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public GameObject m_innerText;
    public Text text;
    public Texture m_MapTexture;
    // Start is called before the first frame update
    void Start()
    {
        text = m_innerText.gameObject.GetComponent<Text>();
        Debug.Log(text);
    }

    // Update is called once per frame
    void Update()
    {
        if ((text != null) && (ImageSwitcher.switched && text.enabled))
        {
            text.enabled = false;
            GetComponent<RawImage>().texture = m_MapTexture;
        }

        if ((text != null) && (!ImageSwitcher.switched && !text.enabled))
        {
            text.enabled = true;
            GetComponent<RawImage>().texture = null;
        }
    }
}
