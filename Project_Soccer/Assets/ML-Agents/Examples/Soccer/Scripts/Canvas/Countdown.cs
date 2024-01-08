using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private int startingTime = 4;
    private GameObject player;
    private GameObject playerCamera;
    private GameObject agent;

    [SerializeField] GameObject threeImage;
    [SerializeField] GameObject twoImage;
    [SerializeField] GameObject oneImage;
    [SerializeField] GameObject goImage;

    [SerializeField] List<GameObject> PlusAgentsList = new List<GameObject>();

    public static Countdown instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        agent = GameObject.Find("PurpleStriker");
        player = GameObject.Find("BlueStriker");
        playerCamera = GameObject.Find("PlayerCamera");
        if(player == null)
            PlusAgentsList.Add(GameObject.Find("BlueAgent"));
        Counting();
    }

    public void Counting()
    {
        agent.GetComponent<AgentSoccer>().enabled = false;
        if (player != null)
        {
            player.GetComponent<MoveCharacter>().enabled = false;
            player.GetComponent<SphereCollider>().enabled = false;
            player.GetComponent<BoxCollider>().enabled = false;
            playerCamera.GetComponent<LookAround>().enabled = false;
        }
        else 
        foreach (var item in PlusAgentsList)
            item.GetComponent<AgentSoccer>().enabled = false;
        StartCoroutine(CountingDown(startingTime));
    }

    private IEnumerator CountingDown(int currentTime)
    {
        while (currentTime >= 0)
        {
            switch (currentTime)
            {
                case 4:
                    threeImage.SetActive(true);
                    break;
                case 3:
                    twoImage.SetActive(true);
                    threeImage.SetActive(false);
                    break;
                case 2:
                    oneImage.SetActive(true);
                    twoImage.SetActive(false);
                    break;
                case 1:
                    goImage.SetActive(true);
                    oneImage.SetActive(false);
                    agent.GetComponent<AgentSoccer>().enabled = true;
                    if (player != null)
                    {
                        player.GetComponent<MoveCharacter>().enabled = true;
                        player.GetComponent<SphereCollider>().enabled = true;
                        player.GetComponent<BoxCollider>().enabled = true;
                        playerCamera.GetComponent<LookAround>().enabled = true;
                    }
                    foreach (var item in PlusAgentsList)
                        item.GetComponent<AgentSoccer>().enabled = true;
                    break;
                case 0:
                    goImage.SetActive(false);
                    break;
            }
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
    }
}
