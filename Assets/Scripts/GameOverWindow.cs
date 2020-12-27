using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;
    private void Awake()
    {
        instance = this;
        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        };
        hide();
    }
    private void show()
    {
        gameObject.SetActive(true);
    }

    private void hide()
    {
        gameObject.SetActive(false);
    }

    public static void showStatic()
    {
        instance.show();
    }
}
