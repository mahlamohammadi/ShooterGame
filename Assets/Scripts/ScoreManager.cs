using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public static void AddScore(int score) =>  Score += score;
}
