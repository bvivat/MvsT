using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretClicked : MonoBehaviour
{
    public GameObject rangeEffect;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit,100.0f))
            {
                if(hit.transform !=null)
                {
                    Debug.Log(hit.transform.gameObject.name);
                    if(hit.transform.gameObject.tag=="turret")
                    {
                        rangeEffect=hit.transform.GetChild(0).gameObject;
                        DisplayInfo();
                    }
                }
            }
        }
    }

    void DisplayInfo()
    {
        rangeEffect.SetActive(true);
    }

    void HideInfo()
    {
        rangeEffect.SetActive(false);
    }
}
