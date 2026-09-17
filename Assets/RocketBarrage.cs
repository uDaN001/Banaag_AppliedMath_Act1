using UnityEngine;

public class RocketBarrage : MonoBehaviour
{
    [SerializeField] float fireInterval = 3f;
    
    private float timer = 0;

    [SerializeField] GameObject rocketPrefab;
    public int rocketCount = 4;

    [SerializeField] float spawnOffset = 45f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            FireRocket();
            timer = 0f;
        }
    }

    private void FireRocket()
    {
        float spacing = 360f / rocketCount;

        for (int i = 0; i < rocketCount; i++)
        {
            float angle = spawnOffset + (spacing * i);

            float radians = angle * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(
                Mathf.Cos(radians),
                0f,
                Mathf.Sin(radians)
            );

            GameObject rocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);

            Rocket rocketScript = rocket.GetComponent<Rocket>(); 
            rocketScript.SetDirection(direction);
        }
    }
}
