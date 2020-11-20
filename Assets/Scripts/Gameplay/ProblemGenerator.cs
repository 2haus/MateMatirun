using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    public int operation;
    int min = 0;
    int max = 9;

    public int x;
    public int y;
    public int result;

    public List<int> choices;

    public void Initialization(int numberOfChoices)
    {
        choices = new List<int>(numberOfChoices);
        for (int i = 0; i < numberOfChoices; i++)
            choices.Add(0);
    }

    public void GenerateProblem()
    {
        x = Random.Range(min, max);
        y = Random.Range(min, max);

        // 0(Sum), 1(Subtraction), 2(Multiplication)
        operation = Random.Range(0, 2);

        switch (operation)
        {
            case 0:
                result = x + y;
                break;

            case 1:
                result = x - y;
                break;

            case 2:
                result = x * y;
                break;

            default:
                Debug.LogError("Error occured while trying to Generate a Math Problem");
                break;
        }
    }

    public void GenerateChoices()
    {
        int answerPos = Random.Range(0, choices.Count);
        Debug.Log($"Answer Pos: {answerPos}");
        int number = 0;

        // Insert the answer into corresponding position generated beforehand
        choices[answerPos] = result;

        // Generate the incorrect answer for the rest of the array
        for (int i = 0; i < choices.Count; i++)
        {
            // If trying to generate the already filled answer in the array skip
            if (i == answerPos) continue;

            // Generating number
            while (true)
            {
                switch (operation)
                {
                    case 0:
                        number = Random.Range(0, min + max);
                        break;

                    case 1:
                        number = Random.Range(-max, max);
                        break;

                    case 2:
                        number = Random.Range(0, max * max);
                        break;

                    default:
                        Debug.LogError("Error occured while trying to Generate a Math Problem");
                        break;
                }
                // To make sure the generated incorrect answer will not be the same
                if (!choices.Contains(number))
                {
                    choices[i] = number;
                    break;
                }
            }
        }
    }
}
