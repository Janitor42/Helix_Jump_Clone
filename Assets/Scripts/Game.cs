using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Game : MonoBehaviour
{
    public int lvl=1;
    private int _lvl=1;
    public Control Control;
    public GameObject[] PlatfirmPrefab;
    public GameObject DestroyLevel;
    public GameObject DestroyLevel_Clone;
    public GameObject Players;
    public Transform Parent;
    public Text TextLvl;

    public GameObject CanvasPanelYouWin;
    public GameObject CanvasPanelYouLose;
    public GameObject CanvasGamePanel;
    public GameObject CanvasStartPanel;
    public GameObject CanvasPanelYouFinish;

    public SoundEffects SoundEffect;


    public enum State
    {
        Palying,
        WinLvl,
        Loss,
    }
    public State CurrentState;
    public void Awake()
    {       
        Inst();
    }
    public void Start()
    {
        Pause();
    }
    public void Inst()
    {
        DestroyLevel = Instantiate(PlatfirmPrefab[0], Parent);
        Control = DestroyLevel.GetComponent<Control>();
    }

    public void Pause()
    {       
        CanvasGamePanel.SetActive(false);
        CanvasStartPanel.SetActive(true);
        Control.enabled = false;
        Time.timeScale = 0;
        SoundEffect.SoundBackGroundOff();
    }
    public void ClickToPlay()
    {
        CanvasStartPanel.SetActive(false);
        CanvasGamePanel.SetActive(true);
        CurrentState = State.Palying;
        Control.enabled = true;
        Time.timeScale = 1;       
        SoundEffect.SoundBackGroundOn();

    }
    public void Finish()
    {
        CanvasGamePanel.SetActive(false);
        CanvasPanelYouWin.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()  
    {
        Destroy(DestroyLevel);
        CanvasPanelYouLose.SetActive(false);
        Players.transform.position = new Vector3(0, 1, -3.5f);
        DestroyLevel = Instantiate(PlatfirmPrefab[0], Parent);
        Control = DestroyLevel.GetComponent<Control>();
        ClickToPlay();
        SoundEffect.SoundYouDeathOff();
    }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Palying) return;
        CurrentState = State.Loss;
        Control.enabled = false;
    }
    public void OnPlayerPause()
    {
        CurrentState = State.Loss;
        YouLose();
        Control.enabled = false;
    }
    public void OnPlayerFinish()
    {
        
        if (CurrentState!=State.Palying) return;
        CanvasGamePanel.SetActive(true);
        CanvasPanelYouWin.SetActive(false);
        Control.enabled = true;
        Time.timeScale = 1;
        _lvl++;
        lvl=_lvl;
        TextLvl.text = lvl.ToString();
        Control.enabled = false;
        NextLvl();
        CurrentState = State.Palying;
        SoundEffect.SoundYouWinOff();

    }
    public void YouWin()
    {
        CanvasGamePanel.SetActive(false);
        CanvasPanelYouWin.SetActive(true);
        Control.enabled = false;
        Time.timeScale = 0;
        SoundEffect.SoundBackGroundOff();
        SoundEffect.SoundYouWin();
    }    
    public void YouLose()
    {   
        StartCoroutine(YouLose_corotine());
    }    
    public void YouFinish()
    {
        CanvasPanelYouFinish.SetActive(true);
        CanvasPanelYouWin.SetActive(false);
        CanvasGamePanel.SetActive(false);
        Control.enabled = false;
        Time.timeScale = 0;
    }
    public void NextLvl()
    {
        SoundEffect.SoundBackGroundOn();
        Destroy(DestroyLevel);
        DestroyLevel = Instantiate(PlatfirmPrefab[1],Parent);
        Control = DestroyLevel.GetComponent<Control>();
        PlatfirmPrefab = PlatfirmPrefab.Skip(1).ToArray();
        Players.transform.position =new Vector3(0, 1, -3.5f);
        if (lvl==6)
        {
            YouFinish();
        }
    }
        IEnumerator YouLose_corotine()
    {
        SoundEffect.SoundBackGroundOff();
        SoundEffect.SoundYouDeath();
        yield return new WaitForSeconds(2f);
        CanvasPanelYouLose.SetActive(true);
        CanvasGamePanel.SetActive(false);

    }
}
