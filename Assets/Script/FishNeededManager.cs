using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishNeededManager : MonoBehaviour
{
    [SerializeField] private GameObject medicinePrefabs, feedPrefabs, ikanPrefabs;

    private float randomPos;

    public bool isMovingMedicine;
    public bool isMovingFeed;

    public bool isPatrolling;

    private float cooldownButton = 3f;
    private float currentCDbutton;

    private bool isCooldown;

    [SerializeField] private Image CDmedicine, CDfeed;


    private void Start()
    {
        isMovingMedicine = false;
        isMovingFeed = false;
        isPatrolling = true;

        currentCDbutton = cooldownButton;

        isCooldown = false;
        CDfeed.fillAmount = 0;
        CDmedicine.fillAmount = 0;
    }
    private void Update()
    {
        CooldownButton();
    }

    private void CooldownButton()
    {
        if (isCooldown == true)
        {
            CDfeed.fillAmount -= 1 / currentCDbutton * Time.deltaTime;
            CDmedicine.fillAmount -= 1 / currentCDbutton * Time.deltaTime;

            if (CDfeed.fillAmount <= 0 && CDmedicine.fillAmount <= 0)
            {
                CDmedicine.fillAmount = 0;
                CDfeed.fillAmount = 0;

                isCooldown = false;

                CDmedicine.gameObject.SetActive(false);
                CDfeed.gameObject.SetActive(false);
            }
        }
    }

    public void medicineButton()
    {
        randomPos = Random.Range(-8f, 7f);

        Instantiate(medicinePrefabs, new Vector2(randomPos, 5f), Quaternion.identity);

        isCooldown = true;
        CDmedicine.fillAmount = 1;
        CDfeed.fillAmount = 1;
        CDmedicine.gameObject.SetActive(true);
        CDfeed.gameObject.SetActive(true);

        isMovingMedicine = true;
        isPatrolling = false;
    }

    public void feedButton()
    {
        randomPos = Random.Range(-8f, 7f);

        Instantiate(feedPrefabs, new Vector2(randomPos, 5f), Quaternion.identity);

        isCooldown = true;
        CDmedicine.fillAmount = 1;
        CDfeed.fillAmount = 1;
        CDmedicine.gameObject.SetActive(true);
        CDfeed.gameObject.SetActive(true);

        isMovingFeed = true;
        isPatrolling = false;
    }

    public void spawnIkanButton()
    {
        randomPos = Random.Range(-4f, 4f);

        Instantiate(ikanPrefabs, new Vector2(randomPos, randomPos), Quaternion.identity);
    }
}
