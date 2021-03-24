using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float waitingTime = 1.5f;
    public static GameManager manager;
    public bool ready = true;
    public bool end = false;
    public GameObject cactus;
    public GameObject gem;
    public AudioClip deathSound;
    public AudioClip goalSound;
    public int score;
    public TextMesh scoreText;
    public GameObject gameOverText;
    void Start()
    {
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ready == true) {
            ready = false;
            InvokeRepeating("MakeCactus", 1f, waitingTime);
            InvokeRepeating("MakeGem", 1f, waitingTime);
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    } 
    void MakeCactus() {
        Instantiate(cactus);
    }

    void MakeGem()
    {
        Instantiate(gem);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        end = true;
        CancelInvoke("MakeCactus");
        CancelInvoke("MakeGem");
        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
        AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
    }
    public void GetScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        AudioSource.PlayClipAtPoint(goalSound, this.transform.position);
    }

}
