using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinArea : MonoBehaviour {

    public List<GameObject> insideMe = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name != "Bowling Ball")
        {
            if (!insideMe.Contains(other.gameObject))
            {
                insideMe.Add(other.gameObject);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Bowling Ball")
        {
            if (insideMe.Contains(other.gameObject))
            {
                insideMe.Remove(other.gameObject);
            }
        }
        //foreach (GameObject obj in insideMe)
        //{
        //    Debug.Log(obj.name);
        //}
    }
}
