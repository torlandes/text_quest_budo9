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

    #region Unity lifecycle

    private void Start()
    {
        _currentStep = _startStep;

        UpdateUi();
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

    #endregion

    #region Private methods

    private void SetCurrentStepAndUpdateUi(Step step)
    {
        _currentStep = step;

        UpdateUi();
    }

    private void TryGoToNextStep(int number)
    {
        int nextStepsCount = _currentStep.NextSteps.Length;
        if (number > nextStepsCount)
        {
            return;
        }
        
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