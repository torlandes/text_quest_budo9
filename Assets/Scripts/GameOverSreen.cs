using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _headerLabel;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _startButton.onClick.AddListener(EnterGame);
        
        Statistics statistics = FindObjectOfType<Statistics>();
        _headerLabel.text = $"Game Over! \n Your moves: {statistics.MovesCount} ";
    }

    #endregion

    #region Public methods

    public void EnterGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}