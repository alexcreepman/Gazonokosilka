using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MowerController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float steering;
    public DisplayMower sprite;
    public float jiggling;
    private int score = 0;
    public TextMeshProUGUI scoreText, multiplierText;
    //private float currentSpeed;
    private float multiplier = 2f;
    private int grassBlockPoints = 100;
    private Rigidbody2D rigidbody;
    private int untilMultIncrease;
    private float timer;
    public float multiplierTime;

    public int getScore()
    {
        return score;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Счёт: "+score;
        multiplierText.text = "Множитель " + multiplier + "x!";
        rigidbody = GetComponent<Rigidbody2D>();
        untilMultIncrease = 2;
        Time.timeScale = 1;
    }

    
    // Update is called once per frame
    private void Update()
    {
        if (timer>0) timer -= Time.deltaTime;
        if (timer <= 0)
        {
            multiplier = 1f;
            untilMultIncrease=2;
        }
    }

    void FixedUpdate()
    {
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //рассчет скорости
        
        Vector2 speed = transform.up * (v * acceleration);
        
        rigidbody.AddForce(speed);
        
        
        float direction = Vector2.Dot(rigidbody.velocity, 
            rigidbody.GetRelativeVector(Vector2.up));
        if (direction >= 0f)
        {
            rigidbody.rotation += h * steering * (rigidbody.velocity.magnitude /
                                                  maxSpeed);
        }
        else
        {
            rigidbody.rotation -= h * steering * (rigidbody.velocity.magnitude /
                                                  maxSpeed);
        }

        float driftForce = Vector2.Dot(rigidbody.velocity, rigidbody.GetRelativeVector(Vector2.left));
        Vector2 relativeForce = Vector2.right * driftForce;
        rigidbody.AddForce(rigidbody.GetRelativeVector(relativeForce));

        if (rigidbody.velocity.magnitude > maxSpeed)
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        //currentSpeed = rigidbody.velocity.magnitude;
        float xj = Random.Range(-jiggling, jiggling);
        float yj = Random.Range(-jiggling, jiggling)/2;
        Vector3 jiggle = new Vector3(xj, yj, 0f);
        sprite.transform.position += jiggle;
        
        scoreText.text = "Счёт: "+score;
        multiplierText.text = "Множитель " + multiplier + "x!";

    }

    public void AddScoreGrass()
    {
        score += (int) (grassBlockPoints * multiplier);
    }

    public void quickerMult()
    {
        score += (int) (grassBlockPoints * multiplier);
        untilMultIncrease = untilMultIncrease - 1;
        if (untilMultIncrease <= 0)
        {
            multiplier += 1f;
            untilMultIncrease = (int)(multiplier);
            untilMultIncrease *= untilMultIncrease;
        }
        timer = multiplierTime;
    }
}
