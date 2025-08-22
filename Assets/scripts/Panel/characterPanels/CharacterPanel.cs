using UnityEngine;
using Character;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CharacterPanel : BasePanel
{
    public List<BaseCharacter> characterList;
    public GameObject characterProfilePrefab;
    public GameObject CharacterInfoPanel;
    public Transform iconParent;
    [Header("text")]
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI characterStatsText;

    public BaseCharacter character;
    private void Awake()
    {
        AddCharacter(character);
    }
    public void AddCharacter(BaseCharacter character)
    {
        GameObject instance = Instantiate(characterProfilePrefab);
        instance.GetComponent<CharacterSelectButton>().SetCharacter(character, this);
        instance.transform.SetParent(iconParent);
        characterList.Add(character);
    }
    public void SelectCharacter(BaseCharacter character)
    {
        characterNameText.text = character.characterName;
        CharacterInfoPanel.SetActive(true);
    }
}
