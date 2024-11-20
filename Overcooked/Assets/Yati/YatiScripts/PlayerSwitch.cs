using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private GameObject activePlayer;

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
        player1.GetComponent<PlayerMovement>().enabled = (newActivePlayer == player1);
        player2.GetComponent<PlayerMovement>().enabled = (newActivePlayer == player2);
    }
}
