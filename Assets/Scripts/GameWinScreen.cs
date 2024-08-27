using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _content;
    [SerializeField] private Button _nextButton;
    [SerializeField] private TextQuest _textQuest;

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        _content.SetActive(false);
        _nextButton.onClick.AddListener(NextButtonClickedCallback);
    }

    private void Start()
    {
        _textQuest.OnLastStepEntered += LastStepEnteredCalllback;
    }

    private void OnDestroy()
    {
        _textQuest.OnLastStepEntered -= LastStepEnteredCalllback;
    }

    #endregion

    #region Private methods

    private void LastStepEnteredCalllback()
    {
        _content.SetActive(true);
    }

    private void NextButtonClickedCallback()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    #endregion
}