using TMPro;
using UnityEngine;

public class TextQuest : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _descriptionLabel;
    [SerializeField] private TMP_Text _answerLabel;

    [SerializeField] private Step _startStep;

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