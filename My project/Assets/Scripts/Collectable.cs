using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.AddScore();
        }
        if(other.CompareTag("Lava"))
        {
            Destroy(gameObject);
            GameManager.instance.GenerateSteak();
        }
    }
}
