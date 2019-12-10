using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeTower : MonoBehaviour
{
    public Transform InstantiateTower;

    // TODO
    // hardcode prefabs for towers
    [Header("green")]
    public GameObject batTower;
    public GameObject cannonTower;
    public GameObject gatlingTower;

    [Header("red")]
    public GameObject batTowerred;
    public GameObject cannonTowerred;
    public GameObject gatlingTowerred;
    // Update is called once per frame
    void Update()
    {
        if (true)// replace with statement that allows for swapping of tower selection
        {
            RaycastHit hit;
            Ray ghostRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ghostRay, out hit) && hit.collider.gameObject.layer != 5)
            {
                Vector3 actualplace = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

                // TODO: implement A way to do this for swapping out the tower that is in use
                var actualTower = batTower; 
                var actualTowerred = batTowerred;
                if (hit.transform.tag == "placementArea")
                {
                    actualTower.transform.position = actualplace;
                    Debug.Log("Placeable at" + actualplace + "!");
                }
                else
                {
                    //actualTower.transform.position
                    actualTowerred.transform.position = hit.point;
                    Debug.Log("Not Placeable!");
                }
            }
        }
        // place tower at placable area where player clicks. 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "placementArea"){
                    Vector3 actualplace = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                    var place = Instantiate(InstantiateTower, actualplace, hit.transform.rotation);
                    Debug.Log("Placed at"+ actualplace+"!"); 
                }
                else {
                   Debug.Log("Not Placed!"); 
                }
            }
        }
    }
}
