using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    [SerializeField]
    private Image bar;
    private float fill = 1f;

    void Update()
    {
        bar.fillAmount = fill;
    }

    public void minus_hp(float damage)
    {
        fill -= damage/100;
    }
}
