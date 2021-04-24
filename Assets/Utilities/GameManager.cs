using UnityEngine;

public class GameManager : Singleton<GameManager>
{
#pragma warning disable 0649
    [SerializeField]
    private MonsterManager monsterManager;
#pragma warning restore 0649
    public Player CurrentPlayer { get; private set; }
    public MonsterManager MonsterManager => monsterManager;
    public PlayerPreferences PlayerPreferences { get; private set; }    
    public Catching Catching { get; private set; }
    public AbilitiesContainer AbilitiesContainer { get; private set; }    
    //Verifica se o tipo Player não está a null como método de prevenção, caso este seja, então é necessário interligar via Unity o componente.
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        PlayerPreferences = new PlayerPreferences();
        Catching = new Catching();
        CurrentPlayer = new Player();
        AbilitiesContainer = new AbilitiesContainer(CurrentPlayer.Abilities);          
    }

}
