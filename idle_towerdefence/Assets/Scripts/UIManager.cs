using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyBarTxt;
    public TextMeshProUGUI attackBarTxt;
    public TextMeshProUGUI healthBarTxt;
    public TextMeshProUGUI defenceBarTxt;
    public TextMeshProUGUI currentWaveTxt;
    public Image currentWaveImg;
    public float currentWaveImgBaseWidth;

    private void Start()
    {
        currentWaveImgBaseWidth = currentWaveImg.rectTransform.sizeDelta.x;
        attackBarTxt.text = ChangeNumber((int)GeneralManager.instance.gameData.moAttack);
        defenceBarTxt.text = "%" + ChangeNumber((int)GeneralManager.instance.gameData.moDefenceUpgradedLevel);
        healthBarTxt.text = ChangeNumber((int)GeneralManager.instance.gameData.moHealth);
        currentWaveTxt.text = "Wave " + GeneralManager.instance.gameData.currentWave;
    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            GeneralManager.instance.gameData.money += 10000;
        }
        moneyBarTxt.text = "$" + ChangeNumber(GeneralManager.instance.gameData.money);
        currentWaveImg.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(currentWaveImg.rectTransform.sizeDelta.x, currentWaveImgBaseWidth * ((float)EnemyManager.instance.currentEnemyKills / (float)EnemyManager.instance.howManyEnemiesGonnaSpawn),0.2f),currentWaveImg.rectTransform.sizeDelta.y);
        currentWaveTxt.text = "Wave " + GeneralManager.instance.gameData.currentWave;
    }

    public void HealtUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        float currentCost = GeneralManager.instance.healthParameters.baseCost * Mathf.Pow(GeneralManager.instance.healthParameters.growthRate, GeneralManager.instance.gameData.moHealthUpgradedLevel+1);
        if(GeneralManager.instance.gameData.money >= currentCost)
        {
            GeneralManager.instance.gameData.moHealthUpgradedLevel += 1;
            GeneralManager.instance.gameData.moHealth = GeneralManager.instance.healthParameters.baseCost * Mathf.Pow(GeneralManager.instance.healthParameters.growthRateForItself, GeneralManager.instance.gameData.moHealthUpgradedLevel);
            healthBarTxt.text = ChangeNumber((int)GeneralManager.instance.gameData.moHealth);
            float nextCost = GeneralManager.instance.healthParameters.baseCost * Mathf.Pow(GeneralManager.instance.healthParameters.growthRate, GeneralManager.instance.gameData.moHealthUpgradedLevel + 1);
            float upgradedValue = GeneralManager.instance.healthParameters.baseCost * Mathf.Pow(GeneralManager.instance.healthParameters.growthRateForItself, GeneralManager.instance.gameData.moHealthUpgradedLevel + 1);
            btn.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)upgradedValue);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
            GeneralManager.instance.gameData.money -= (int)currentCost;
        }

    }

    public void AttackUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        float currentCost = GeneralManager.instance.attackParameters.baseCost * Mathf.Pow(GeneralManager.instance.attackParameters.growthRate, GeneralManager.instance.gameData.moAttackUpgradedLevel + 1);
        if(GeneralManager.instance.gameData.money >= currentCost)
        {
            GeneralManager.instance.gameData.moAttackUpgradedLevel += 1;
            GeneralManager.instance.gameData.moAttack = GeneralManager.instance.attackParameters.baseCost * Mathf.Pow(GeneralManager.instance.attackParameters.growthRateForItself, GeneralManager.instance.gameData.moAttackUpgradedLevel);
            attackBarTxt.text = ChangeNumber((int)GeneralManager.instance.gameData.moAttack);
            float nextCost = GeneralManager.instance.attackParameters.baseCost * Mathf.Pow(GeneralManager.instance.attackParameters.growthRate, GeneralManager.instance.gameData.moAttackUpgradedLevel + 1);
            float upgradedValue = GeneralManager.instance.attackParameters.baseCost * Mathf.Pow(GeneralManager.instance.attackParameters.growthRateForItself, GeneralManager.instance.gameData.moAttackUpgradedLevel + 1);
            btn.transform.parent.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)upgradedValue);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
            GeneralManager.instance.gameData.money -= (int)currentCost;
        }
    }

    public void AutoAttackSpeedUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        GeneralManager.instance.gameData.moBaseAttackSpeed -= 0.05f;
        float nextCost = GeneralManager.instance.moAttackSpeedParameters.baseCost * Mathf.Pow(GeneralManager.instance.moAttackSpeedParameters.growthRate , (2 - GeneralManager.instance.gameData.moBaseAttackSpeed) * 20);
        btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
    }

    public void HealthRegenUpgrade()
    {

    }

    public void DefenceUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        float nextCost = GeneralManager.instance.defenceParameters.baseCost * Mathf.Pow(GeneralManager.instance.defenceParameters.growthRate, GeneralManager.instance.gameData.moDefenceUpgradedLevel);
        GeneralManager.instance.gameData.moDefenceUpgradedLevel += 1;
        defenceBarTxt.text = "%" + ChangeNumber((int)GeneralManager.instance.gameData.moDefenceUpgradedLevel);
        GeneralManager.instance.gameData.moDefence = nextCost;
        btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
    }

    public void SpikeExplosionCountUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        GeneralManager.instance.gameData.seCountLevel++;
        float nextCost = GeneralManager.instance.seCountParameters.baseCost * Mathf.Pow(GeneralManager.instance.seCountParameters.growthRate, GeneralManager.instance.seCount[GeneralManager.instance.gameData.seCountLevel+1]);
        btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
        GeneralManager.instance.spikeExplosion.GetComponent<SpikeExplosion>().SetSpikeExplosion();

    }
    public void SpikeExplosionAttackSpeedUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        GeneralManager.instance.gameData.seExplosionTimeLevel++;
        float nextCost = GeneralManager.instance.seAttackSpeedParameters.baseCost * Mathf.Pow(GeneralManager.instance.seAttackSpeedParameters.growthRate, GeneralManager.instance.gameData.seExplosionTimeLevel + 1);
        btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
        GeneralManager.instance.spikeExplosion.GetComponent<SpikeExplosion>().SetSpikeExplosion();
    }

    public void TriangleTurretCountUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        if (GeneralManager.instance.gameData.ttCountLevel + 1 < GeneralManager.instance.ttCount.Length-1)
        {
            GeneralManager.instance.gameData.ttCountLevel++;
            float nextCost = GeneralManager.instance.ttCountParameters.baseCost * Mathf.Pow(GeneralManager.instance.ttCountParameters.growthRate, GeneralManager.instance.ttCount[GeneralManager.instance.gameData.ttCountLevel + 1]);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
            GeneralManager.instance.TriangleTurret.GetComponent<RotatingTurret>().SetRotatingTurrets();
        }
        if(GeneralManager.instance.gameData.ttCountLevel == GeneralManager.instance.ttCount.Length - 2)
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
            btn.GetComponent<Button>().interactable = false;
        }
    }

    public void TriangleTurretRotateSpeed()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        GeneralManager.instance.gameData.seExplosionTimeLevel++;
        float nextCost = GeneralManager.instance.seAttackSpeedParameters.baseCost * Mathf.Pow(GeneralManager.instance.seAttackSpeedParameters.growthRate, GeneralManager.instance.gameData.seExplosionTimeLevel + 1);
        btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
        GeneralManager.instance.spikeExplosion.GetComponent<SpikeExplosion>().SetSpikeExplosion();
    }

    public void OrbCountUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        if(GeneralManager.instance.gameData.tcCountLevel +1 < GeneralManager.instance.ttCount.Length-1)
        {
            GeneralManager.instance.gameData.tcCountLevel++;
            float nextCost = GeneralManager.instance.tcCountParameters.baseCost * Mathf.Pow(GeneralManager.instance.tcCountParameters.growthRate, GeneralManager.instance.tcCount[GeneralManager.instance.gameData.tcCountLevel + 1]);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
            GeneralManager.instance.turningCircles.GetComponent<RotatingTurret>().SetRotatingTurrets();
        }
        if (GeneralManager.instance.gameData.tcCountLevel == GeneralManager.instance.tcCount.Length - 2)
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
            btn.GetComponent<Button>().interactable = false;
        }
    }

    public void OrbRotateSpeedUpgrade()
    {

    }

    public void OrbRespawnTimeUpgrade()
    {

    }

    public void xrayCountUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        if (GeneralManager.instance.gameData.xrayCountLevel + 1 < GeneralManager.instance.xrayCount.Length - 1)
        {
            GeneralManager.instance.gameData.xrayCountLevel++;
            float nextCost = GeneralManager.instance.xrayCountParameters.baseCost * Mathf.Pow(GeneralManager.instance.xrayCountParameters.growthRate, GeneralManager.instance.xrayCount[GeneralManager.instance.gameData.xrayCountLevel + 1]);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
            GeneralManager.instance.XrayTurret.GetComponent<RotatingTurret>().SetRotatingTurrets();
        }
        if (GeneralManager.instance.gameData.xrayCountLevel == GeneralManager.instance.xrayCount.Length - 2)
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
            btn.GetComponent<Button>().interactable = false;
        }
    }

    public void xrayRotateSpeedUpgrade()
    {

    }

    public void TurningSpikeAttackSpeedUpgrade()
    {

    }

    public void TurningSpikeGraphUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        if (GeneralManager.instance.gameData.stGraphParameterLevel + 1 < GeneralManager.instance.stGraphParameter.Length - 1)
        {
            GeneralManager.instance.gameData.stGraphParameterLevel++;
            float nextCost = GeneralManager.instance.stGraphParameters.baseCost * Mathf.Pow(GeneralManager.instance.stGraphParameters.growthRate, GeneralManager.instance.stGraphParameter[GeneralManager.instance.gameData.stGraphParameterLevel + 1]);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
        }
        if (GeneralManager.instance.gameData.stGraphParameterLevel == GeneralManager.instance.stGraphParameter.Length - 2)
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
            btn.GetComponent<Button>().interactable = false;
        }
    }

    public void TurretCountUpgrade()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        if (GeneralManager.instance.gameData.ntCountLevel + 1 < GeneralManager.instance.ntCount.Length - 1)
        {
            GeneralManager.instance.gameData.ntCountLevel++;
            float nextCost = GeneralManager.instance.ntCountParameters.baseCost * Mathf.Pow(GeneralManager.instance.ntCountParameters.growthRate, GeneralManager.instance.ntCount[GeneralManager.instance.gameData.ntCountLevel + 1]);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ChangeNumber((decimal)nextCost) + "$";
            GeneralManager.instance.turrets.GetComponent<TurretManager>().SpawnTurrets();
        }
        if (GeneralManager.instance.gameData.ntCountLevel == GeneralManager.instance.ntCount.Length - 2)
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
            btn.GetComponent<Button>().interactable = false;
        }
    }

    public void TurretAttackSpeedUpgrade()
    {

    }

    public void TurretRotateSpeedUpgrade()
    {

    }
    public string ChangeNumber(decimal amount)
    {
        string value = "";
        if(amount < 1000)
            value = Math.Round(amount, 0).ToString();
        else if(amount >= 1000 && amount < 1000000)
            value = Math.Round(amount / 1000, 1).ToString() + "K";
        else if(amount >= 1000000 && amount < 1000000000)
            value = Math.Round(amount / 1000000, 2).ToString() + "M";
        else if (amount >= 1000000000 && amount < 1000000000000)
        {
            value = Math.Round(amount / 1000000000, 2).ToString() + "B";
        }
        else
        {
            value = Math.Round(amount / 1000000000000, 2).ToString() + "T";
        }
        return value;
    }

}
