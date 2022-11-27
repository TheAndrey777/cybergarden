namespace greenatom.ViewModels ;

    [Serializable]
    public record FormViewModel
    {
        public string FullName;
        public DateTime DateBirth;
        public Occupation Occupation;
        public FamiliarWithProgramming FamiliarWithProgramming;
        public MajorCommercialProjects MajorCommercialProjects;

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