using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StaticClasses;

public class StartGame : MonoBehaviour
{
    public Button m_StartGameButton;
    public Button m_GoBackButton;
    // Start is called before the first frame update
    void Start()
    {
        m_StartGameButton.onClick.AddListener(BtnStartGameOnClick);
        m_GoBackButton.onClick.AddListener(BtnGoBackOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BtnStartGameOnClick()
    {
        SceneManager.LoadScene("Lobby");
    }

    void BtnGoBackOnClick()
    {
        SceneManager.LoadScene("Login");
        ImageSwitcher.switched = false;
    }
}
