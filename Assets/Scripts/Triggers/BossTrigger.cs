using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public EnemyAI Boss;

    public void Awake()
    {
        Boss.Deactivate();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Boss.Activate();
            gameObject.SetActive(false);
        }
    }
}