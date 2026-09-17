using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CardinalPlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

        if (horizontalInput != 0)
        {
            movement = new Vector3(horizontalInput, 0f, 0f);
        }
        else if (verticalInput != 0)
        {
            movement = new Vector3(0f, 0f, verticalInput);
        }

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
