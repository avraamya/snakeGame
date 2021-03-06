﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    private static int score;
    [SerializeField] private Snake snake;
    private LevelGrid levelGrid;


    private void Awake()
    {
        instance = this;
        InitializeStatic();
    }
    void Start()
    {
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(21, 21);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);

//        CMDebug.ButtonUI(Vector2.zero, "Reload Scene" , () => {
  //          Loader.Load(Loader.Scene.GameScene);
    //    });
    }

    public static void InitializeStatic()
    {
        score = 0;
    }
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;
    }

    public static void SnakeDied()
    {
        GameOverWindow.showStatic();
    }
}
