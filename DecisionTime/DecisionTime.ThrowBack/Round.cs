using DecisionTime.Core;
using DecisionTime.Core.Constants;
using DecisionTime.Core.GameObjects;
using System.Collections.Generic;

namespace DecisionTime.ThrowBack
{
    public class Round
    {
        public string PlayerName { get; set; }
        public Game Game { get; set; }
        public int Turn { get; set; } = 1;
        public List<Decision> Decisions { get; set; }
        public string Title { get; set; }
        public bool GameOver { get; set; }

        public Round(string playerName, string level)
        {
            PlayerName = playerName;
            var difficulty = GameLevelHelper.GetGameLevel(level);
            Game = new Game(difficulty);

            if (difficulty == GameLevel.Easy)
            {
                Title = "Coward";
            }
            else
            {
                Title = "Meek";
            }
            
        }

        public void EndTurn()
        {
            // Do end of turn calcs
            Turn++;
        }

        public void LoadDecisions(List<Decision> decisionList)
        {
            Decisions = decisionList;
        }

        public Decision PresentDecision()
        {
            var decision = Decisions.Find(dec => dec.IsResolved.Equals(false));

            if (decision is null)
            {
                GameOver = true;
            }

            return decision;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}
