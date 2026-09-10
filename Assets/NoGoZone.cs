using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float warningDistance = 5f;
    [SerializeField] float dangerDistance = 3f;

    private Renderer renderer;
    private Color originalColor;
    private Vector3 originalPosition;

    [SerializeField] float shakeSpeed= 10f;
    [SerializeField] float shakeAmount = 0.5f;
    [SerializeField] float maxWarningTime = 3f;
    private float warningTimer = 0f;
   

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        originalColor = renderer.material.color;
        originalPosition = transform.position;
    }

    private void Update()
    {
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= warningDistance)
        {
            warningTimer += Time.deltaTime;

            // Change color to red
            renderer.material.color = Color.red;

            // Shake zone
            float shakeX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float shakeZ = Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;

            transform.position = originalPosition + new Vector3(
                shakeX,
                0f,
                shakeZ
            );

            // Player got extremely close
            if (distance <= dangerDistance)
            {
                RestartScene();
            }

            // Player stayed too long
            if (warningTimer >= maxWarningTime)
            {
                RestartScene();
            }
        }
        else
        {
            // Return to normal
            warningTimer = 0f;

            renderer.material.color = originalColor;
            transform.position = originalPosition;
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
