using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private Level[] level;
    private int currentLevel;
    private GameObject currentLevelGameObject;

    private void Awake()
    {
        currentLevel = 0;
        ChangeLevel();
    }
    private void ChangeLevel() 
    {
        if (currentLevelGameObject) 
        {
            Destroy(currentLevelGameObject);
        }
        currentLevelGameObject = Instantiate(level[currentLevel].gameObject, Vector3.zero, Quaternion.Euler(0f, 0f, 0f));
    }
    public void NextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("level", currentLevel);
        ChangeLevel();
        GameCycle.instance.statement = GameCycle.Statement.Waiting;
        Player.player.SetStartPosition();
        UIManager.instance.textWinTimer.gameObject.SetActive(false);
        UIManager.instance.animatorPanelWin.SetTrigger("Hide");
        UIManager.instance.animatorPanelStartScreen.SetTrigger("Show");
        UIManager.instance.textLevel.text = "LEVEL\n<size=175>" + (currentLevel+1) + "</size>";
    }
}
