using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySequence : MonoBehaviour
{
    public ASyncLoader asyncLoader;

    [SerializeField] GameObject NielsCredits;
    [SerializeField] GameObject story1;
    [SerializeField] GameObject story2;
    
    public void Start()
    {
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        yield return new WaitForSeconds(2.0f);
        NielsCredits.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        story1.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        story2.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        if (asyncLoader != null)
        {
            asyncLoader.LoadLevel("Scene_01");
        }
        else
        {
            Debug.LogError("ASyncLoader component not found on SceneLoader GameObject.");
        }
    }
}
