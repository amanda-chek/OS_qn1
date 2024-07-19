using UnityEngine;
using UnityEngine.UI;

public class ShowWindowOnApproach : MonoBehaviour
{
    public GameObject[] canvases; // Array of canvases to switch between
    public string playerTag = "Player"; // Tag for the player
    public Button nextButton; // Reference to the "Next" button

    private int currentCanvasIndex = 0;
    private string doneTag = "doneBTN"; // Tag to check when to close the entire canvas

    void Start()
    {
        // Ensure all canvases are initially inactive
        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClicked); // Add listener to the button
        }
        else
        {
            Debug.LogError("Next button is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player entered the trigger zone");

            // Show the first canvas when the player enters the trigger zone
            if (canvases.Length > 0)
            {
                canvases[currentCanvasIndex].SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player exited the trigger zone");
            // Optionally handle player exit if needed
        }
    }

    public void OnNextButtonClicked()
    {
        if (canvases.Length > 0)
        {
            // Check if the nextButton has the "doneBTN" tag
            if (nextButton.CompareTag(doneTag))
            {
                Debug.Log("Found 'Done' tag on button. Hiding all canvases.");
                // Hide all canvases when the "Done" tag is encountered
                foreach (GameObject canvas in canvases)
                {
                    canvas.SetActive(false);
                }
            }
            else
            {
                // Hide the current canvas
                Debug.Log("Hiding canvas: " + canvases[currentCanvasIndex].name);
                canvases[currentCanvasIndex].SetActive(false);

                // Move to the next canvas
                currentCanvasIndex++;
                if (currentCanvasIndex >= canvases.Length)
                {
                    currentCanvasIndex = 0; // Optionally wrap around to the first canvas
                }

                // Show the next canvas
                Debug.Log("Showing canvas: " + canvases[currentCanvasIndex].name);
                canvases[currentCanvasIndex].SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("No canvases assigned in the array.");
        }
    }
}
