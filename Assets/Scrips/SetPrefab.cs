using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SetPrefab : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    private ARTrackedImageManager manager;

    private Dictionary<string, GameObject> objs;

    void Start()
    {
        manager = GetComponent<ARTrackedImageManager>();
        if (manager == null) return;
        manager.trackablesChanged.AddListener(OnImageChanged);
        objs = new Dictionary<string, GameObject>();
        SetUp();
    }

    void Oestroy()
    {
        manager.trackablesChanged.RemoveListener(OnImageChanged);
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

    private void OnImageChanged(ARTrackablesChangedEventArgs<ARTrackedImage> args)
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
            UppdateImage(trackedImage.Value);
        }
    }
    private void UppdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null) return;

        if (trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            objs[trackedImage.referenceImage.name].gameObject.SetActive(false);
        }

        Debug.Log(objs[trackedImage.name]);

        objs[trackedImage.referenceImage.name].gameObject.SetActive(true);
        objs[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
        objs[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;
        
    }
}
