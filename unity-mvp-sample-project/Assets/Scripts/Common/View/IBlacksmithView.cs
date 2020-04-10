using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.View
{
    public interface IBlacksmithView
    {
        void SetLives(int lives);

        void PlayAnimation(string name);

        void DoJump();


    }
}