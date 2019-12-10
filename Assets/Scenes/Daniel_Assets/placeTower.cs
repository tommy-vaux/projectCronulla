using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeTower : MonoBehaviour
{
    public Transform InstantiateTower;


    // Update is called once per frame
    void Update()
    {
        // place tower at placable area where player clicks. 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "placementArea"){
                    Vector3 actualplace = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.3f, hit.transform.position.z);
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
