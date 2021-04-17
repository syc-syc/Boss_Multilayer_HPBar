using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS : MonoBehaviour
{
    //Background foreground color
    public Image background;
    public Image foreground;
    public Slider fore_g;
    public Slider healtheffect;
    //HP
    public Text CurrentHPlayer;
    // HP color
    public Color[] hpColors;
    //one layer HP
    public int singleLayerHP = 1000;
    //total hp
    public int totalHP = 3000;

    private int currentHP;
    public int CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
            ShowHPlayer();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = totalHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeHP(200);
        }
        if (healtheffect.value > fore_g.value)
        {
            healtheffect.value -= 0.003f;
        }
        else
        {
            healtheffect.value = fore_g.value;
        }
        if (CurrentHP == 0)
        {
            CurrentHPlayer.gameObject.SetActive(false);
        }
    }

    public void ChangeHP(int num)
    {
        CurrentHP -= num;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
        }
    }

    private void ShowHPlayer()
    {
        if(CurrentHP == 0)
        {
            fore_g.value = 0;
            CurrentHPlayer.text = "X 0";
            return;
        }
        //current layer HP number;
        int layerNum = CurrentHP / singleLayerHP;
        if(CurrentHP % singleLayerHP != 0)
        {
            layerNum++;
        }

        CurrentHPlayer.text = "<color=orange>" + "X " + "</color>" + "<color=orange>" + "<size=150>" + layerNum.ToString() + "</size>" + "</color>";
        

        //foreGround get
        int foregroundColorIndex = (layerNum % hpColors.Length) - 1;
        if(foregroundColorIndex == -1)
        {
            foregroundColorIndex = hpColors.Length - 1;
        }
        foreground.color = hpColors[foregroundColorIndex];

        //last layerHP
        if(layerNum == 1)
        {
            background.color = new Color(255/255f, 255/255f, 255/255f, 10/255f);
        }
        else
        {
            int backgroundColorIndex;
            if(foregroundColorIndex != 0)
            {
                backgroundColorIndex = foregroundColorIndex - 1;
            }
            else
            {
                backgroundColorIndex = hpColors.Length - 1;
            }

            background.color= hpColors[backgroundColorIndex];
        }

        float length = 1.0f * (CurrentHP % singleLayerHP) / singleLayerHP;
        if(length == 0)
        {
            length = 1;
        }
        fore_g.value = length;
    }
    
}
