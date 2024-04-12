using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesInteraction : MonoBehaviour
{

    [SerializeField] GameObject throwCollectible;
    [SerializeField] float throwDelay = 5f;
    [SerializeField] Camera cam;
    [SerializeField] float throwOffset;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
            FindFirstObjectByType<AppManager>().canFinish = true;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "Floor")
                {
                    Vector3 pos = hit.point;
                    pos.y += throwOffset;
                    GameObject objectThrown = Instantiate(throwCollectible, pos, Quaternion.identity);
                    StartCoroutine(WaitForSeconds(objectThrown));

                }
                    
                    
            }
        }
    }

    IEnumerator WaitForSeconds(GameObject go)
    {
        //Wait Until Sound has finished playing

        yield return new WaitForSeconds(throwDelay);
        Destroy(go);
      



    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}