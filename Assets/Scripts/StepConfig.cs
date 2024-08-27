using UnityEngine;

// [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject")]
[CreateAssetMenu(fileName = nameof(StepConfig), menuName = "Configs/Game/Step Config")]
public class StepConfig : ScriptableObject
{
    #region Variables

    [TextArea(5, 10)]
    [SerializeField] private string _answers;
    [TextArea(3, 10)]
    [SerializeField] private string _description;

    [SerializeField] private StepConfig[] _nextStep;

    #endregion

    #region Properties

    public string Answers => _answers;
    public string Description => _description;
    public StepConfig[] NextSteps => _nextStep;

    #endregion
}