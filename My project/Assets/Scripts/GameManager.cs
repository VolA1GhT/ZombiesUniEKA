using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    public GameObject gameOverPanel;
    public Vector3 selectedSize;
    public Vector3 pushForce;
    private int selectedIndex = 0;
    private InputAction next, prev, jump;
    public static int score = 0;
    public GameObject collectablePrefab;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    private float timer;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip musicClip;
    public AudioClip collectClip;
    public AudioClip jumpClip;


    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
        prev = InputSystem.actions.FindAction("NextZombie");
        next = InputSystem.actions.FindAction("PreviousZombie");
        jump = InputSystem.actions.FindAction("Jump");

        SelectZombie(selectedIndex);
    }

    private void Update()
    {
        if (next.WasPressedThisFrame())
        {
            Debug.Log("next");
            selectedIndex++;
            if (selectedIndex > 3)
                selectedIndex = 0;
            SelectZombie(selectedIndex);
        }
        if (prev.WasPressedThisFrame())
        {
            Debug.Log("prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = 3;
            SelectZombie(selectedIndex);
        }
        if (jump.WasPressedThisFrame())
        {
            Debug.Log("jump");
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            sfxSource.PlayOneShot(jumpClip);
            if (rb != null)
                rb.AddForce(pushForce);
        }
        timer += Time.deltaTime;
        timerText.text = "Time: " + timer.ToString("F1") +"s";

        AddScore();
    }

    void SelectZombie(int index)
    {
        if(selectedZombie != null)
        {
            selectedZombie.transform.localScale = Vector3.one;
        }
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected: " + selectedZombie);

    }

    public void AddScore()
    {
        score++;
        sfxSource.PlayOneShot(collectClip);
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        if(zombies[0] == null && zombies[1] == null && zombies[2] == null && zombies[3] == null)    
        {
            gameOverPanel.SetActive(true);
        }
    }
}
