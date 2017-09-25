using System.Collections.Generic;

namespace CardMaker.Model
{
    public class WorkItemsDataSource
    {
        public List<WorkItemsData> WorkItems { get; set; } 
    }

    public class WorkItemsData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AssignedTo { get; set; }
        public string State { get; set; }
        public string Rank { get; set; }
        public string Cost { get; set; }
        public string Team { get; set; }
        public string Iteration { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
        public string AreaSubPath { get; set; }
        public string IterationSubPath { get; set; }
        public string FirstLevelIteration { get; set; }
        public string Keywords { get; set; }
        public string ItemUrl { get; set; }
    }
}
