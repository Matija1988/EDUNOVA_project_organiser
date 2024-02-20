﻿using Organiser.ObjectClasses;
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

        public List<Activity> _activities { get; set; }

        private Main Main { get;  }

        public DataInitialisation (Main Main) : this()
        {
            this.Main = Main;
            
        }

        public DataInitialisation()
        {
          
            _projects = new List<Project>();
            _members = new List<Member>();
            _activities = new List<Activity>();


            FillProjectsList();
            FillMembersList();
            FillActivitiesList();

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
            member.id = 1;
            member.Name = "Matija";
            member.LastName = "Pavkovic";
            member.Username = "test";
            member.Password = "test";
            member.IsTeamLeader = true;

            _members.Add((Member)member);

            IMember member1 = Factory.MemberFactory();
            member1.id = 2; 
            member1.Name = "Tester";
            member1.LastName = "Testic";
            member1.Username = "Tester";
            member1.Password =  "abcd";

            member1.IsTeamLeader = false;

            _members.Add((Member)member1);


        }

        private void FillActivitiesList()
        {
            IActivity activity = Factory.ActivityFactory();
            activity.id = 1;
            activity.Name = "1.1.Izrada analize troškova i koristi";
            activity.Description = "Energetska obnova zgrade ... mora uključivati izolaciju vanjskog zida, dizalicu topline, ugradnju PVC stolarije, fotonaponske ćelije 12 kw/h ...";
            activity.DateStart = DateTime.Parse("01.06.2023.");
            activity.DateEnd = DateTime.Parse("01.08.2023.");
       //     activity.ProofOfDelivery = null;
            activity.IsFinished = true;
            activity.DateAccepted = DateTime.Parse("29.07.2023.");
            activity.AssociatedProject = 1;
            activity.MemberID = 1;

            _activities.Add((Activity)activity);

            IActivity activity1 = Factory.ActivityFactory();
            activity1.id = 2;
            activity1.Name = "2.1. Zakup medijskog prostora na nacionalnim radio postajama";
            activity1.Description = "Izrada radio jingla 30 sekundi, zakup nacionalne radio postaje za 50 emitiranja";
            activity1.DateStart = DateTime.Parse("15.02.2021.");
            activity1.DateEnd = DateTime.Parse("28.03.2021.");
          //  activity1.ProofOfDelivery = null;
          activity1.IsFinished = true;
            activity1.DateAccepted = DateTime.Parse("01.04.2021.");
            activity1.AssociatedProject = 2;
            activity1.MemberID = 2;

            _activities.Add((Activity)activity1);

            IActivity activity2 = Factory.ActivityFactory();
            activity2.id = 3;
            activity2.Name = "1.3 Izrada komunikacijske strategije";
            activity2.Description = "Komunikacijska strategija promocije eko-edukativne staze na potezu " +
                                    "PP Drava-Mura mora uključivati zakup 2x lokalnih, 1x regionalnih i " +
                                    "1x nacionalnih radio postaja, 2x nacionalne dnevne novine .... ";
            activity2.DateStart = DateTime.Parse("01.05.2019.");
            activity2.DateEnd = DateTime.Parse("01.06.2019.");
            // activity2.ProofOfDelivery = null;
            activity2.IsFinished = true;
            activity2.DateAccepted = DateTime.Parse("03.06.2019.");
            activity2.AssociatedProject = 3;
            activity2.MemberID = 1; 
            
            _activities.Add((Activity)activity2);

            IActivity activity3 = Factory.ActivityFactory();
            activity3.id = 4;
            activity3.Name = "4.1. Koordinacijski sastanci";
            activity3.Description = "Izvršitelj je dužan napraviti zapisnik, držati potpisne liste te osigurati fotografski dokaz mjesečnih koordinacijskih sastanaka";
            activity3.DateStart = DateTime.Parse("15.01.2021.");
            activity3.DateEnd = DateTime.Parse("16.01.2021.");
            //activity3.ProofOfDelivery = null;
            activity3.IsFinished = true;
            activity3.DateAccepted = DateTime.Parse("16.01.2021.");
            activity3.AssociatedProject = 2;
            activity3.MemberID = 1;

            _activities.Add((Activity)activity3);

            IActivity activity4 = Factory.ActivityFactory();
            activity4.id = 5;
            activity4.Name = "3.2. Redovno fotografiranje aktivnosti projekta";
            activity4.Description = "Na poziv Naručitelja Izvršitelj je dužan fotografirati ključne faze provedbe projekta, \r\n10x dostvljanje min rezolucije 4000x3000 300dpi";
            activity4.DateStart = DateTime.Parse("17.04.2020.");
            activity4.DateEnd = DateTime.Parse("17.04.2020.");
            //activity4.ProofOfDelivery = null;
            activity4.IsFinished = true;
            activity4.DateAccepted = DateTime.Parse("18.04.2020.");
            activity4.AssociatedProject = 3;
            activity4.MemberID = 2;

            _activities.Add((Activity)activity4);

        }

    }
}
