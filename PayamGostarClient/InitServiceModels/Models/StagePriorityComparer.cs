using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.InitServiceModels.Models
{
    internal class StagePriorityComparer : IComparer<Stage>
    {
        private static StagePriorityComparer s_stagePriorityComparer;

        private StagePriorityComparer()
        {
        }

        internal static StagePriorityComparer GetInstance()
        {
            if (s_stagePriorityComparer == null)
            {
                s_stagePriorityComparer = new StagePriorityComparer();
            }

            return s_stagePriorityComparer;
        }

        public int Compare(Stage x, Stage y)
        {
            if ((x.IsDoneStage && y.IsDoneStage) || (!x.IsDoneStage && !y.IsDoneStage))
            {
                return 0;
            }
            else if (x.IsDoneStage && !y.IsDoneStage)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        
    }
}
