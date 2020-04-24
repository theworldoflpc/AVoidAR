using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StaticClasses;

public class SwitchScene : MonoBehaviour
{
    public Button m_SwitchSceneButton;

    // Start is called before the first frame update
    void Start()
    {
        m_SwitchSceneButton.onClick.AddListener(BtnSwitchSceneOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BtnSwitchSceneOnClick()
    {
        ImageSwitcher.switched = true;
        SceneManager.LoadScene("GameSetup");
    }


}
