using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    [Header("UI")]
    [SerializeField] private TMP_Text _descriptionLabel;
    [SerializeField] private TMP_Text _answerLabel;
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    [SerializeField] private Button _button4;

    [Header("Settings")]
    [SerializeField] private Step _startStep;

    [Header("DEBUG")]
    [SerializeField] private Step _currentStep;

    #endregion

    #region Properties

    public static int MovesCount { get; private set; }
    
    #endregion

    #region Unity lifecycle

    private void Start()
    {

        //делегаты
        _button1.onClick.AddListener(() => TryGoToNextStep(1));
        _button2.onClick.AddListener(() => TryGoToNextStep(2));
        _button3.onClick.AddListener(() => TryGoToNextStep(3));
        _button4.onClick.AddListener(() => TryGoToNextStep(4));

        MovesCount = 0;
        SetCurrentStepAndUpdateUi(_startStep);
    }

    private void Update()
    {
        for (int i = 1; i < 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                TryGoToNextStep(i);
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log($"TextQuest MovesCount '{MovesCount}'");
    }

    #endregion

    #region Private methods
    

    private void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void SetCurrentStepAndUpdateUi(Step step)
    {
        _currentStep = step;

        UpdateUi();
    }

    private void TryGoToNextStep(int number)
    {
        //костыль
        if (_currentStep.NextSteps.Length == 0)
        {
            GoToGameOverScene();
            return;
        }

        int nextStepsCount = _currentStep.NextSteps.Length;
        if (number > nextStepsCount)
        {
            return;
        }

        MovesCount++;
        int nextStepIndex = number - 1; //number = 1, index = 0
        Step nextStep = _currentStep.NextSteps[nextStepIndex];
        SetCurrentStepAndUpdateUi(nextStep);
    }

    private void UpdateUi()
    {
        _descriptionLabel.text = _currentStep.Description;
        _answerLabel.text = _currentStep.Answers;
    }

    #endregion
}