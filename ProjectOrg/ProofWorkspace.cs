﻿using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class ProofWorkspace
    {

        public List<Member> Members { get; }

        public List<ProofOfDelivery> ProofOfDeliveries { get; }

        private Main Main { get; }

        private TestDataConstructor TestDataConstructor;

        public ProofWorkspace (Main main) : this()
        {

            this.Main = main;
        }


        public ProofWorkspace ()
        {

        }


        public void ProofMenu ()
        {
            U04MenuTexts.ProofMenuText();

            ProofMenuSwitch();
        }

        private void ProofMenuSwitch ()
        {
            switch (U01UserInputs.InputIntZeroAllowed("Proof menu input: "))
            {
                case 1:
                    Console.WriteLine("Listing proofs");
                    U03GraphicElements.PrintStars();
                    ListProofs();
                    ProofMenu();
                    break;

                case 2:
                    Console.WriteLine("Adding new proof");
                    AddNewProof();
                    break;


                case 3:
                    Console.WriteLine("Editing extising proof");
                    UpdateProof(); 
                    break;

                case 4:
                    Console.WriteLine("Delete proof");
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                        DeleteProof();
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

        private void DeleteProof ()
        {
            ListProofs();

            int index = U01UserInputs.InputInt("Input the ID od the entry you wish to delete: ");

            ProofOfDelivery proofOfDelivery = Main.TestDataConstructor.ProofOfDeliveries[0];

            Main.TestDataConstructor.ProofOfDeliveries.ForEach(p => { if (p.id == index) { proofOfDelivery = p; } });

            Main.TestDataConstructor.ProofOfDeliveries.Remove(proofOfDelivery);

            ProofMenu();

        }

        private void UpdateProof ()
        {
            ListProofs();

            Main.ProofsUpdate.UpdateProofs();   
        }

        private void AddNewProof ()
        {
            ListProofs();

            int inputID = U01UserInputs.InputInt("Enter ID: ");
            try { 
            Main.TestDataConstructor.ProofOfDeliveries.ForEach(p =>
              {
                  if (p.id == inputID)
                  {
                      U02ErrorMessages.ErrorMessageInputExists();
                      AddNewProof();

                  }
              });

            Main.TestDataConstructor.ProofOfDeliveries.Add(new ProofOfDelivery()
            {
                id = inputID,
                DocumentName = U01UserInputs.InputString("Enter document name: "),
                Location = U01UserInputs.InputString("Enter document location: "),
                Member = Main.TestDataConstructor.Members[U01UserInputs.InputInt("Choose member: ") - 1],
                DateCreated = DateTime.Parse("07.02.2023.")

            });
            } catch
            {
                U02ErrorMessages.ErrorMessageInput();
                AddNewProof ();
            }
            ProofMenu();
        }

        private void ListProofs ()
        {

            var index = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Main.TestDataConstructor.ProofOfDeliveries.ForEach(p => {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(++index + ") " + p ); U03GraphicElements.PrintMinus(); });
            Console.ResetColor();



        }


    }

}
