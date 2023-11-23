using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
