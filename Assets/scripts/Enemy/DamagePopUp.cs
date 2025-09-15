using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    TextMeshPro damageText;
    public static DamagePopUp Create(Vector3 position, int damageAmount)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.damagePopupPrefab, position, Quaternion.identity); 
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.SetDamageText(damageAmount);
        return damagePopUp;
    }
    private void Awake()
    {
        damageText = GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
    }
    public void SetDamageText(int amount)
    {
        damageText.text = amount.ToString();
    }
}
