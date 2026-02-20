using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
