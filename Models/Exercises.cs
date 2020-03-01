using System;
using System.Collections.Generic;

namespace RESTAPIDEMO.Models
{
    public partial class Exercises
    {
        public int Id { get; set; }
        public string Exercise { get; set; }
        public string Solution { get; set; }
        public string VarableData { get; set; }
        public string ExerciseLevel { get; set; }
        public string ProjectType { get; set; }
        public string Langues { get; set; }
        public string ExpectedSolution { get; set; }
    }
}
