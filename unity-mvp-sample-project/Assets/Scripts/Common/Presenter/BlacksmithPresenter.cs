using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Model;
using Common.View;

namespace Common.Presenter
{
    public class BlacksmithPresenter : IBlacksmithPresenter
    {
        IBlacksmithView View;
        BlacksmithModel model;
        public BlacksmithPresenter(IBlacksmithView view)
        {
            model = new BlacksmithModel();

            View = view;
        }
        public void Addlives()
        {
            model.Lives += 10;
            View.SetLives(model.Lives);
        }

        public void Greet()
        {
            View.PlayAnimation("greet");
        }

        public void Jump()
        {
            View.DoJump();
        }
    }
}