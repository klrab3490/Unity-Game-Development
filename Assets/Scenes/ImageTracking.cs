using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ImageTracking : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager m_imageManager;
    [SerializeField] Transform SolarSysem;

    public void OnEnable()
    {
        m_imageManager.trackedImagesChanged += OnPlaneChanged;
    }

    public  void OnPlaneChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            SolarSysem.gameObject.SetActive(true);
            SolarSysem.position = trackedImage.transform.position;
        }
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            
            SolarSysem.position = trackedImage.transform.position;
        }
        foreach(ARTrackedImage trackedImage in args.removed)
        {
            SolarSysem.gameObject.SetActive(false);
        }
    }
    public void OnDisable()
    {
        m_imageManager.trackedImagesChanged -= OnPlaneChanged;
    }
}
