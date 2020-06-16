using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class PlayerData
    {
        private List<ItemData> inventory;
        private float Lucht = 100;
        private int Health = 3;

        public PlayerData()
        {
            inventory = new List<ItemData>();
        }
        
        public List<ItemData> getinventory()
        {
            return this.inventory;
        }

        public void TakeDamage(int value)
        {
            this.Health -= value;

            if (Health == 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        public void AddHealth(int value)
        {
            this.Health += value;
        }

        public int getHealth()
        {
            return this.Health;
        }

        public float lucht
        {
            get { return Lucht; }
            set
            {
                if (lucht >= 0)
                {
                    Lucht = value;
                }
                GameObject.Find("Air_slider").GetComponent<Slider>().value = (float) lucht / 100;
            }
        }
    }
}