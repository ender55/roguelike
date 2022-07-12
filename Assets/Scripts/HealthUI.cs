using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Text heartText;

    private void OnEnable()
    {
        player.Health.OnHpChange += UpdateUI;
        player.Health.OnMaxHpChange += UpdateUI;
        player.OnDeath += DisableUi;
    }

    private void OnDisable()
    {
        player.Health.OnHpChange -= UpdateUI;
        player.Health.OnMaxHpChange -= UpdateUI;
        player.OnDeath -= DisableUi;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.Health.CurrentHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < player.Health.MaxHp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (player.Health.CurrentHp > 6)
        {
            heartText.text = "+" + (player.Health.CurrentHp - 6);
            heartText.enabled = true;
        }
        else
        {
            heartText.enabled = false;
        }
    }

    private void DisableUi()
    {
        gameObject.SetActive(false);
    }
    
}
