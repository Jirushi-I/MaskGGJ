
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneToLoad;
    Scene SceneToUnload;

    bool additive = false;

    void OnEnable()
    {
        SceneManager.LoadSceneAsync(SceneToLoad, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }
}
