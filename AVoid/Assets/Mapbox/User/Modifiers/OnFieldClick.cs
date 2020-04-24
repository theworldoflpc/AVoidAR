using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnFieldClick : MonoBehaviour
{
    public Button continueBtn;
    public Button selectMap;
    public Material grassMat;
    public Material mat;
    public static bool readyToContinue = false;
    private Color readyColor;
    private Color translucentGrey;
    private List<Transform> parks;
    private Texture grassTexture;
    private Texture greenTexture;

    // Start is called before the first frame update
    void Start()
    {
        Material copyMat = Instantiate(mat);
        Material copyGrass = Instantiate(grassMat);
        grassTexture = copyGrass.mainTexture;
        greenTexture = copyMat.mainTexture;
        readyColor = new Color(0.72f, 0, 0.08f);
        translucentGrey = new Color(0.77f, 0.77f, 0.77f, 0.50f);
        continueBtn.onClick.AddListener(ReadyUp);
        selectMap.onClick.AddListener(SetMap);
    }
    bool setGameAreas = false;
    // Update is called once per frame
    private Vector2 clickPos;
    private void ChangeMat(GameObject park)
    {
        try
        {
            Transform clickedPark = park.transform;
            //Set every other mesh to the original grass material

            foreach (Transform otherPark in parks)
            {
                try
                {
                    otherPark.GetComponent<MeshRenderer>().material = grassMat;

                }
                catch (Exception ex) { Debug.Log(ex.Message); }
            }
            if (clickedPark != null)
                clickedPark.GetComponent<MeshRenderer>().material = mat;
        } catch (Exception ex) { }

    }
    bool on = false;
    private void SetMap()
    {
        //GameObject conestogaPark = GameObject.Find("Landuse - 1342245301");
        if (!on)
        {
            grassMat.mainTexture = greenTexture;
        }
        else
        {
            grassMat.mainTexture = grassTexture;
        }
        on = !on;
        readyToContinue = true;
        //ChangeMat(conestogaPark);
    }
    void Update()
    {

        try
        {
            if (!setGameAreas)
            {
                parks = FindParks(gameObject);

                int mapCells = gameObject.transform.childCount;
                if (mapCells > 0)
                {
                    //Check if the final map cell has all its child objects
                    Transform finalMapCell = gameObject.transform.GetChild(mapCells - 1);
                    if (finalMapCell != null && finalMapCell.childCount > 0)
                    {
                        FindGameAreas();
                        setGameAreas = true;
                    }
                }
            }
            if (readyToContinue)
            {
                continueBtn.enabled = true;
                continueBtn.GetComponent<Image>().color = readyColor;
                continueBtn.transform.GetChild(0).GetComponent<Image>().color = Color.white;

            }
            else
            {
                continueBtn.enabled = false;
                continueBtn.GetComponent<Image>().color = translucentGrey;
                continueBtn.transform.GetChild(0).GetComponent<Image>().color = translucentGrey;



            }
        } catch (Exception ex) { }
    }
    public static bool frameTracker = false;
    private void FindGameAreas()
    {
        try
        {
            foreach (Transform park in parks)
            {
                park.gameObject.AddComponent<ChangeMaterial>();
                park.gameObject.GetComponent<ChangeMaterial>().originalMat = grassMat;
                park.gameObject.GetComponent<ChangeMaterial>().replaceMat = mat;
                park.gameObject.GetComponent<ChangeMaterial>().parks = parks;
                /*buildingOrPark.gameObject.AddComponent(typeof(EventTrigger));
                EventTrigger trigger = buildingOrPark.gameObject.GetComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;
                entry.callback.AddListener((eventData) => { Debug.Log("test"); });
                trigger.triggers.Add(entry);*/
            }
        } catch (Exception ex) { }
    }

    public List<Transform> FindParks(GameObject gameObject)
    {
        List<Transform> parks = new List<Transform>();
        int mapCells = gameObject.transform.childCount;

        //Get the cells in the map
        for (int i = 0; i < mapCells; i++)
        {
            Transform cell = gameObject.transform.GetChild(i);
            foreach (Transform buildingOrPark in cell)
            {

                if (buildingOrPark.name.Contains("Landuse"))
                {

                    parks.Add(buildingOrPark);
                }
            }
        }
        return parks;

    }

    private void ReadyUp()
    {
        //Move to the next scene with the selected mesh
        Debug.Log("ready'd up!");
    }
}
