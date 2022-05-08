using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina = 100f;
    public float currentStamina;

    public static StaminaBar instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public bool thereIsStamina;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if(currentStamina > 0)
        {
            thereIsStamina = true;

            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(currentStamina < 0)
            {
                thereIsStamina = false;

                currentStamina = 0;
                staminaBar.value = 0.1f;
            }

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            thereIsStamina = false;

            currentStamina = 0;
            staminaBar.value = 0.1f;


            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);
        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100f;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        if(currentStamina > 100)
        {
            currentStamina = 100;
        }
        regen = null;
    }

}
