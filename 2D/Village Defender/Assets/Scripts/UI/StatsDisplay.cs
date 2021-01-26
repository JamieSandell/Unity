using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    private Defender defenderPrefab = null;

    private const string CHARACTER_IMAGE_TAG = "StatsCharacterImage";
    private const string NAME_TAG = "StatsNameValue";
    private const string ATTACK_POWER_TEXT_TAG = "StatsAttackValue";
    private const string HEALTH_TEXT_TAG = "StatsHitpointsValue";
    private const string SPECIAL_ABILITY_TAG = "StatsSpecialAbilityValue";
    private const string STAR_COST_TAG = "StatsStarCostValue";

    public void SetDefender(Defender defender)
    {
        defenderPrefab = defender;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        //Find our Stats' GameObjects by tag
        GameObject characterImage, defenderName, attackPower, health, specialAbility, starCost = null;
        characterImage = GameObject.FindGameObjectWithTag(CHARACTER_IMAGE_TAG);
        defenderName = GameObject.FindGameObjectWithTag(NAME_TAG);
        attackPower = GameObject.FindGameObjectWithTag(ATTACK_POWER_TEXT_TAG);
        health = GameObject.FindGameObjectWithTag(HEALTH_TEXT_TAG);
        specialAbility = GameObject.FindGameObjectWithTag(SPECIAL_ABILITY_TAG);
        starCost = GameObject.FindGameObjectWithTag(STAR_COST_TAG);

        //Update the Stats' GameObjects with the values from the defenderPrefab
        characterImage.GetComponent<Image>().sprite = defenderPrefab.GetCharacterSprite();
        defenderName.GetComponent<Text>().text = defenderPrefab.GetName();
        attackPower.GetComponent<Text>().text = defenderPrefab.GetAttackPower().ToString();
        health.GetComponent<Text>().text = defenderPrefab.GetHealth().ToString();
        specialAbility.GetComponent<Text>().text = defenderPrefab.GetSpecialAbility();
        starCost.GetComponent<Text>().text = defenderPrefab.GetStarCost().ToString();
    }
}
