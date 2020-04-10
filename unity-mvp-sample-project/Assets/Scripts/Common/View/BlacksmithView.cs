using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common.Presenter;
namespace Common.View
{
    public class BlacksmithView : MonoBehaviour, IBlacksmithView
    {

        public Text LivesLabel;
        IBlacksmithPresenter presenter;
        Animator anim;
     
        bool jump = false;
        float jump_speed = 8.0f;
        float fall_speed = 5.0f;
        bool fall = false;
   
        void Start()
        {
            presenter = new BlacksmithPresenter(this);
            anim = GetComponent<Animator>();
    
        }

        void Update()
        {
            if (jump)
            {
                transform.position += transform.up * jump_speed * Time.deltaTime;
                jump_speed -= 8 * Time.deltaTime;
                if (jump_speed <= 0)
                {
                    jump_speed = 8.0f;
                    jump = false;
                    fall = true;
                }
               
            }
            else if (fall)
            {
                if (Physics2D.Raycast(transform.position-transform.up*2 , -transform.up, 0.001f))
                {
                    fall_speed = 5;
                    fall = false;
                  
                }
                else
                {
                    fall_speed += 2.0f*Time.deltaTime;
                    transform.position += -transform.up * fall_speed * Time.deltaTime;
                }
            }
        }

        #region <<Events trigger presetner methods>>

        /// <summary>
        /// calls from UI button
        /// </summary>
        public void User_Event_Greet()
        {
            presenter.Greet();
        }


        /// <summary>
        /// calls from UI button
        /// </summary>
        public void User_Event_Jump()
        {
            presenter.Jump();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.tag== "Health")
            {
                StartCoroutine(AddLives(collider.gameObject));
            }
        }

        /// <summary>
        /// calling a presenter method
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        IEnumerator AddLives(GameObject g)
        {
            g.SetActive(false);
            presenter.Addlives();

            yield return new WaitForSeconds(2.0f);
            g.SetActive(true);

        }
        #endregion



        #region <<View methods that presenter calls them>>
        /// <summary>
        /// IBlacksmithView method
        /// </summary>
        /// <param name="lives">amount of lives to add</param>
        public void SetLives(int lives)
        {
            LivesLabel.text = "Lives: " + lives.ToString();
        }

        /// <summary>
        /// IBlacksmithView method
        /// </summary>
        /// <param name="name"></param>
        public void PlayAnimation(string name)
        {
            if (name == "greet")
            {
                anim.SetTrigger("greet");
            }
        }

        /// <summary>
        /// IBlacksmithView method
        /// </summary>
        public void DoJump()
        {
            
            jump = true;
        }

        #endregion
    }
}