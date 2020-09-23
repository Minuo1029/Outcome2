using System.Collections;
using Teakisland.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;
namespace Teakisland
{

    [System.Serializable]
    public class ActionEvent : UnityEvent { }

    public class QuestionSetting : MonoBehaviour
    {

        public float skipDelay=2;
        public string ASkipto;
        public string BSkipto;
        public string closeSkipto;
        [Space(5)]
        public string userSay_close;
        public string userSay_selectA;
        public string userSay_selectB;
        [Space(5)]
        public QuestionData question;

        private bool isClick;
        private QuestionItem questionItem;

        public Coroutine ShowQuestion()
        {
            isClick = false;
            return StartCoroutine(WaitUserSelect());
        }

        private IEnumerator WaitUserSelect()
        {
            questionItem = DialogueManager.Instance.Question(question);
            questionItem.AddClick_SelectA(SelectA);
            questionItem.AddClick_SelectB(SelectB);
            questionItem.AddClick_Close(Close);
            while (!isClick) yield return null;
        }

        private IEnumerator WaitForResult(string skip)
        {
            yield return new WaitForSeconds(skipDelay);
            questionItem.SetInteractable(false);
            yield return MainAutoRunner.SkipTo(skip);
            isClick = true;
        }

        public void Close()
        {
            if (!string.IsNullOrEmpty(userSay_close)) DialogueManager.Instance.Talk(DialogueManager.Instance.talker0.name, userSay_close);
            StartCoroutine(WaitForResult(closeSkipto));
        }

        public void SelectA()
        {
            if (!string.IsNullOrEmpty(userSay_close)) DialogueManager.Instance.Talk(DialogueManager.Instance.talker0.name, userSay_selectA);
            StartCoroutine(WaitForResult(ASkipto));
        }

        public void SelectB()
        {
            if (!string.IsNullOrEmpty(userSay_close)) DialogueManager.Instance.Talk(DialogueManager.Instance.talker0.name, userSay_selectB);
            StartCoroutine(WaitForResult(BSkipto));
        }

    }
}