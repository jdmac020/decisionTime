using DecisionTime.Core;
using DecisionTime.Core.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionTime.ThrowBack
{
    public class Round
    {
        public string PlayerName { get; set; }
        public Game Game { get; set; }
        public int Turn { get; set; } = 1;
        public List<Decision> Decisions { get; set; }

        public Round(string playerName, string level)
        {
            PlayerName = playerName;
            var difficulty = GameLevelHelper.GetGameLevel(level);
            Game = new Game(difficulty);
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
            return Decisions.Find(decision => decision.IsResolved.Equals(false));
        }

        public void ResolveDecision(Decision decision, int optionId)
        {
            decision.Resolve(optionId);
        }
    }
}
