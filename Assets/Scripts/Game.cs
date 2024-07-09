using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour {

    enum GAME_STATUS
    {
        Ready,
        InGame,
        GameOver
    }

    private GAME_STATUS status;
    public PipelineManager pipelineManager;
    private int score;
    public Text uiScore;
    public Text uiResultScore;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            this.score = value;
            this.uiScore.text = value.ToString();
            this.uiResultScore.text = value.ToString();
        }
    }
    private GAME_STATUS Status
    {
        get
        {
            return status;
        }

        set
        {
            status = value;
            UpdateUI();
        }
    }
    public GameObject panelReady;
    public GameObject panelInGame;
    public GameObject panelGameOver;
    public Player player;
    // Use this for initialization
    void Start ()
    {
        this.Status = GAME_STATUS.Ready;
        this.player.OnDeath += Player_OnDeath;
        this.player.OnScore += OnPlayerScore;
	}

    void OnPlayerScore(int score)
    {
        this.Score += score;
    }

	private void Player_OnDeath()
    {
        this.Status = GAME_STATUS.GameOver;
        this.pipelineManager.Stop();
    }

    public void StartGame()
    {
        this.Status = GAME_STATUS.InGame;
        pipelineManager.StartRun();
        player.Fly();
        Debug.LogFormat("StartGame:{0}",this.Status);
    }

    public void UpdateUI()
    {
        this.panelReady.SetActive(this.Status == GAME_STATUS.Ready);
        this.panelInGame.SetActive(this.Status == GAME_STATUS.InGame);
        this.panelGameOver.SetActive(this.Status == GAME_STATUS.GameOver);
    }
    public void Restart()
    {
        this.Status = GAME_STATUS.Ready;
        this.pipelineManager.Init();
        this.player.Init();
        this.Score = 0;
    }
}
