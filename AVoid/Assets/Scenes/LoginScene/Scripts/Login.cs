using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Button m_CreateGameButton;
    public Button m_JoinGameButton;

    // Start is called before the first frame update
    void Start()
    {
        m_CreateGameButton.onClick.AddListener(BtnCreateGameOnClick);
        //m_signupButton.onClick.AddListener(btnSignupOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BtnCreateGameOnClick() {
        SceneManager.LoadScene("GameSetup");
    }

    void BtnJoinGameOnClick()
    {
        SceneManager.LoadScene("Lobby");
    }

}
