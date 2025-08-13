using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class EncounterZone : MonoBehaviour
{
    // 10% chance to trigger a battle on every step
    public float encounterChance = 0.10f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered is the Player
        if (other.CompareTag("Player")) 
        {
            // Roll the dice! Random.value is a random float between 0.0 and 1.0
            if (Random.value < encounterChance)
            {
                Debug.Log("A wild ghost appeared!");
                // Later, this will load the battle scene
                SceneManager.LoadScene("BattleScene"); 
            }
        }
    }
}