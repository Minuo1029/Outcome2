﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Teakisland.DialogueSystem;
namespace Teakisland
{

    [System.Serializable]
    public struct TalkLineItem
    {
        public float delaySkip;
        public string skipto;
        public string talkerName;
        [TextArea]
        public string message;
    }

    public class MainAutoRunner : MonoBehaviour
    {

        public static Dictionary<string, MainAutoRunner> AutoRunners = new Dictionary<string, MainAutoRunner>();
        public static Dictionary<string, QuestionSetting> QuestionSettings = new Dictionary<string, QuestionSetting>();


        public float startDelay = 1;
        public float autoTime = 2;
        public TalkLineItem[] lineItems;

        protected virtual void Start()
        {
            MainAutoRunner[] runners = FindObjectsOfType<MainAutoRunner>();
            QuestionSetting[] questions = FindObjectsOfType<QuestionSetting>();
            for (int i = 0; i < runners.Length; i++)
            {
                if (!AutoRunners.ContainsKey(runners[i].name))
                {
                    AutoRunners.Add(runners[i].name, runners[i]);
                }
            }
            for (int i = 0; i < questions.Length; i++)
            {
                if (!QuestionSettings.ContainsKey(questions[i].name))
                {
                    QuestionSettings.Add(questions[i].name, questions[i]);
                }
            }
            StartStoryLine();
        }

        public Coroutine StartStoryLine()
        {
             return StartCoroutine(LineRunner());
        }

        private IEnumerator LineRunner()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(startDelay);
            for (int i = 0; i < lineItems.Length; i++)
            {
                DialogueManager.Instance.Talk(lineItems[i].talkerName, lineItems[i].message);
                if (!string.IsNullOrEmpty(lineItems[i].skipto))
                {
                    yield return new WaitForSeconds(autoTime);
                    yield return SkipTo(lineItems[i].skipto);
                }
                yield return new WaitForSeconds(autoTime);
            }
        }

        public static Coroutine SkipTo(string skipName)
        {
            if (AutoRunners.ContainsKey(skipName))
            {
                return AutoRunners[skipName].StartStoryLine();
            }
            else if (QuestionSettings.ContainsKey(skipName))
            {
                return QuestionSettings[skipName].ShowQuestion();
            }
            return null;
        }

    }
}