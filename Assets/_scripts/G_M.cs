using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { NullState, Intro, MainMenu, Game }
public delegate void OnStateChangeHandler();


public class G_M : MonoBehaviour // Unity class in case update() is needed 
{
    protected G_M() {}
    private static G_M _instance = null;
    public static int ballsGathered = 0;

#region Global Variables
    public GameState gameState { get; private set; }
#endregion

#region Global Methods / Events
public event OnStateChangeHandler OnStateChange;
#endregion

    // Singleton pattern implementation
    public static G_M ptr {
        get {
            if (G_M._instance == null) {
                G_M._instance = new G_M();
            }  
            return G_M.ptr;
        }
    }
    
    public void SetGameState(GameState gameState) {
        this.gameState = gameState;
        if(OnStateChange!=null) {
            OnStateChange();
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        // if needed
    }

    void Update()
    {
        // if needed
    }
}