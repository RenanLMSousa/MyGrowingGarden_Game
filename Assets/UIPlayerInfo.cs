using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerInfo : MonoBehaviour
{
    public Player player;

    public TMP_Text txtPlayerMoney;
    public TMP_Text txtPlayerName;
    // Start is called before the first frame update

    void Update()
    {
        this.txtPlayerMoney.text = player.GetMoney().ToString();
        this.txtPlayerName.text = player.playerName;
    }
}
