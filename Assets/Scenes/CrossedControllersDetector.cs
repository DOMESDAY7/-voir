using UnityEngine;
using UnityEngine.XR;

public class CrossedControllersDetector : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;
    public float crossDistanceThreshold = 0.1f; // Adjust this value as needed
    private bool isPaused = false;



    void Update()
    {
        // Check the distance between the two controllers
        float distance = Vector3.Distance(leftController.position, rightController.position);
        Debug.Log(distance);

        if (distance < crossDistanceThreshold && !isPaused)
        {
            // Controllers are crossed, pause the game
            PauseGame();
        }
        else if (distance >= crossDistanceThreshold && isPaused)
        {
            // Controllers are no longer crossed, resume the game
            ResumeGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Paused");
        // Add any other code necessary to pause the game
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        Debug.Log("Game Resumed");
        // Add any other code necessary to resume the game
    }
}
