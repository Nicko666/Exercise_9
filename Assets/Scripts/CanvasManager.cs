using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public Player player;
    public PlayerUI playerUI;
    public Transform start;
    public GameObject startMenu;
    public Text message;
    public GameObject WinMenu;

    private void OnEnable()
    {
        Player.PlayerIsCreated += PlayerCreated;
        Player.PlayerIsDamaged += PlayerIsDamaged;
        Player.PlayerIsDead += PlayerIsDead;
        Player.PlayerWin += PlayerWin;
    }

    private void OnDisable()
    {
        Player.PlayerIsCreated -= PlayerCreated;
        Player.PlayerIsDamaged -= PlayerIsDamaged;
        Player.PlayerIsDead -= PlayerIsDead;
        Player.PlayerWin -= PlayerWin;
    }

    public void Start()
    {
        message.text = "";
        startMenu.SetActive(true);
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Instantiate(player.gameObject, start, true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerCreated(Player player)
    {
        playerUI.player = player;
        playerUI.gameObject.SetActive(true);
    }

    public void PlayerIsDamaged(int damage)
    {
        playerUI.Damage(damage);
    }

    public void PlayerIsDead()
    {
        playerUI.gameObject.SetActive(false);
        message.text = "You lose";
        startMenu.SetActive(true);
    }

    public void PlayerWin(GameObject player)
    {
        message.text = "You Win!";
        playerUI.gameObject.SetActive(false);
        WinMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
