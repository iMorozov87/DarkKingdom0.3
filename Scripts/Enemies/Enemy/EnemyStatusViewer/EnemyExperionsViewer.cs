using UnityEngine;

public class EnemyExperionsViewer : MonoBehaviour
{
    [SerializeField] private TextMesh _experionsText;

    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Die += ShowExperience;
    }

    private void OnDisable()
    {
        _enemy.Die -= ShowExperience;
    }

    private void  ShowExperience()
    {        
        _experionsText.gameObject.SetActive(true);
        _experionsText.text = "+ " + _enemy.RewardExperience + " XP";
    }
}
