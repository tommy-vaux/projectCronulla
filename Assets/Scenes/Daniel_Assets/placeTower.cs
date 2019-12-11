using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class placeTower : MonoBehaviour
{
    public GameObject selectedTower;
    private GameObject selectedTowerGreen;
    private GameObject selectedTowerRed;

    // TODO
    [Header("Prefabs")]
    public GameObject batTower;
    public GameObject cannonTower;
    public GameObject gatlingTower;
    // hardcode prefabs for towers
    [Header("green")]
    public GameObject batTowerGreen;
    public GameObject cannonTowerGreen;
    public GameObject gatlingTowerGreen;

    [Header("red")]
    public GameObject batTowerred;
    public GameObject cannonTowerred;
    public GameObject gatlingTowerred;
    // Update is called once per frame
    void Update()
    {
        if (selectedTower != null)// replace with statement that allows for swapping of tower selection
        {
            RaycastHit hit;
            Ray ghostRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ghostRay, out hit) && EventSystem.current.currentSelectedGameObject == null)
            {
                Debug.Log("Hit Layer: " + hit.collider.gameObject.tag);
                Vector3 actualplace = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

                // TODO: implement A way to do this for swapping out the tower that is in use
                var actualTower = selectedTowerGreen; 
                var actualTowerred = selectedTowerRed;
                if (hit.transform.tag == "placementArea")
                {
                    actualTowerred.transform.position = new Vector3(-1000, -1000, -1000);
                    actualTower.transform.position = actualplace;
                    //Debug.Log("Placeable at" + hit.point + "!");
                }
                else
                {
                    actualTower.transform.position = new Vector3(-1000, -1000, -1000);
                    actualTowerred.transform.position = hit.point;
                    //Debug.Log("Not Placeable at" + hit.point + "!");
                }
            } else if (EventSystem.current.currentSelectedGameObject != null)
            {
                // move both towers to -1000
                hideTowers();
            }
        }
        // place tower at placable area where player clicks. 
        if (Input.GetMouseButtonDown(0) && selectedTower != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "placementArea"){
                    Vector3 actualplace = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                    var place = Instantiate(selectedTower, actualplace, hit.transform.rotation);
                    Debug.Log("Placed at"+ actualplace+"!"); 
                }
                else {
                   Debug.Log("Not Placed!"); 
                }
            }
        }
    }

    public void chooseTower(int towerID)
    {
        if(towerID == 0)
        {
            // bat
            selectedTower = batTower;
            selectedTowerGreen = batTowerGreen;
            selectedTowerRed = batTowerred;
        } else if(towerID == 1)
        {
            // cannon
            selectedTower = cannonTower;
            selectedTowerGreen = cannonTowerGreen;
            selectedTowerRed = cannonTowerred;
        } else if(towerID == 2)
        {
            // gatling gun
            selectedTower = gatlingTower;
            selectedTowerGreen = gatlingTowerGreen;
            selectedTowerRed = gatlingTowerred;
        }
    }

    void hideTowers()
    {
        batTowerGreen.transform.position = new Vector3(-1000, -1000, -1000);
        cannonTowerGreen.transform.position = new Vector3(-1000, -1000, -1000);
        gatlingTowerGreen.transform.position = new Vector3(-1000, -1000, -1000);
        batTowerred.transform.position = new Vector3(-1000, -1000, -1000);
        cannonTowerred.transform.position = new Vector3(-1000, -1000, -1000);
        gatlingTowerred.transform.position = new Vector3(-1000, -1000, -1000);
    }
}
