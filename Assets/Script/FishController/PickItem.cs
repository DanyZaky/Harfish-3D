using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public float speed;

    private Transform targetMedicine;
    private Transform targetFeed;

    private FishNeededManager fnm;

    //public SpriteRenderer fishSprite;
    //private fishStat fish;

    private void Start()
    {
        fnm = GameObject.Find("FishNeededManager").GetComponent<FishNeededManager>();
        //fish = gameObject.GetComponent<fishStat>();
    }

    void Update()
    {
        if (fnm.isMovingMedicine == true)
        {
            targetMedicine = GameObject.FindGameObjectWithTag("Medicine").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, targetMedicine.position, speed * Time.deltaTime);

            //if (targetMedicine.position.x > transform.position.x)
            //{
            //    fishSprite.flipX = false;
            //}
            //else if (targetMedicine.position.x < transform.position.x)
            //{
            //    fishSprite.flipX = true;
            //}
        }

        if (fnm.isMovingFeed == true)
        {
            targetFeed = GameObject.FindGameObjectWithTag("Feed").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, targetFeed.position, speed * Time.deltaTime);

            //if (targetFeed.position.x > transform.position.x)
            //{
            //    fishSprite.flipX = false;
            //}
            //else if (targetFeed.position.x < transform.position.x)
            //{
            //    fishSprite.flipX = true;
            //}
        }
    }

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Medicine")
        {
            fnm.isMovingMedicine = false;
            fnm.isPatrolling = true;
            Destroy(targetMedicine.gameObject);
        }

        if (col.gameObject.tag == "Feed")
        {
            fnm.isMovingFeed = false;
            fnm.isPatrolling = true;
            //fish.FeededFunc(1);
            Destroy(targetFeed.gameObject);
        }

        if (col.gameObject.tag == "Cat")
        {
            Destroy(gameObject);
        }
    }
}
