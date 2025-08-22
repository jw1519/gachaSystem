using Character;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
    [SerializeField] Image iconImage;
    BaseCharacter character;
    CharacterPanel characterPanel;

    public void SetCharacter(BaseCharacter character, CharacterPanel characterPanel)
    {
        iconImage.sprite = character.characterProfileSprite;
        this.characterPanel = characterPanel;
        this.character = character;
    }
    public void SelectCharacter()
    {
        characterPanel.SelectCharacter(character);
    }
}
