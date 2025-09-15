using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    TextMeshPro text;
    Color textColor;
    float dissapearTimer;
    public static DamagePopUp Create(Vector3 position, int damageAmount)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.damagePopupPrefab, position, Quaternion.identity); 
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.SetUp(damageAmount);
        return damagePopUp;
    }
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        dissapearTimer -= Time.deltaTime;
        if (dissapearTimer < 0)
        {
            float dissapearSpeed = 3f;
            textColor.a -= dissapearSpeed * Time.deltaTime;
            text.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetUp(int amount)
    {
        text.text = amount.ToString();
        textColor = text.color;
        dissapearTimer = 1f;
    }
}
