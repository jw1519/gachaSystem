using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Character;
using Enemy;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    public Button endTurnButton;

    public List<GameObject> combatOrder;
    public int currentCombatIndex = 0;

    BasePanel gameWonPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        gameWonPanel = UIManager.instance.panels.Find(panel => panel.name == "GameWonPanel");
    }
    public void AddToCombat(GameObject character)
    {
        combatOrder.Add(character);
    }

    public IEnumerator StartCombat()
    {

        yield return new WaitForSeconds(1f);

        if (combatOrder[currentCombatIndex] != null)
        {
            GameObject Target = combatOrder[currentCombatIndex];
            if (Target.GetComponent<SetEnemy>() != null)
            {
                EnemyTurn(Target);
            }
            else
            {
                PlayerTurn(Target);
            }
            currentCombatIndex = (currentCombatIndex + 1) % combatOrder.Count; // moves to the next in the list and wraps around

        }
        else
        {
            Debug.Log("current combat index is null");
        }
    }
    public void PlayerTurn(GameObject player)
    {
        BaseCharacter character = player.GetComponent<BaseCharacter>();
        character.energy = character.maxEnergy;

        endTurnButton.GetComponentInChildren<TextMeshProUGUI>().text = "End Turn";
        endTurnButton.enabled = true;
    }
    public void EnemyTurn(GameObject enemy)
    {
        if (enemy.GetComponent<SetEnemy>().enemy.isAlive != false)
        {
            endTurnButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enemy Turn";
            endTurnButton.enabled = false;
            //enemy.GetComponent<EnemyCombat>().StartTurn();
        }
    }
    public void RemoveFromCombat(GameObject enemy)
    {
        combatOrder.Remove(enemy.gameObject);
        //check combat status
        bool isenemyAlive = EnemiesAlive();
        if (isenemyAlive == false)
        {
            gameWonPanel.OpenPanel();
        }
    }
    public bool EnemiesAlive()
    {
        foreach (GameObject gameObject in combatOrder)
        {
            if (gameObject.GetComponent<SetEnemy>() != null)
            {
                return true;
            }
        }
        return false;
    }
}
