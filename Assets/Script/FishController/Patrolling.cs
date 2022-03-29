using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    [SerializeField] private Transform[] moveSpots;
    private int randomSpot;

    private FishNeededManager fnm;

    //public SpriteRenderer fishSprite;

    void Start()
    {
        // Debug.Log(fishSprite.flipX);
        fnm = GameObject.Find("FishNeededManager").GetComponent<FishNeededManager>();

        for (int i = 0; i < 23; i++)
        {
            moveSpots[i] = GameObject.Find("MoveSpot (" + (i + 1) + ")").GetComponent<Transform>();
        }

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        if (fnm.isPatrolling == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            //direction
            //if (moveSpots[randomSpot].position.x > transform.position.x)
            //{
                // transform.localScale = new Vector3(0.5f, 0.5f, 1);
            //    fishSprite.flipX = false;
            //}
            //else if (moveSpots[randomSpot].position.x < transform.position.x)
            //{
                // transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            //    fishSprite.flipX = true;
            //}
        }
    }
}
