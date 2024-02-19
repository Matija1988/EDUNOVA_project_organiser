using Organiser.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Organiser
{
    internal class DataInitialisation
    {
        public  List<Project> _projects { get; set; }

        public List<Member> _members { get; set; }

        private Main Main { get;  }

        public DataInitialisation (Main Main) : this()
        {
            this.Main = Main;
            
        }

        public DataInitialisation()
        {
            _projects = new List<Project>();
            _members = new List<Member>();

            FillProjectsList();
            FillMembersList();

         }

      
        private void FillProjectsList()
        {
            IProject project = Factory.ProjectFactory();
            project.id = 1;
            project.UniqueID = "JP21-21KD";
            project.Name = "Poboljšanje energetske učinkovitosti zgrade Zamišljena Adresa 2";
            project.DateStart = DateTime.Parse("21.05.2023.");
            project.DateEnd = DateTime.Parse("21.11.2024.");
            project.IsFinished = false;

            _projects.Add((Project)project);

            IProject project1 = Factory.ProjectFactory();
            project1.id = 2;
            project1.UniqueID = "UZ-54-2-I";
            project1.Name = "Uspostava regionalnog centra kompetentnosti Srednja strukovna škola Bubimir";
            project1.DateStart = DateTime.Parse("01.01.2021.");
            project1.DateEnd = DateTime.Parse("29.12.2023.");
            project1.IsFinished = true;

            _projects.Add((Project)project1);

            IProject project2 = Factory.ProjectFactory();
            project2.id = 3;
            project2.UniqueID = "A4-K-7-762";
            project2.Name = "Zelene staze Dunava i Drave";
            project2.DateStart = DateTime.Parse("12.04.2019.");
            project2.DateEnd = DateTime.Parse("01.05.2022.");
            project2.IsFinished = true;

            _projects.Add((Project)project2);

            IProject project3 = Factory.ProjectFactory();
            project3.id = 4;
            project3.UniqueID = "INTER-HU-CRO-213-D-91";
            project3.Name = "INTEREG-Hungary-Croatia cluster sustainability du dah";
            project3.DateStart = DateTime.Parse("20.01.2023");
            project3.DateEnd = DateTime.Parse("20.10.2023.");
            project3.IsFinished = true;
            
            _projects.Add((Project)project3);


        }

        private void FillMembersList()
        {
            IMember member = Factory.MemberFactory();
            member.Name = "Matija";
            member.LastName = "Pavkovic";
            member.Username = "test";
            member.Password = "test";
            member.IsTeamLeader = true;

            _members.Add((Member)member);

            IMember member1 = Factory.MemberFactory();
            member1.Name = "Tester";
            member1.LastName = "Testic";
            member1.Username = "Tester";
            member1.Password =  "abcd";

            member1.IsTeamLeader = false;

            _members.Add((Member)member1);


        }

    }
}
