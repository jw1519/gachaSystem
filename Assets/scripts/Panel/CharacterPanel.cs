using UnityEngine;
using Character;
using UnityEngine.UIElements;

public class CharacterPanel : BasePanel
{
    public GameObject characterProfilePrefab;
    public void AddCharacter(BaseCharacter character)
    {
        Instantiate(characterProfilePrefab);
        characterProfilePrefab.GetComponent<Image>().sprite = character.characterProfileSprite;
    }
}
