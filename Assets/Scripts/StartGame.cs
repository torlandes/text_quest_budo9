using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _startButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _startButton.onClick.AddListener(EnterGame);
    }

    #endregion

    #region Public methods

    public void EnterGame()
    {
        Debug.Log("EnterGame");
        SceneManager.LoadScene("GameOverScene");
    }

    #endregion
}