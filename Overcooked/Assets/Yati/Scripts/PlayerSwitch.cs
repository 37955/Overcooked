using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CameraFollow cameraFollow; // Reference to the CameraFollow script

    public GameObject activePlayer;

    private void Start()
    {
        activePlayer = player1;
        SetActivePlayer(activePlayer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            activePlayer = (activePlayer == player1) ? player2 : player1;
            SetActivePlayer(activePlayer);
        }
    }

    private void SetActivePlayer(GameObject newActivePlayer)
    {
        var player1Movement = player1.GetComponent<PlayerMovement>();
        player1Movement.enabled = (newActivePlayer == player1);
        if (newActivePlayer != player1)
        {
            if (player1Movement.dustTrail != null && player1Movement.dustTrail.isPlaying)
                player1Movement.dustTrail.Stop();

            if (player1Movement.dustDash != null && player1Movement.dustDash.isPlaying)
                player1Movement.dustDash.Stop();
        }

        var player2Movement = player2.GetComponent<PlayerMovement>();
        player2Movement.enabled = (newActivePlayer == player2);
        if (newActivePlayer != player2)
        {
            if (player2Movement.dustTrail != null && player2Movement.dustTrail.isPlaying)
                player2Movement.dustTrail.Stop();

            if (player2Movement.dustDash != null && player2Movement.dustDash.isPlaying)
                player2Movement.dustDash.Stop();
        }

        player1.transform.Find("CanvasActivePlayer").gameObject.SetActive(newActivePlayer == player1);
        player2.transform.Find("CanvasActivePlayer").gameObject.SetActive(newActivePlayer == player2);

        // Update the camera's active player
        if (cameraFollow != null)
        {
            cameraFollow.SetActivePlayer(newActivePlayer.transform);
        }
    }
}
