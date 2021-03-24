using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CactusMove : MonoBehaviour
{
    public float cactusSpeed;
    public TextMesh scoreText;
    public int preScore = 0;
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * cactusSpeed * Time.deltaTime);

        if (this.transform.position.x < -6f)
        {
            Destroy(this.gameObject);
        }

        int score = Int32.Parse(scoreText.text);
        settingSpeed(score, preScore);
    }

    void OnEnable()
    {
        this.transform.position = new Vector3(6f, UnityEngine.Random.Range(-1, 1.5f), 0);
    }

    void settingSpeed(int score, int preScore)
    {
        if (score != preScore)
        {
            cactusSpeed = 5.0f + (score / 10f) * 0.3f;
        }
        preScore = score;
    }
}
