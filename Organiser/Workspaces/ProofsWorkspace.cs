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

        public ProofOfDelivery SelectedProof { get; }

        public ProofsWorkspace (Main Main) : this()
        {
            this.Main = Main;
        }

        public ProofsWorkspace() 
        {
        
        }

        public void ProofMenu (ProofOfDelivery proof)
        {

            Console.Write("Working on proof: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(proof.DocumentName + "\n");
            Console.ResetColor();

            U04MenuTexts.ProofMenuText();
            ProofMenuSwitch(proof);
        }

        private void ProofMenuSwitch (ProofOfDelivery proof)
        {
            switch (U01UserInputs.InputIntZeroAllowed("Proof menu input: "))
            {
                case 1:
                    Console.WriteLine("Listing proofs");
                    U03GraphicElements.PrintStars();
                    List();
                    ProofMenu(proof);
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
            throw new NotImplementedException();
        }

        public void List ()
        {
            throw new NotImplementedException();
        }

        public void Update ()
        {
            throw new NotImplementedException();
        }

        public void Delete ()
        {
            throw new NotImplementedException();
        }
    }
}
