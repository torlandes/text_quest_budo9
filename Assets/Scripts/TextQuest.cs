using System;
using TMPro;
using UnityEngine;
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
    [SerializeField] private StepConfig _startStep;

    [Header("DEBUG")]
    [SerializeField] private StepConfig _currentStep;
    [SerializeField] private Statistics _statistics;

    public event Action OnLastStepEntered;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _statistics =
            FindObjectOfType<Statistics>(); //дженерик компонента - принимает <Т> и ищет на сцене геймобжект компоненты Statistics

        //делегаты
        _button1.onClick.AddListener(() => TryGoToNextStep(1));
        _button2.onClick.AddListener(() => TryGoToNextStep(2));
        _button3.onClick.AddListener(() => TryGoToNextStep(3));
        _button4.onClick.AddListener(() => TryGoToNextStep(4));

        _statistics.MovesCount = 0;
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

    #endregion

    #region Private methods

    private void SetCurrentStepAndUpdateUi(StepConfig step)
    {
        _currentStep = step;

        UpdateUi();

        if (_currentStep.NextSteps.Length == 0)
        {
           OnLastStepEntered?.Invoke();
        }
    }

    private void TryGoToNextStep(int number)
    {
        int nextStepsCount = _currentStep.NextSteps.Length;
        if (number > nextStepsCount)
        {
            return;
        }

        _statistics.MovesCount++;
        int nextStepIndex = number - 1; //number = 1, index = 0
        StepConfig nextStep = _currentStep.NextSteps[nextStepIndex];
        SetCurrentStepAndUpdateUi(nextStep);
    }

    private void UpdateUi()
    {
        _descriptionLabel.text = _currentStep.Description;
        _answerLabel.text = _currentStep.Answers;

        int nextStepsLength = _currentStep.NextSteps.Length;
        _button1.gameObject.SetActive(nextStepsLength > 0);
        _button2.gameObject.SetActive(nextStepsLength > 1);
        _button3.gameObject.SetActive(nextStepsLength > 2);
        _button4.gameObject.SetActive(nextStepsLength > 3);
    }

    #endregion
}