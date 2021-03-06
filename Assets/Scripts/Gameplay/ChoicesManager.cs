﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MMBackend;

public class ChoicesManager : MonoBehaviour
{
    public MusicCore map;
    public ChoicesUI ui;
    public ProblemGenerator rng;
    public int numberOfChoices;

    public Button[] button = new Button[4];

    // Declare queue for FIFO operation
    public Queue<Question> questions = new Queue<Question>();
    public Queue<Question> bubbles = new Queue<Question>();
    public Queue<bool> noteStatus = new Queue<bool>();

    public Question problem;

    public Text soal;

    public void Initialization(int numberOfChoices, Timing[] judgementTime)
    {
        ui.Initialized(numberOfChoices);
        numberOfChoices += 2;
        problem = new Question(numberOfChoices);
        this.numberOfChoices = numberOfChoices;
        for (int i = 0; i < judgementTime.Length; i++)
        {
            GenerateChoices(judgementTime[i].regenerate);
        }
    }

    public void GenerateChoices(bool regenerate)
    {
        if (regenerate)
        {
            Question problem = new Question(numberOfChoices);
            problem = rng.GenerateProblem(problem, numberOfChoices);
            bubbles.Enqueue(problem);
            questions.Enqueue(problem);
            noteStatus.Enqueue(true);
        }
        else
        {
            noteStatus.Enqueue(false);
        }
    }

    public void CheckFor()
    {
        if (noteStatus.Count != 0)
        {
            if (noteStatus.Peek())
            {
                noteStatus.Dequeue();
                ChangeChoices();
            }
            else
            {
                noteStatus.Dequeue();
            }
        }
    }

    public Question GetQuestion()
    {
        Question bubbleData = new Question(numberOfChoices);
        bubbleData = bubbles.Dequeue();

        return bubbleData;
    }

    public bool AnswerCheck(int answer)
    {
        if (answer == problem.result)
        {
            CheckFor();
            return true;
        }
        else
        {
            CheckFor();
            return false;
        }
    }

    public void ChangeChoices()
    {
        // Get latest question from the queue
        problem = questions.Dequeue();

        // Assign multiple choices to UI
        for (int i = 0; i < problem.choices.Count; i++)
        {
            button[i].GetComponent<ChoiceLogic>().number = problem.choices[i];
            button[i].GetComponentInChildren<Text>().text = problem.choices[i].ToString();
        }

        string operation = "";
        switch (problem.operation)
        {
            case 0:
                operation = "+";
                break;

            case 1:
                operation = "-";
                break;

            case 2:
                operation = "*";
                break;
        }
        soal.text = $"Soal: {problem.x} {operation} {problem.y} = ?";
    }
}
