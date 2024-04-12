using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesInteraction : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
            FindFirstObjectByType<AppManager>().canFinish = true;
          


        }
    }
}