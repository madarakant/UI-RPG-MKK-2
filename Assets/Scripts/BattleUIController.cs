using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Button shieldButton;
    [SerializeField] private Button restartButton;
    
    private void Start()
    {
        attackButton.onClick.AddListener(() => GameManager.Instance.PlayerAttack());
        shieldButton.onClick.AddListener(() => GameManager.Instance.ToggleShield());
        restartButton.onClick.AddListener(() => GameManager.Instance.RestartGame());
    }
}