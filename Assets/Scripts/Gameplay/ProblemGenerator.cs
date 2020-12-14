using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MMBackend;

public class ProblemGenerator : MonoBehaviour
{
    // Game internal difficulty
    int min = 0;
    int max = 9;

    public Question GenerateProblem(Question question, int numberOfChoices)
    {
        question = new Question(numberOfChoices);
        for (int i = 0; i < numberOfChoices; i++)
            question.choices.Add(0);

        question.x = Random.Range(min, max);
        question.y = Random.Range(min, max);

        // 0(Sum), 1(Subtraction), 2(Multiplication)
        question.operation = Random.Range(0, 2);

        switch (question.operation)
        {
            case 0:
                question.result = question.x + question.y;
                break;

            case 1:
                question.result = question.x - question.y;
                break;

            case 2:
                question.result = question.x * question.y;
                break;

            default:
                Debug.LogError("Error occured while trying to Generate a Math Problem");
                break;
        }

        int answerPos = Random.Range(0, question.choices.Count);
        //Debug.Log($"Answer: {question.result}");
        int number = 0;

        // Insert the answer into corresponding position generated beforehand
        question.choices[answerPos] = question.result;

        // Generate the incorrect answer for the rest of the array
        for (int i = 0; i < question.choices.Count; i++)
        {
            // If trying to generate the already filled answer in the array skip
            if (i == answerPos) continue;

            // Generating number
            while (true)
            {
                switch (question.operation)
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
                        // Debug.LogError("Error occured while trying to Generate a Math Problem");
                        break;
                }
                // To make sure the generated incorrect answer will not be the same
                if (!question.choices.Contains(number))
                {
                    // Set the number to x-choices
                    question.choices[i] = number;
                    break;
                }
            }
        }
        return question;
    }
}
