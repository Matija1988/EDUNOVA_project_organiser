using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PO
{


    internal class ProofWorkspace
    {

        public List<O04Member> Members { get; }

        public List<O06ProofOfDelivery> ProofOfDeliveries { get; set;  }
        private MembersWorkspace MembersWorkspace { get; }

      
        private Main Main { get; }

        private ActivitiesWorkspace ActivitiesWorkspace { get; }


        public ProofWorkspace (Main main) : this()
        {

            this.Main = main;
            this.MembersWorkspace = main.MembersWorkspace;
            this.ActivitiesWorkspace = main.ActivitiesWorkspace;
            

        }


        public ProofWorkspace ()
        {
            ProofOfDeliveries = new List<O06ProofOfDelivery>();



            TestData();
        }



        public void TestData ()
        {


            ProofOfDeliveries.Add(new O06ProofOfDelivery()
            {

                id = 1,
                DocumentName = "Media plan",
                Location = "//Urbana aglomeracija zamisljeni grad//1.1. Izrada media plana//",
            //    Member = Main.MembersWorkspace.Members[1],
                DateCreated = DateTime.Parse("12.11.2021."),


            });




        }

        public void ProofMenu ()
        {
            U04MenuTexts.ProofMenuText();
            ProofMenuSwitch();
        }

        private void ProofMenuSwitch ()
        {
            switch (U01UserInputs.InputInt("Proof menu input: "))
            {
                case 1:
                    Console.WriteLine("Listing proofs");
                    U03GraphicElements.PrintStars();
                    ListProofs();

                    break;

                case 2:
                    Console.WriteLine("Adding new proof");
                    break;


                case 3:
                    Console.WriteLine("Editing extising proof");

                    break;

                case 4:
                    Console.WriteLine("Delete proof");
                    break;

                case 5:
                   // ActivitiesWorkspace.ActivitiesMenu();
                    break;

                case 6:
                    Main.MainMenu();
                    break;

                default:

                    break;
            }

        }

        private void ListProofs ()
        {

            var index = 0;

            ProofOfDeliveries.ForEach(p => { Console.WriteLine(++index + ") " + p); });


            ProofMenu();

        }
    }
}
