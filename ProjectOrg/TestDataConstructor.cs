using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class TestDataConstructor
    {
        public List<Member> Members {  get; set; }

        public List<Project> Projects { get; set; }

        public List<ProofOfDelivery> ProofOfDeliveries { get; set; }

        public List<Folder> Folders { get; set; }

        public List<Activity> Activities { get; set; }



        public Main Main {  get;  }

        public TestDataConstructor(Main main) 
        
        { 
            this.Main = main;

            Members = new List<Member>();
            MembersDataConstructor();

            ProofOfDeliveries = new List<ProofOfDelivery>();
            ProofDataConstructor();

            Projects = new List<Project>();
            ProjectDataConstructor();

            Folders = new List<Folder>();
            FoldersDataConstructor();

            Activities = new List<Activity>();
            ActivitiesDataConstructor();
            
        }

                 
        public void MembersDataConstructor()
        {
            Members.Add(new Member()
            {
                id = U01UserInputs.AutoIncrementID(Members),
                Name = "Matija",
                LastName = "Pavkovic",
                Username = "test",
                Password = "test",
                IsTeamLeader = true,

            });

            Members.Add(new Member()
            {
                id = U01UserInputs.AutoIncrementID(Members),
                Name = "Tester",
                LastName = "Testic",
                Username = "tester",
                Password = "abcd",
                IsTeamLeader = false,

            });

            
        }

        public void ProjectDataConstructor()
        {
            Projects.Add(new Project()
            {
                id = 1,
                UniqueID = "K.K. 2711",
                Name = "Urbana aglomeracija zamisljeni grad",
                DateStart = DateTime.Parse("07.01.2021."),
                DateEnd = DateTime.Parse("12.05.2024."),
                IsFinished = false


            });

            Projects.Add(new Project()
            {
                id = 2,
                UniqueID = "JUPP 412",
                Name = "Izrada interaktivne slikovnice JU PP Biokovo",
                DateStart = DateTime.Parse("10.04.2021."),
                DateEnd = DateTime.Parse("10.05.2022."),
                IsFinished = false

            });

            Projects.Add(new Project()
            {
                id = 3,
                UniqueID = "K.K 712",
                Name = "Izrada studijsko-projektne dokumentacije za stazu i nigdjezemsku",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now,
                IsFinished = true

            });
        }

        public void ProofDataConstructor()
        {
            ProofOfDeliveries.Add(new ProofOfDelivery()
            {
                id = 1,
                DocumentName = "Media plan",
                Location = "//Urbana aglomeracija zamisljeni grad//1.1. Izrada media plana//",
                Member = Members[0],
                DateCreated = DateTime.Parse("10.11.2023.")
            });

            ProofOfDeliveries.Add(new ProofOfDelivery()
            {
                id = 2,
                DocumentName = "Slikovnica knjizni blok",
                Location = "//Izrada interaktivne slikovnice JU PP Biokovo//1. Dizajn slikovnice//",
                Member = Members[1],
                DateCreated = DateTime.Parse("10.11.2023.")
            });
        }


        public void FoldersDataConstructor ()
        {
            Folders.Add(new Folder()
            {
                id = 1,
                Location = "//Urbana aglomeracija zamisljeni grad//",
                ContractActivityName = "1.1. Izrada media plana",
                ProofOfDelivery = ProofOfDeliveries[0],


            });

            Folders.Add(new Folder()
            {
                id = 2,
                Location = "//Izrada interaktivne slikovnice JU PP Biokovo//",
                ContractActivityName = "1. Dizajn slikovnice",
                ProofOfDelivery = ProofOfDeliveries[1],


            });
        }

        public void ActivitiesDataConstructor()
        {
            Activities.Add(new Activity()
            {
                id = 1,
                Name = "1.1. Izrada media plana",
                Description = "Potrebno je izraditi media plan koji obuhvaca lokalne medije",
                DateStart = DateTime.Parse("10.02.2021."),
                DateEnd = DateTime.Parse("10.03.2021."),
                Folder = Folders[0],
                IsFinished = true,
                DateAccepted = DateTime.Parse("08.03.2021"),
                AssociatedProject = Projects[0],
                Member = Members[0],



            });


            Activities.Add(new Activity()
            {
                id = 2,
                Name = "1. Dizajn slikovnice",
                Description = "Dizajn slikovnice koja ide uz pametnu olovku te prikazuje floru i faunu podrucja PP Biokovo.",
                DateStart = DateTime.Parse("11.04.2021."),
                DateEnd = DateTime.Parse("01.12.2021."),
                Folder = Folders[1],
                IsFinished = true,
                DateAccepted = DateTime.Parse("20.11.2021."),
                AssociatedProject = Projects[1],
                Member = Members[1]


            });

            Activities.Add(new Activity()
            {
                id = 3,
                Name = "1.2. Izrada strategije kriznog komuniciranja",
                Description = "Potrebno je izraditi strategiju kriznog komuniciranja koja ukljucuje formiranje TKK, scenarije kriza, evaluaciju medija ...",
                DateStart = DateTime.Parse("20.02.2021."),
                DateEnd = DateTime.Parse("20.03.2021."),
                Folder = Folders[0],
                IsFinished = true,
                DateAccepted = DateTime.Parse("18.03.2021"),
                AssociatedProject = Projects[0],
                Member = Members[0],

            });
        }
    }
}
