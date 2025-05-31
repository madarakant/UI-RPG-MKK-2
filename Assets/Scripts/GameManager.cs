using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Character Prefabs")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] enemyPrefabs;
    
    [Header("References")]
    [SerializeField] private Transform characterParent;
    
    [Header("UI Elements")]
    [SerializeField] private GameObject battleUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI enemyNameText;
    
    private Player player;
    private Enemy currentEnemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Clean up existing characters
        foreach (Transform child in characterParent)
        {
            Destroy(child.gameObject);
        }

        // Create player
        GameObject playerObj = Instantiate(playerPrefab, characterParent);
        player = playerObj.GetComponent<Player>();
        
        if (player == null)
        {
            Debug.LogError("Player component missing on player prefab!");
            return;
        }

        // Spawn first enemy
        SpawnNewEnemy();
        
        // Set up UI
        battleUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void SpawnNewEnemy()
    {
        if (currentEnemy != null)
        {
            Destroy(currentEnemy.gameObject);
        }

        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned!");
            return;
        }

        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject enemyObj = Instantiate(enemyPrefab, characterParent);
        currentEnemy = enemyObj.GetComponent<Enemy>();
        
        if (currentEnemy == null)
        {
            Debug.LogError("Enemy component missing on enemy prefab!");
            return;
        }

        enemyNameText.text = currentEnemy.CharacterName;
    }

    public void PlayerAttack()
    {
        if (player.IsDead() || currentEnemy.IsDead()) return;
        
        int damage = player.Attack();
        currentEnemy.TakeDamage(damage);
        
        if (currentEnemy.IsDead())
        {
            SpawnNewEnemy();
        }
        else
        {
            EnemyAttack();
        }
    }

    public void ToggleShield()
    {
        player.ToggleShield();
    }

    private void EnemyAttack()
    {
        if (player.IsDead() || currentEnemy.IsDead()) return;
        
        int damage = Mathf.Max(1, currentEnemy.AttackPower - player.Defense);
        player.TakeDamage(damage);
        
        if (player.IsDead())
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        battleUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        // Clean up current characters
        Destroy(player.gameObject);
        if (currentEnemy != null) Destroy(currentEnemy.gameObject);
        
        // Reinitialize game
        InitializeGame();
    }
}