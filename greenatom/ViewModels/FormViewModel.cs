namespace greenatom.ViewModels ;

    public class FormViewModel
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

    public enum Occupation
    {
        Schoolboy,
        Student,
        WorkIt,
        WorkOutsideIt,
        DontHaveJob,
        Pensioner,
    }

    public enum FamiliarWithProgramming
    {
        Zero,
        Recently,
        Years1To3,
        Years3To5,
        YearsMoreThan5
    }

    public enum MajorCommercialProjects
    {
        Zero,
        NotMonetized,
        SeveralProjects,
        ProjectsIsMonetized
    }