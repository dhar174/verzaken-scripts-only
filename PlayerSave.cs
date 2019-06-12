using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerSave : MonoBehaviour {

	public static void SavePlayer(CharacterStats player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/savegame.sav", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        print("Successfully saved");
        stream.Close();
    }
    public static int[] LoadPlayer()
    {
        //print("Pooper scooper");
        if(File.Exists(Application.persistentDataPath + "/savegame.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/savegame.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            print("Loaded From Save");
            stream.Close();
            return data.stats;
            
        }
        else
        {
            print("File does not exist");
            //return new int[43];
            GameObject.Find("BtnManager").GetComponent<BtnManager>().NewGame();
            return null;
        }
    }
    public static void DeletePlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame.sav"))
        {
            File.Delete(Application.persistentDataPath + "/savegame.sav");
        }
    }
}
[Serializable]
public class PlayerData
{
    public int[] stats;

    public PlayerData(CharacterStats player)
    {
        stats = new int[43];
        stats[0] = player.playerLevelCheck;
        stats[1] = player.baseHealthCheck;
        stats[2] = player.strengthcheck;
        stats[3] = player.speedcheck;
        stats[4] = player.jumpcheck;
        stats[5] = player.playerXP;
        stats[6] = player.levelMultiplier+=1;
        stats[7] = player.weapon1Type;
        stats[8] = player.weapon2Type;
        stats[9] = player.weapon1powerSave;
        stats[10] = player.weapon2powerSave;
        stats[11] = player.weapon1Mat;
        stats[12] = player.weapon2Mat;
        stats[13] = player.itemInvBool1;
        stats[14] = player.itemInvBool2;
        stats[15] = player.itemInvBool3;
        stats[16] = player.itemInvBool4;
        stats[17] = player.itemInvBool5;
        stats[18] = player.itemInvBool6;
        stats[19] = player.itemInvBool7;
        stats[20] = player.itemInvBool8;
        stats[21] = player.itemInvBool9;
        stats[22] = player.itemInvBool10;
        stats[23] = player.itemInvBool11;
        stats[24] = player.itemInvBool12;
        stats[25] = player.itemInvBool13;
        stats[26] = player.itemInvBool14;
        stats[27] = player.itemInvBool15;
        stats[28] = player.itemInvBool16;
        stats[29] = player.itemInvBool17;
        stats[30] = player.itemInvBool18;
        stats[31] = player.itemInvBool19;
        stats[32] = player.itemInvBool20;
        stats[33] = player.itemInvBool21;
        stats[34] = player.firstgameint;
        stats[35] = player.firstboxint;
        stats[36] = player.firstenemyint;
        stats[37] = player.firstpickaxeint;
        stats[38] = player.firstmineint;
        stats[39] = player.firstweaponfoundint;
        stats[40] = player.firstartifactint;
        stats[41] = player.firstteleportint;
        stats[42] = player.secondlevelpopupint;







    }
}
