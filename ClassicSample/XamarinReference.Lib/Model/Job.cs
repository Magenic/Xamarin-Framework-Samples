using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Model
{
    public class Job
    {
        //Header Info
        public string JobName { get; set; }
        public string CompanyName { get; set; }
        public string OfficeLocation { get; set; }

        //critical info
        public DateTime? DueDate { get; set; }

        // 0=green 1=yellow, 2=red
        public int NeedAction { get; set; }


        //percentage numbers for project work in prep phase, work phase, and delivery phase
        public float PercentPrep { get; set; }
        public float PercentWork { get; set; }
        public float PercentDelivery { get; set; }

        //task counts
        public int TaskInProgress { get; set; }
        public int TaskInReview { get; set; }
        public int TaskForReview { get; set; }
        public int TaskToDo { get; set; }
    }
}
