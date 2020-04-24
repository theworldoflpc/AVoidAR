using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBack : MonoBehaviour
{
    public Button m_GoBackButton;

    // Start is called before the first frame update
    void Start()
    {
        m_GoBackButton.onClick.AddListener(BtnGoBackOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BtnGoBackOnClick()
    {
        SceneManager.LoadScene("GameSetup");
    }
}
