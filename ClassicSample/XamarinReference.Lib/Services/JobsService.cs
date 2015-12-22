using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

namespace XamarinReference.Lib.Services
{
    public class JobsService : IJobsService
    {
        public IList<Job> Jobs { get; set; }

        public JobsService()
        {
            Jobs = new List<Job>
            {
                 new Job
                 {
                    JobName = "House Corrino Spice Audit",
                    CompanyName = "CHOAM",
                    OfficeLocation = "Planet Arrakis",
                    DueDate =  null,
                    NeedAction = 1,
                    PercentPrep = 30.0f,
                    PercentDelivery = 0.0f,
                    PercentWork = 25.0f,
                    TaskInProgress = 100,
                    TaskInReview = 20,
                    TaskForReview  = 2,
                    TaskToDo = 5
                 },
                new Job
                 {
                    JobName = "Year End 2015",
                    CompanyName = "Acme Corp.",
                    OfficeLocation = "New Jersey",
                    DueDate =  new DateTime(2015, 12, 31),
                    NeedAction = 2,
                    PercentPrep = 80.0f,
                    PercentDelivery = 90.0f,
                    PercentWork = 1.0f,
                    TaskInProgress = 4,
                    TaskInReview = 3,
                    TaskForReview  = 2,
                    TaskToDo = 100 
                 },
                new Job
                 {
                    JobName = "Construction Review for new Highways",
                    CompanyName = "Sirius Cybernetics Corp.",
                    OfficeLocation = "London, England",
                    DueDate =  new DateTime(2015, 10, 1),
                    NeedAction = 0,
                    PercentPrep = 100f,
                    PercentDelivery = 100f,
                    PercentWork = 100f,
                    TaskInProgress = 9999,
                    TaskInReview = 9999,
                    TaskForReview  = 9999,
                    TaskToDo = 9999 
                 },
                 new Job
                 {
                    JobName = "Top Secret Really, Really, Really long project name needed to test long project names to make sure that they work properly in the app.",
                    CompanyName = "Really long company name used to test that we can properly display really long company names",
                    OfficeLocation = "Really long city name to prove we can support really long location names",
                    DueDate =  new DateTime(9999, 12, 31),
                    NeedAction = 0,
                    PercentPrep = 60f,
                    PercentDelivery = 69f,
                    PercentWork =  75f,
                    TaskInProgress = 9999,
                    TaskInReview = 9999,
                    TaskForReview  = 9999,
                    TaskToDo = 9999
                 },
                 new Job
                 {
                    JobName = "Very Big Project for Year End of 2015",
                    CompanyName = "Very Big Corp. of America",
                    OfficeLocation = "Washington, D.C.",
                    DueDate =  new DateTime(2015, 12, 1),
                    NeedAction = 2,
                    PercentPrep = 0.0f,
                    PercentDelivery = 0.0f,
                    PercentWork = 0.0f,
                    TaskInProgress = 0,
                    TaskInReview = 0,
                    TaskForReview  = 0,
                    TaskToDo = 0
                 },
                 new Job
                 {
                    JobName = "LexCorp & Wayne Enterprises Merger",
                    CompanyName = "Wayne Enterprises",
                    OfficeLocation = "Gotham City",
                    DueDate =  new DateTime(2016, 07, 04),
                    NeedAction = 2,
                    PercentPrep = 42.0f,
                    PercentDelivery = 12.5f,
                    PercentWork = 2.0f,
                    TaskInProgress = 4096,
                    TaskInReview = 32,
                    TaskForReview  = 16,
                    TaskToDo = 8 
                 },
                 new Job
                 {
                    JobName = "3rd Quarter Bookkeeping Work 2015",
                    CompanyName = "Stark Industeries",
                    OfficeLocation = "Manhattan New York City",
                    DueDate =  new DateTime(2015, 11, 2),
                    NeedAction = 1,
                    PercentPrep = 64.0f,
                    PercentDelivery = 32.5f,
                    PercentWork = 0.0f,
                    TaskInProgress = 1024,
                    TaskInReview = 16,
                    TaskForReview  = 8,
                    TaskToDo = 4
                 },

            };
        }
    }
}
