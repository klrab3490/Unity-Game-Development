using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RayCastTest : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] Transform  point;
    // Start is called before the first frame update
    void Start() {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began ) {
            List<ARRaycastHit> hit= new List<ARRaycastHit>();
            raycastManager.Raycast(Input.touches[0].position, hit, TrackableType.Planes);
            foreach (var item in hit) {
                point.position = item.pose.position;
            }
            //List<ARRaycastHit> hits = new List<ARRaycastHit>();
        }
    }
}
