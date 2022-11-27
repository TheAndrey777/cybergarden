namespace greenatom.ViewModels ;

    public record class FormViewModel
    {
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public Occupation Occupation { get; set; }
        public FamiliarWithProgramming FamiliarWithProgramming { get; set; }
        public MajorCommercialProjects MajorCommercialProjects { get; set; }

        public override string ToString()
        {
            return $"{FullName} {DateBirth} {Occupation} {FamiliarWithProgramming} {MajorCommercialProjects}";
        }
    }

    [Serializable]
    public enum Occupation
    {
        Schoolboy,
        Student,
        WorkIt,
        WorkOutsideIt,
        DontHaveJob,
        Pensioner,
    }

    [Serializable]
    public enum FamiliarWithProgramming
    {
        Zero,
        Recently,
        Years1To3,
        Years3To5,
        YearsMoreThan5
    }

    [Serializable]
    public enum MajorCommercialProjects
    {
        Zero,
        NotMonetized,
        SeveralProjects,
        ProjectsIsMonetized
    }