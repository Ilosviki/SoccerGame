using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class SoccerEnvController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInfo
    {
        public AgentSoccer Agent;
        [HideInInspector]
        public Vector3 StartingPos;
        [HideInInspector]
        public Quaternion StartingRot;
        [HideInInspector]
        public Rigidbody Rb;
    }


    /// <summary>
    /// Max Academy steps before this platform resets
    /// </summary>
    /// <returns></returns>
    [Tooltip("Max Environment Steps")] public int MaxEnvironmentSteps = 25000;

    /// <summary>
    /// The area bounds.
    /// </summary>

    /// <summary>
    /// We will be changing the ground material based on success/failue
    /// </summary>

    public GameObject ball;
    [HideInInspector]
    public Rigidbody ballRb;
    Vector3 m_BallStartingPos;

    //Player on the Grid
    public GameObject player;
    Vector3 m_PlayerStartingPos;
    Quaternion m_PlayerStartingRot;

    //List of Agents On Platform
    public List<PlayerInfo> AgentsList = new List<PlayerInfo>();

    private SoccerSettings m_SoccerSettings;

    private SimpleMultiAgentGroup m_BlueAgentGroup;
    private SimpleMultiAgentGroup m_PurpleAgentGroup;

    private int m_ResetTimer;

    private int playerScore = 0;
    private int agentScore = 0;

    private bool isStart = true;

    void Start()
    {

        m_SoccerSettings = FindObjectOfType<SoccerSettings>();
        // Initialize TeamManager
        m_BlueAgentGroup = new SimpleMultiAgentGroup();
        m_PurpleAgentGroup = new SimpleMultiAgentGroup();
        ballRb = ball.GetComponent<Rigidbody>();
        m_BallStartingPos = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        m_PlayerStartingPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        m_PlayerStartingRot = player.transform.rotation;
        foreach (var item in AgentsList)
        {
            item.StartingPos = item.Agent.transform.position;
            item.StartingRot = item.Agent.transform.rotation;
            item.Rb = item.Agent.GetComponent<Rigidbody>();
            if (item.Agent.team == Team.Blue)
            {
                m_BlueAgentGroup.RegisterAgent(item.Agent);
            }
            else
            {
                m_PurpleAgentGroup.RegisterAgent(item.Agent);
            }
        }
        ResetScene();
        isStart = false;
    }

    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            m_BlueAgentGroup.GroupEpisodeInterrupted();
            m_PurpleAgentGroup.GroupEpisodeInterrupted();
            ResetScene();
        }
    }


    public void ResetBall()
    {
        ball.transform.position = m_BallStartingPos;
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }

    public void GoalTouched(Team scoredTeam)
    {
        if (scoredTeam == Team.Blue)
        {
            m_BlueAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_PurpleAgentGroup.AddGroupReward(-1);
            playerScore++;
        }
        else
        {
            m_PurpleAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_BlueAgentGroup.AddGroupReward(-1);
            agentScore++;
        }
        m_PurpleAgentGroup.EndGroupEpisode();
        m_BlueAgentGroup.EndGroupEpisode();
        Score.instance.ScoreChanging(playerScore, agentScore);
        ResetScene();
    }

    public void ResetScene()
    {
        m_ResetTimer = 0;

        //Reset Player
        player.transform.SetPositionAndRotation(m_PlayerStartingPos, m_PlayerStartingRot);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //Reset Agents
        foreach (var item in AgentsList)
        {
            item.Agent.transform.SetPositionAndRotation(item.StartingPos, item.StartingRot);
            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
        }

        //Reset Ball
        ResetBall();

        //Reset Canvas
        if(!isStart)
            Countdown.instance.Counting();
        else
            isStart = false;
    }
}
