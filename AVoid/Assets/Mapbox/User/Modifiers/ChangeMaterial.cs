using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public Material originalMat;
    public Material replaceMat;
    public List<Transform> parks;
    public Button clickHandler;
    private Mesh selectedMesh;

    Vector3 clickPos;
    bool clicked;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            Debug.Log("yo");
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    clickPos = touch.position;
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(clickPos);
                    if (Physics.Raycast(ray, out hit) && !OnFieldClick.frameTracker)
                    {
                        Debug.Log("Clicked on gameobject: " + hit.collider.transform.gameObject.GetInstanceID());
                        TapOrClick(hit.collider.transform.gameObject.GetInstanceID());
                        OnFieldClick.frameTracker = true;
                    }
                    break;
            }
        }*/
/*
#if UNITY_ANDROID || UNITY_IOS
        clicked = Input.touchCount > 0;
                if (clicked)
                    clickPos = Input.GetTouch(0).position;
#else
        clicked = Input.GetMouseButtonDown(0);
        clickPos = Input.mousePosition;

#endif*/
        


        /* if (Input.GetMouseButtonDown(0))
          {
              Debug.Log("Clicked on gameobject: " + gameObject.GetInstanceID());

              TapOrClick();
          }*/

    }

    private void LateUpdate()
    {
        OnFieldClick.frameTracker = false;
    }
    private void TapOrClick(int id)
    {
        Debug.Log("changing mat for id " + id);

        try
        {
            ChangeMat(id, replaceMat);
            SetSelectedMap();
            OnFieldClick.readyToContinue = true;
        }
        catch (Exception ex) { }
    }

    private void OnMouseDown()
    {
        //TapOrClick(gameObject.GetInstanceID());

    }

    bool selected = false;
    private void ChangeMat(int id, Material mat)
    {
        Debug.Log("looking for id " + id);
        Transform clickedPark = null;
        //Set every other mesh to the original grass material

        foreach (Transform otherPark in parks)
        {
            try
            {
                Debug.Log("park " + otherPark.GetInstanceID());

                if (otherPark.gameObject.GetInstanceID() == id)
                {
                    Debug.Log("found the park");
                    clickedPark = otherPark;
                }
                otherPark.GetComponent<MeshRenderer>().material = originalMat;

            }
            catch (Exception ex) { Debug.Log(ex.Message); }
        }
        Debug.Log("clicked park is " + clickedPark.gameObject.name);
        if (clickedPark != null)
            clickedPark.GetComponent<MeshRenderer>().material = mat;

    }

    private void SetSelectedMap()
    {
        selectedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }
}
