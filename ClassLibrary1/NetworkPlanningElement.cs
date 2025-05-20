using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class NetworkPlanningElement
    {
        public int ID { get; set; }
        public double WorkDuration { get; set; }
        public double EarlyStart { get; set; }
        public double LateStart { get; set; }
        public double LateFinish { get; set; }
        public double EarlyFinish { get; set; }
        public double TimeReserve { get; set; }
        public int ManAmount { get; set; }
        public List<int> PreviousElements { get; set; }
        public List<int> NextElements { get; set; }

        public NetworkPlanningElement(int id, string previousElementsString, double workDuration, int manAmount)
        {
            PreviousElements = new List<int>();
            NextElements = new List<int>();
            ID = id;
            WorkDuration = workDuration;
            ManAmount = manAmount;

            PreviousElements = new List<int>();
            if (previousElementsString.Trim() == "-")
            {
                PreviousElements.Add(0);
            }
            else
            {
                PreviousElements.AddRange(
                    previousElementsString.Split(',')
                         .Select(s => int.Parse(s.Trim()))
                );
            }

        }

        public void CalculteEarlyStart(List<NetworkPlanningElement> WorkElements)
        {
            double maxFinish = 0;
            foreach (var elementID in PreviousElements)
            {
                var match = WorkElements.FirstOrDefault(x => x.ID == elementID);
                double finish = 0;
                if (match != null)
                {
                    finish = match.EarlyFinish;
                }
                else
                {
                    finish = 0;
                }

                if (finish > maxFinish)
                {
                    maxFinish = finish;
                }
            }

            EarlyStart = maxFinish;
        }

        public void CalculteEarlyFinish()
        {
            EarlyFinish = EarlyStart + WorkDuration;
        }

        public void CalculteLateStart()
        {
            LateStart = LateFinish - WorkDuration;
        }

        public void CalculteLateFinish(List<NetworkPlanningElement> WorkElements)
        {
            double minStart = double.MaxValue; 

            if (NextElements.Count == 0)
            {
                minStart = EarlyFinish;
            }

            foreach (var elementID in NextElements)
            {
                var match = WorkElements.FirstOrDefault(x => x.ID == elementID);
                double start = 0;
                if (match != null)
                {
                    start = match.LateStart;
                }
                else
                {
                    start = EarlyFinish;
                }

                if (start < minStart)
                {
                    minStart = start;
                }
            }

            LateFinish = minStart;
        }

        public void CalculateTimeReserve()
        {
            TimeReserve = LateFinish - EarlyFinish;
        }
    }
}
