using UnityEngine;
using UnityEngine.UI; // For UI
using UnityEngine.SceneManagement; // For restarting if needed

public class PlayerCollector : MonoBehaviour
{
    public int score = 0;
    public int totalItems;
    public GameObject winCanvas; // Drag your UI Canvas here
    public Text statsText; // Drag your Text element here

    void Start()
    {
        // Calculate total items automatically based on Tag
        totalItems = GameObject.FindGameObjectsWithTag("Collectible").Length;
        winCanvas.SetActive(false); // Hide stats screen at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            Destroy(other.gameObject); // Remove item
            
            // Check for Win Condition
            if (score >= totalItems)
            {
                EndLevel();
            }
        }
        
        // Optional: End Level Trigger (if player walks into a specific zone)
        if (other.CompareTag("Finish"))
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        winCanvas.SetActive(true);
        // Display Stats
        statsText.text = "Run Complete!\nItems Collected: " + score + "/" + totalItems;
        // Optional: Stop time or freeze player here
        Time.timeScale = 0; 
    }
}