using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] int rocketBonus = 1;
    [SerializeField] int maxBonus = 8;

    private Transform player;
    private RocketBarrage rocketBarrage;
    private bool collected = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            rocketBarrage = playerObj.GetComponent<RocketBarrage>();
        }
    }

    void Update()
    {
        if (collected || player == null || rocketBarrage == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < pickupDistance)
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (rocketBarrage.rocketCount >= maxBonus)
            return;

        rocketBarrage.rocketCount += rocketBonus;

        rocketBarrage.rocketCount = Mathf.Min(rocketBarrage.rocketCount, maxBonus);

        collected = true;

        Destroy(gameObject);
    }
}
