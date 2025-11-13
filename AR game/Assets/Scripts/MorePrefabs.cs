using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MorePrefabs : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    private ARTrackedImageManager manager;

    private Dictionary<string, GameObject> objs;

    void Start()
    {
        manager = GetComponent<ARTrackedImageManager>();
        if (manager == null) return;
        manager.trackedImagesChanged += OnImageChanged;
        objs = new Dictionary<string, GameObject>();
        SetUp();
    }

    void OnDestroy()
    {
        manager.trackedImagesChanged -= OnImageChanged;
    }

    private void SetUp()
    {
        foreach (var prefab in prefabs)
        {
            var _objs = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _objs.name = prefab.name;
            _objs.name = prefab.name;
            _objs.gameObject.SetActive(false);
            objs.Add(_objs.name, _objs);
        }
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            UppdateImage(trackedImage);
        }
        foreach (var trackedImage in args.updated)
        {
            UppdateImage(trackedImage);
        }
        foreach (var trackedImage in args.removed)
        {
            UppdateImage(trackedImage);
        }
    }
    private void UppdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null) return;

        if (trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            objs[trackedImage.referenceImage.name].gameObject.SetActive(false);
        }

        objs[trackedImage.referenceImage.name].gameObject.SetActive(true);
        objs[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
        objs[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
        
    }
}
