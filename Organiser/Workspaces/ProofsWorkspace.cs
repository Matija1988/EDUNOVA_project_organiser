using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Workspaces
{
    internal class ProofsWorkspace : IWorkspace
    {
        private Main Main { get; }

        public Activity SelectedActivity { get;  }

        public ProofOfDelivery SelectedProof { get; }

        public Project SelectedProject { get; } 

        public ProofsWorkspace (Main Main) : this()
        {
            this.Main = Main;
        }

        public ProofsWorkspace() 
        {
        
        }

        public void ProofMenu ()
        {

            Console.Write("Working on proof for activity:  " );
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Main.ActivitiesWorkspace.SelectedActivity.Name + "\n");
            Console.ResetColor();

            U04MenuTexts.ProofMenuText();
            ProofMenuSwitch();
        }

        private void ProofMenuSwitch ( )
        {
            switch (U01UserInputs.InputIntZeroAllowed("Proof menu input: "))
            {
                case 1:
                    Console.WriteLine("Listing proofs");
                    U03GraphicElements.PrintStars();
                    List();
                    ProofMenu();
                    break;

                case 2:
                    Console.WriteLine("Adding new proof");
                    Add();
                    break;


                case 3:
                    Console.WriteLine("Editing extising proof");
                    Update();
                    break;

                case 4:
                    Console.WriteLine("Delete proof");
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                        Delete();
                    }
                    else
                    {
                        U02ErrorMessages.LackOfAuthority();
                        Main.MainMenu();
                    }


                    break;

                case 5:
                    Main.ProjectWorkspace.ProjectsMenu();
                    break;

                case 6:
                    Main.MainMenu();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:

                    break;
            }

        }


        public void Add ()
        {


            int id = U01UserInputs.AutoIncrementID(Main.DataInitialisation._projects);

            Main.DataInitialisation._proofOfDeliveries.ForEach(p => { if (p.id == id) { id++; } });

            string location = Main.ProjectWorkspace.SelectedProject.Name + "/" + Main.ActivitiesWorkspace.SelectedActivity.Name;

            IProofOfDelivery proofOfDelivery = Factory.ProofOfDeliveryFactory();
            proofOfDelivery.id = id;
            proofOfDelivery.DocumentName = U01UserInputs.InputString("Enter document name: ");

            Main.MembersWorkspace.List();
            int memberid = U01UserInputs.InputInt("Created by:");
            var member = Main.DataInitialisation._members[0];

            Main.DataInitialisation._members.ForEach(m => { if (m.id == member.id) member = m; });

            proofOfDelivery.Member = member; 
            proofOfDelivery.Location = location;
            proofOfDelivery.Activity = Main.ActivitiesWorkspace.SelectedActivity;

            if(U01UserInputs.InputBool("Accept input: 1) YES / 2) NO | "))
            {
                Main.DataInitialisation._proofOfDeliveries.Add((ProofOfDelivery)proofOfDelivery);
            }

            ProofMenu(); 
        }

        public void List ()
        {
            U03GraphicElements.PrintStars ();

            Main.DataInitialisation._proofOfDeliveries.ForEach(p => 
            { 
                if (p.Activity == Main.ActivitiesWorkspace.SelectedActivity) 
                { 
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(p); 
                    Console.ResetColor();
                } 
            });

        }

        public void Update ()
        {
            throw new NotImplementedException();
        }

        public void Delete ()
        {
            int proofID = U01UserInputs.InputInt("Choose ID of proof you wish to delete: ");

            var proof = Main.DataInitialisation._proofOfDeliveries[0];

            Main.DataInitialisation._proofOfDeliveries.ForEach(p => { if (p.id == proof.id) proof = p;  });

            Main.DataInitialisation._proofOfDeliveries.Remove(proof);

        }

       
    }
}
