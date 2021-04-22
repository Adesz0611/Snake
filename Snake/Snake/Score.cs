using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Score
    {
        private UInt64 score;
        private UInt64 savedScore;

        public Score() {
            Reset();
        }
        public void Reset() {
            score = 0;
            savedScore = LoadScore();
        }

        public UInt64 GetScore() {
            return score;
        }

        public void AddToScore(UInt64 p_score) {
            score += p_score;
        }

        public void SaveScore() {
            UInt64 currentMax = LoadScore();
            FileStream f = new FileStream("score.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);

            sw.Write(Math.Max(GetScore(), currentMax));
            savedScore = Math.Max(GetScore(), currentMax);

            sw.Close();
            f.Close();
        }

        public static UInt64 LoadScore() {
            UInt64 score = 0;
            if (File.Exists("score.txt"))
            {
                FileStream f = new FileStream("score.txt", FileMode.Open);
                StreamReader sr = new StreamReader(f);

                score = UInt64.Parse(sr.ReadLine());

                sr.Close();
                f.Close();
            }

            return score;
        }

        public void printScoreLabel() {
            Console.SetCursorPosition(1, 33);
            Console.Write("Jelenlegi pontszám: ");
        }

        private string checkIfRecord() {
            return (savedScore < score) ? " [Új Rekord]" : "";
        }

        public void printScore() {
            Console.SetCursorPosition(21, 33);
            Console.Write(score + checkIfRecord());
        }
    }
}
