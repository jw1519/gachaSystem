using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    TextMeshPro text;
    Color textColor;
    float dissapearTimer;
    public static DamagePopUp Create(Vector3 position, int damageAmount, bool iscriticalHit)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.damagePopupPrefab, position, Quaternion.identity); 
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.SetUp(damageAmount, iscriticalHit);
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
    public void SetUp(int amount, bool isCriticalHit)
    {
        text.text = amount.ToString();
        if (isCriticalHit == true)
        {
            text.fontSize = 4f;
            textColor = Color.red;
        }
        else
        {
            text.fontSize = 2.2f;
            textColor = Color.yellow;
        }
        text.color = textColor;
        dissapearTimer = 1f;
    }
}
