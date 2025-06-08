using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAndLoad : MonoBehaviour
{
    public CanvasGroup fadePanel;       // 拖入 FadePanel UI
    public float fadeDuration = 5f;     // 淡出时间
    public string sceneToLoad = "LoseScene";

    private bool isFading = false;

    public void StartFadeAndLoad()
    {
        if (!isFading)
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private System.Collections.IEnumerator FadeOutAndLoadScene()
    {
        isFading = true;
        float time = 0f;

        while (time < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }

        fadePanel.alpha = 1f;
        yield return new WaitForSeconds(0.5f); // 稍微黑屏一会再跳转
        SceneManager.LoadScene(sceneToLoad);
    }
}