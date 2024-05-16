using ScriptableObjectArchitecture;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private FloatVariable _score;
    [SerializeField] private FloatVariable _scoreIncrement;
    [SerializeField] private FloatVariable _scoreIncrementInterval;

    private void Start()
    {
        _score.Value = 0;

        InvokeRepeating(nameof(ScoreOverTime), 0, _scoreIncrementInterval);
    }

    private void ScoreOverTime()
    {
        _score.Value += _scoreIncrement;
    }
}
