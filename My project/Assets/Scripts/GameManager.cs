using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] zombies;
    public GameObject selectedZombie;
    void Start()
    {
        selectedZombie = zombies[2];
    }

    void Update()
    {
        
    }
}
