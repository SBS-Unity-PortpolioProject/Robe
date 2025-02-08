using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get 
        {
            if (!_instance)
            {
                GameObject obj = new GameObject("GameManager",typeof(GameManager));
                _instance = obj.GetComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public int FinalHealth;

    public int CurrentHealth = 100;


    public float ClearTime;

    public float FailTime;
}
