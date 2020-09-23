using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Teakisland.DialogueSystem
{

    public class QuestionItem : MonoBehaviour
    {

        public float Height
        {
            get
            {
                return ownRect.sizeDelta.y;
            }
        }

        public Text titleText;
        public Text hintText;
        public Text contentText;

        public Text selectTextA, selectTextB;
        public Button selectBtnA, selectBtnB;
        public Button closeBtn;

        private RectTransform ownRect;

        public void SetInteractable(bool value)
        {
            closeBtn.interactable = value;
            selectBtnA.interactable = value;
            selectBtnB.interactable = value;
        }

        public void SetQuestionData(QuestionData data)
        {
            ownRect = GetComponent<RectTransform>();
            titleText.text = data.title;
            hintText.text = data.hint;
            contentText.text = data.content;
            selectTextA.text = data.selectA;
            selectTextB.text = data.selectB;
            RefreshLayout();
        }

        /// <summary>
        /// 绑定点击叉叉按钮执行的方法
        /// </summary>
        /// <param name="action"></param>
        public void AddClick_Close(UnityAction action)
        {
            if (action == null) return;
            closeBtn.onClick.AddListener(action);
        }

        /// <summary>
        /// 绑定点击左选择按钮执行的方法
        /// </summary>
        /// <param name="action"></param>
        public void AddClick_SelectA(UnityAction action)
        {
            if (action == null) return;
            selectBtnA.onClick.AddListener(action);
        }

        /// <summary>
        /// 绑定点击右选择按钮执行的方法
        /// </summary>
        /// <param name="action"></param>
        public void AddClick_SelectB(UnityAction action)
        {
            if (action == null) return;
            selectBtnB.onClick.AddListener(action);
        }

        public void RefreshLayout()
        {
            ownRect.anchoredPosition = new Vector2(DialogueManager.Instance.padding_Left, -DialogueManager.Instance.padding_Top - DialogueManager.CurrentVertical);
            DialogueManager.CurrentVertical += ownRect.sizeDelta.y + DialogueManager.Instance.itemSpace;
            DialogueManager.Instance.RefreshContent();
        }

    }
}