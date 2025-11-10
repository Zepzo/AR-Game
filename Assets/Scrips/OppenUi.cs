using UnityEngine;
using UnityEngine.SceneManagement;

public class OppenUi : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
}