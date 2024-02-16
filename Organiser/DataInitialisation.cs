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
            project.UniqueID = "KK 21";
            project.Name = "Hakuna matata";
            project.DateStart = DateTime.Parse("12.11.2023.");
            project.DateEnd = DateTime.Parse("04.02.2024.");
            project.IsFinished = true;

            _projects.Add((Project)project);

            IProject project1 = Factory.ProjectFactory();
            project1.UniqueID = "LOL 20220";
            project1.Name = "Mlad razuzdan i lud";
            project1.DateStart = DateTime.Parse("12.11.2023.");
            project1.DateEnd = DateTime.Parse("14.10.2024.");
            project1.IsFinished = false;

            _projects.Add((Project)project1);


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
            member1.Password = "abcd";
            member1.IsTeamLeader = false;

            _members.Add((Member)member1);


        }

    }
}
