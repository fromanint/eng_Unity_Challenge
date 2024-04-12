using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject minimapCamera = GameObject.FindWithTag("MinimapPlayer");
        minimapCamera.transform.SetParent(this.transform);
        Vector3 minimapPos = Vector3.zero;
        minimapPos.y =   minimapCamera.transform.position.y;
        minimapCamera.transform.localPosition = minimapPos;

    }

 
}
