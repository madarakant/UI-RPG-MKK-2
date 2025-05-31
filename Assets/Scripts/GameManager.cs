using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform characterParent;
    
    [Header("UI Elements")]
    [SerializeField] private GameObject battleUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Text enemyNameText;
    
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
        // Create player
        GameObject playerObj = Instantiate(playerPrefab, characterParent);
        player = playerObj.GetComponent<Player>();
        
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
        
        // Randomly select an enemy prefab
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject enemyObj = Instantiate(enemyPrefab, characterParent);
        currentEnemy = enemyObj.GetComponent<Enemy>();
        
        // Update UI
        enemyNameText.text = currentEnemy.CharacterName;
    }
    
    public void PlayerAttack()
    {
        if (player.IsDead() || currentEnemy.IsDead()) return;
        
        // Player attacks enemy
        int damage = player.Attack();
        currentEnemy.TakeDamage(damage);
        
        // Check if enemy died
        if (currentEnemy.IsDead())
        {
            SpawnNewEnemy();
        }
        else
        {
            // Enemy counterattacks
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