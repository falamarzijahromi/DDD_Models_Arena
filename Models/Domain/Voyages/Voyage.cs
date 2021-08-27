using System;

namespace Domain.Voyages
{
    public class Voyage
    {
        public VoyageStates State { get; private set; } = VoyageStates.Sailing;

        public BerthPlan BerthPlan { get; private set; }

        public int Number { get; private set; }

        public Voyage(int number)
        {
            Number = number;
        }

        public BerthPlan ChangeStateToBerth()
        {
            if (BerthPlan is null)
                throw new Exception("Voyages Without Bert Plan Can Not Change State to Berth!");

            if (State is VoyageStates.Accomplished)
                throw new Exception("Accomplished Voyages Can Not Change State to Berth!");

            State = VoyageStates.Berth;

            return BerthPlan;
        }

        public void ChangeStateToCancel()
        {
            State = VoyageStates.Canceled;
        }

        public void ChangeStateToAnchorage()
        {
            State = VoyageStates.Anchorage;
        }

        public void ChangeStateToAccomplished()
        {
            if (State is not VoyageStates.Berth)
                throw new Exception("Voyage Must be in Berth State in Order to Change State to Accomplished");

            State = VoyageStates.Accomplished;
        }

        internal void SetBerthPlan(BerthPlan plan)
        {
            if (BerthPlan is not null)
                throw new Exception("Already Planned Voyages Can Not Plan Again!");

            BerthPlan = plan;
        }

        internal void ResetBerthPlan(BerthPlan plan)
        {
            if (BerthPlan is null)
                throw new Exception("Can Not Reset Berth Plan For Not Planned Voyages!");

            BerthPlan = plan;
        }
    }
}
