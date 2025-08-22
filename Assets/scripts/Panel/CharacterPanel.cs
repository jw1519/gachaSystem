using UnityEngine;
using Character;
using UnityEngine.UI;

public class CharacterPanel : BasePanel
{
    public GameObject characterProfilePrefab;
    public void AddCharacter(BaseCharacter character)
    {
        Instantiate(characterProfilePrefab);
        characterProfilePrefab.GetComponent<Image>().sprite = character.characterProfileSprite;
    }
}
