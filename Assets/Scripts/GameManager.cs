using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Transform startTransform;
    public Player player;

    public bool gameOver;

    private void Awake()
    {
        GetInstance();
    }

    private void GetInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        player.gameObject.SetActive(false);
        startPanel.gameObject.SetActive(true);
    }

    public void GameStart()
    {
        player.gameObject.SetActive(true);
        player.rideAnimal.transform.localPosition = startTransform.position;
        player.rideAnimal.Ride(player);
        startPanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(false);

    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        startPanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(true);
    }
}
