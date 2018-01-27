using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SelfieTeam.Selfie
{
    public class SceneAssembler : MonoBehaviour
    {
        public Player player;
        public SceneManager manager;
        

        public void Awake()
        {
            player.Init();
            manager.Init();
        }

    }
}
