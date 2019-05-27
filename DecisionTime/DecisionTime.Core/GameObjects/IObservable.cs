using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.Core.GameObjects
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
    }
}
