using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform loadingPanel;
    public Button startGameButton;
    private Camera mainCamera;
    public AudioSource audioSource;
    public Text totalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        mainCamera = Camera.main;
        loadingPanel.sizeDelta = new Vector2(Screen.width, Screen.height);
        HideLoadingScreen();
        startGameButton.onClick.AddListener(StartGame);
    }

    public void ShowLoadingScreen()
    {
        StartCoroutine(AnimateLoadingScreen(new Vector2(0.0f, 0.0f)));
    }

    public void HideLoadingScreen()
    {
        StartCoroutine(AnimateLoadingScreen(new Vector2(0.0f, -Screen.height)));
    }

    private IEnumerator AnimateLoadingScreen(Vector2 targetPosition)
    {
        float duration = 1.0f;
        Vector2 startPosition = loadingPanel.anchoredPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            loadingPanel.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        loadingPanel.anchoredPosition = targetPosition;
    }

    public void StartGame()
    {
        ShowLoadingScreen();
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Map");
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(HideLoadingScreenAfterDelay());
    }

    private IEnumerator HideLoadingScreenAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        HideLoadingScreen();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void LateUpdate()
    {


    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Map");
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Map1");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void MuteAudio()
    {
        if (audioSource != null)
        {
            audioSource.mute = true;
        }
    }

    public void UnmuteAudio()
    {
        if (audioSource != null)
        {
            audioSource.mute = false;
        }
    }

    public void UpdateTotalScoreUI(int score)
    {
        totalScoreText.text = "Total Score: " + score.ToString();
    }
}
