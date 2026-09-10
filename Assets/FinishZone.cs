using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] float finishDistance = 2f;
    [SerializeField] Transform player;
    [SerializeField] GameObject winUI;

    private bool hasWon = false;

    void Start()
    {
        winUI.SetActive(false);
    }

    void Update()
    {
        if (hasWon)
            return;

        float distance = Vector3.Distance(
            player.position,
            transform.position
        );

        if (distance <= finishDistance)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        hasWon = true;

        winUI.SetActive(true);
    }
}