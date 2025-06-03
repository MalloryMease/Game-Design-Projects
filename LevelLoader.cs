using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private jk_skinwalker skw;

    // Update is called once per frame
    void Update()
    {
        skw = FindAnyObjectByType<jk_skinwalker>();
    }

    public void LoadNextLevel(string name)
    {
        StartCoroutine(LoadLevel(name));
    }

    IEnumerator LoadLevel(string name)
    {
        if (skw != null)
        {
            skw.enabled = false;
        }
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(name);
    }
}
