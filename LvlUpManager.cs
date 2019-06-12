using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson {
    public class LvlUpManager : MonoBehaviour {

        public CharacterStats playerstats;
        public LevelProgression levelProgression;
        public SoundManager soundmanager;

        private void Start()
        {
            playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
            levelProgression = GameObject.FindGameObjectWithTag("StartManager").GetComponent<LevelProgression>();
            soundmanager = GameObject.FindGameObjectWithTag("SoundFXManager").GetComponent<SoundManager>();
        }

        public void MaxHealthUp()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints > 0)
            {
                int buffAmount;
              
                
                  

                

                
                
                    buffAmount = 100;
                playerstats.AddMaxHealth(buffAmount);


                
                playerstats.LevelUp();
                playerstats.lvlUpPoints--;
                Done();
            }
        }
        

        public void StrengthUp()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints > 0)
            {
                CharacterStats.StrengthStat++;
                playerstats.lvlUpPoints--;
                playerstats.LevelUp();
            }
        }

        public void StrengthDown()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints == 0)
            {
                CharacterStats.StrengthStat--;
                playerstats.lvlUpPoints++;
                playerstats.LevelUp();
            }
        }

        public void SpeedUp()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints > 0)
            {
                playerstats.addonetoSpeed = true;
                CharacterStats.SpeedStat++;
                playerstats.lvlUpPoints--;
                playerstats.LevelUp();
            }
        }
        public void SpeedDown()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints == 0)
            {
                playerstats.addonetoSpeed = false;
                CharacterStats.SpeedStat--;
                playerstats.lvlUpPoints++;
                playerstats.LevelUp();
            }
        }
        public void JumpUp()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints > 0)
            {
                playerstats.addonetoJump = true;
                CharacterStats.JumpStat++;
                playerstats.lvlUpPoints--;
                playerstats.LevelUp();
            }
        }
        public void JumpDown()
        {
            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints == 0)
            {
                playerstats.addonetoJump = false;
                CharacterStats.JumpStat--;
                playerstats.lvlUpPoints++;
                playerstats.LevelUp();
            }
        }
        public void Done()
        {

            soundmanager.PlayMenuSound();
            if (playerstats.lvlUpPoints == 0)
            {
                ItemInventory.unavailable = false;
                TimeStop.unavailable = false;
                StartScreen.unavailable = false;
                WeaponInventory.unavailable = false;
                playerstats.AddLevel();
                levelProgression.LvlUpScreenOff();
            }
        }

    }
}
