using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public float speed;

    private Transform targetMedicine;
    private Transform targetFeed;

    private FishNeededManager fnm;
    private Patrolling ptrl;

    //public SpriteRenderer fishSprite;
    //private fishStat fish;

    private void Start()
    {
        fnm = GameObject.Find("FishNeededManager").GetComponent<FishNeededManager>();
        ptrl = GetComponent<Patrolling>();
        //fish = gameObject.GetComponent<fishStat>();
    }

    void Update()
    {
        if (fnm.isMovingMedicine == true)
        {
            targetMedicine = GameObject.FindGameObjectWithTag("Medicine").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, targetMedicine.position, speed * Time.deltaTime);

            if (targetMedicine.position.x > transform.position.x && ptrl.rotationValue != 0)
            {
                ptrl.isRotate = true;

                if (ptrl.isRotate == true)
                {
                    ptrl.rotationValue -= 10;
                    transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);

                    if (ptrl.rotationValue <= 0)
                    {
                        ptrl.isRotate = false;
                        ptrl.rotationValue = 0;
                        transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);
                    }
                }
            }
            else if (targetMedicine.position.x < transform.position.x && ptrl.rotationValue != 180)
            {
                ptrl.isRotate = true;

                if (ptrl.isRotate == true)
                {
                    ptrl.rotationValue += 10;
                    transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);

                    if (ptrl.rotationValue >= 180)
                    {
                        ptrl.isRotate = false;
                        ptrl.rotationValue = 180;
                        transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);
                    }
                }
            }
        }

        if (fnm.isMovingFeed == true)
        {
            targetFeed = GameObject.FindGameObjectWithTag("Feed").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, targetFeed.position, speed * Time.deltaTime);

            if (targetFeed.position.x > transform.position.x && ptrl.rotationValue != 0)
            {
                ptrl.isRotate = true;

                if (ptrl.isRotate == true)
                {
                    ptrl.rotationValue -= 10;
                    transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);

                    if (ptrl.rotationValue <= 0)
                    {
                        ptrl.isRotate = false;
                        ptrl.rotationValue = 0;
                        transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);
                    }
                }
            }
            else if (targetFeed.position.x < transform.position.x && ptrl.rotationValue != 180)
            {
                ptrl.isRotate = true;

                if (ptrl.isRotate == true)
                {
                    ptrl.rotationValue += 10;
                    transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);

                    if (ptrl.rotationValue >= 180)
                    {
                        ptrl.isRotate = false;
                        ptrl.rotationValue = 180;
                        transform.localRotation = Quaternion.Euler(0, ptrl.rotationValue, 0);
                    }
                }
            }
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
