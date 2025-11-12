using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager manager;

    [SerializeField] private GameObject one;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject three;

    public void One()
    {
        manager.trackedImagePrefab = one;
    }

    public void Two()
    {
        manager.trackedImagePrefab = two;
    }

    public void Three()
    {
        manager.trackedImagePrefab = three;
    }
}
