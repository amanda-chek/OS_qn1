using UnityEngine;

public class PreventPassThrough : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        // Get the player's Transform component
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(playerTransform);
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the trigger is with the player
        if (other.gameObject.tag == "Player")
        {
            // Calculate the correction vector to move the player back
            Vector3 correction = (transform.position - other.transform.position).normalized * 0.01f;

            // Move the player back to a valid position using Transform
            playerTransform.position -= correction;
        }
    }
}