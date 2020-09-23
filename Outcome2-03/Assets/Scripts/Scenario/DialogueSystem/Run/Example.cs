using Teakisland.DialogueSystem;
using UnityEngine;

namespace Teakisland
{
    public class Example : MonoBehaviour
    {

        private void OnGUI()
        {
            GUI.skin.label.fontSize = 25;
            GUI.contentColor = Color.green;
            GUILayout.Label("按下数字键1~5使用不同的角色发送消息");
            GUILayout.Label("按下Q键弹出问题选择框框");
            GUILayout.Label("按下空格键滑动至最下");
            GUILayout.Label("按下Esc清空气泡");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //发送消息实例

                //方法一，创建一个角色，使用默认头像
                //Talker talker = new Talker("Exampler");
                //talker.Say("Hello everyone, I'm Exampler !");

                //方法二，使用设置好的角色发送消息
                //DialogueManager.Instance.Talk("Jimmy", "Hello everyone, I'm Jimmy !");

                //如果没有找到指定的角色则自动创建一个角色，发送消息，效果同方法一
                DialogueManager.Instance.Talk("Exampler", "Hello everyone, I'm Exampler !");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DialogueManager.Instance.Talk("User", "Hello everyone, I'm User !");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                DialogueManager.Instance.Talk("Mike", "Hello everyone, I'm Mike !");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                DialogueManager.Instance.Talk("Emily", "Hello everyone, I'm Emily !");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                DialogueManager.Instance.Talk("Frank", "Hello everyone, I'm Frank !");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuestionData data = new QuestionData("A conflict has occured. how do you proceed?", "anyone here", "A conflict has occured. how do you proceed?A conflict has occured. how do you proceed?", "SelectA", "SelectB");
                DialogueManager.Instance.Question(data, Close, SelectA, SelectB);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueManager.Instance.ScrollToEnd();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DialogueManager.Instance.ClearCache();
            }

        }

        public void Close()
        {
            Debug.Log("点击了Close");
        }

        public void SelectA()
        {
            Debug.Log("点击了SelectA");
        }

        public void SelectB()
        {
            Debug.Log("点击了SelectB");
        }

    }
}