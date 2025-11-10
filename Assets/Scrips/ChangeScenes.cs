using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    public void one()
    {
        SceneManager.LoadScene("1");
    }

    public void two()
    {
        SceneManager.LoadScene("2");
    }

    public void three()
    {
        SceneManager.LoadScene("3");
    }
}
