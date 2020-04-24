using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StaticClasses;

public class ChooseMap : MonoBehaviour
{
    public Button m_BrowseMapButton;
    // Start is called before the first frame update
    void Start()
    {
        m_BrowseMapButton.onClick.AddListener(BtnBrowseMapOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BtnBrowseMapOnClick()
    {
        SceneManager.LoadScene("ZoomableMap");
    }


}
