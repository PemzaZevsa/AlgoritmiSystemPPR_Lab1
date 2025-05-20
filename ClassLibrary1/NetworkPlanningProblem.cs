using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class NetworkPlanningProblem
    {
        public bool zeroElement;
        public bool additionalLastElement;

        public List<NetworkPlanningElement> WorkElements;
        public NetworkPlanningElement FirstElement {  get; set; }
        public NetworkPlanningElement LastElement {  get; set; }
        public int Count { get; set; }
        public double ProjectDuration 
        {
            get
            {
                return LastElement.EarlyFinish;
            }
        }
        public string CriticalPath
        {
            get
            {
                List<int> ids = new List<int>();

                foreach (var element in WorkElements)
                {
                    if (element.TimeReserve == 0)
                    {
                        ids.Add(element.ID);
                    }
                }

                return string.Join("-", ids);
            }
        }

        public NetworkPlanningProblem(List<string[]> rowsData)
        {
            zeroElement = false;
            additionalLastElement = false;
            this.Count = 1;//making assumption that all tasks starts from task#1 and other tasks sorted abc
            List<NetworkPlanningElement> workElements = new List<NetworkPlanningElement>();

            //Elements addition
            foreach (var row in rowsData)
            {
                NetworkPlanningElement tempEl = new NetworkPlanningElement(Count,row[0], double.Parse(row[1]), int.Parse(row[2]));
                Count++;
                workElements.Add(tempEl);
            }

            //first element addition
            List<int> firstElements = new List<int>();
            foreach (var element in workElements)
            {
                if (element.PreviousElements.Count == 0)
                {
                    firstElements.Add(element.ID);
                }
            }

            if (firstElements.Count > 1)
            {
                foreach (var element in workElements)
                {
                    if (element.PreviousElements.Count == 0)
                    {
                        element.NextElements.Add(0);
                    }
                }

                zeroElement = true;
                NetworkPlanningElement zeroEl = new NetworkPlanningElement(0, "-1", 0, 0);
                zeroEl.NextElements = firstElements;
                workElements.Add(zeroEl);
            }

            //linking elements
            foreach (var element in workElements)
            {
                foreach (var item in element.PreviousElements)
                {
                    workElements.FirstOrDefault(x => x.ID == item)?.NextElements.Add(element.ID);
                }
            }

            //last element addition
            List<int> lastElements = new List<int>();
            foreach (var element in workElements)
            {
                if (element.NextElements.Count == 0)
                {
                    lastElements.Add(element.ID);
                }
            }

            if (lastElements.Count > 1)
            {
                foreach (var element in workElements)
                {
                    if (element.NextElements.Count == 0)
                    {
                        element.NextElements.Add(Count);
                    }
                }

                additionalLastElement = true;
                NetworkPlanningElement lastEl = new NetworkPlanningElement(Count, string.Join(",", lastElements), 0, 0);
                Count++;
                workElements.Add(lastEl);
            }


            ArgumentNullException.ThrowIfNull(workElements);
            WorkElements = workElements;

            NetworkPlanningElement temp = workElements.FirstOrDefault();//redo
            if (temp is not null)
            {
                FirstElement = temp;
            }
            else
            {
                throw new ArgumentException("Першому елементу наамагається призначитися NULL-значення");
            }

            temp = workElements.LastOrDefault();//redo
            if (temp is not null)
            {
                LastElement = temp;
            }
            else
            {
                throw new ArgumentException("Останньому елементу наамагається призначитися NULL-значення");
            }
        }

        public void CalculateaEarlyStartFinish()
        {
            foreach (var element in WorkElements)
            {
                element.CalculteEarlyStart(WorkElements);
                element.CalculteEarlyFinish();
            }
        }

        public void CalculateaLateStartFinish()
        {
            foreach (var element in WorkElements.AsEnumerable().Reverse())
            {
                element.CalculteLateFinish(WorkElements);
                element.CalculteLateStart();
            }
        }

        public void CalculateTimeReserves()
        {
            foreach (var element in WorkElements)
            {
                element.CalculateTimeReserve();
            }
        }

        
    }
}
