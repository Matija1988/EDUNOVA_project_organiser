using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectOrg
{

    internal class ProofsUpdate
    {
        public List<ProofOfDelivery> ProofOfDeliveries { get; }

        public List<Member> Members { get; }

        private Main Main { get; }
        public ProofsUpdate (Main Main) : this()
        {


            this.Main = Main;
        }

        public ProofsUpdate ()
        {

        }

        public void UpdateProofs ()
        {
            try
            {

                int indexID = U01UserInputs.InputInt("Choose the ID of the entry you wish to update: ");

                var ProofOfDelivieries = Main.TestDataConstructor.Activities;

                var ProofOfDelivery = Main.TestDataConstructor.ProofOfDeliveries[0];

                ProofOfDeliveries.ForEach(p => { if (p.id == indexID) { ProofOfDelivery = p; } });

                U04MenuTexts.UpdateProofsMenu();

                switch (U01UserInputs.InputIntZeroAllowed("Choose which atribute you wish to update: "))
                {
                    case 1:

                        string documentName = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                          "\n" + "Previous input: " + ProofOfDelivery.DocumentName +
                                                                            "\n" + "New input: ");

                        bool validation = U01UserInputs.InputBool("\n" + "Change proof information " +
                                                                   "\n" +
                                                                    "\n" + "Previous entry: " + ProofOfDelivery.DocumentName +
                                                                     "\n" + "New entry: " + documentName +
                                                                      "\n");

                        if (validation)
                        {
                            ProofOfDelivery.DocumentName = documentName;
                        }

                        break;

                    case 2:

                        string location = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                     "\n" + "Previous input: " + ProofOfDelivery.Location +
                                                                      "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change proof information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + ProofOfDelivery.Location +
                                                                "\n" + "New entry: " + location +
                                                                 "\n");

                        if (validation)
                        {
                            ProofOfDelivery.Location = location;
                        }
                        break;

                    case 3:

                        Member member = Main.TestDataConstructor.Members[U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                                                                 "\n" + "Previous input: " + ProofOfDelivery.Member +
                                                                                                  "\n" + "New input: ") - 1];

                        validation = U01UserInputs.InputBool("\n" + "Change proof information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + ProofOfDelivery.Member +
                                                                "\n" + "New entry: " + member +
                                                                 "\n");

                        if (validation)
                        {
                            ProofOfDelivery.Member = member;
                        }
                        break;

                    case 4:

                        DateTime dateCreated = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                            "\n" + "Previous input: " + ProofOfDelivery.DateCreated +
                                                                             "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change proof information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + ProofOfDelivery.DateCreated +
                                                                "\n" + "New entry: " + dateCreated +
                                                                 "\n");

                        if (validation)
                        {
                            ProofOfDelivery.DateCreated = dateCreated;
                        }
                        break;

                    case 5:

                        documentName = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                  "\n" + "Previous input: " + ProofOfDelivery.DocumentName +
                                                                   "\n" + "New input: ");

                        location = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                              "\n" + "Previous input: " + ProofOfDelivery.Location +
                                                               "\n" + "New input: ");

                        member = Main.TestDataConstructor.Members[U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                                                          "\n" + "Previous input: " + ProofOfDelivery.Member +
                                                                                           "\n" + "New input: ") - 1];

                        dateCreated = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                   "\n" + "Previous input: " + ProofOfDelivery.DateCreated +
                                                                    "\n" + "New input: ");


                        validation = U01UserInputs.InputBool("\n" + "Change activity information? " +
                                                              "\n" +
                                                               "\n" + "Previus input: " + ProofOfDelivery +
                                                                "\n" + "New name: " + documentName + " || " + "New location: " + location + " || " + "Created on: " + dateCreated +
                                                                      " || " + "Created by: " + member +
                                                                    "\n" + "Accept changes: 1) YES / 2) NO | ");

                        if(validation)
                        {
                            ProofOfDelivery.DocumentName = documentName;
                            ProofOfDelivery.Location = location;
                            ProofOfDelivery.DateCreated = dateCreated;
                            ProofOfDelivery.Member = member;
                         
                        }

                        break;

                    case 0:
                        Main.ProjectWorkspace.ProjectsMenu();
                        break;



                }

            }
            catch
            {
                Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
            }
            Main.ProjectWorkspace.ProjectsMenu();
        }

    }
}
